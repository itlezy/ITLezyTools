using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Itlezy.App.Console.UI;
using Itlezy.App.Network.UI;
using Itlezy.App.OutputViewer.UI;
using Itlezy.App.QuickManager.Config;
using Itlezy.App.QuickManager.Diagnostics;
using Itlezy.App.QuickManager.Diagnostics.UI;
using Itlezy.App.ScratchPad.UI;
using Itlezy.Common.Config;
using Itlezy.Common.Diagnostics;
using Itlezy.Common.Platform;
using log4net;

namespace Itlezy.App.QuickManager.UI
{
    /// <summary>
    /// The ListView is populated based on a list of MonitorItems and Launch Items configured in an XML file
    /// For each ListViewItem that has an associated Url, a Thread is spawned to check for availability
    /// Each availability event, as well process start/stop events are enqueued in an UI update requests queue
    /// A timer updates the UI, based on the queue described above
    /// </summary>
    public partial class MainForm : Form
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(MainForm));

        private EnvironmentConfig environmentConfig;

        /// <summary>
        /// The actual XML configuration
        /// </summary>
        private readonly XmlDocument xQuickManagerConfig = new XmlDocument();

        private readonly XmlConfigHelper xmlConfigHelper = new XmlConfigHelper();
        private ProcessConfigurationManager processConfigurationManager;
        private readonly Itlezy.App.QuickManager.Diagnostics.ProcessStopper processStopper = new Itlezy.App.QuickManager.Diagnostics.ProcessStopper();
        private readonly ExternalLauncher externalLauncher = new ExternalLauncher();

        private readonly OutputViewerMainForm outputViewer = new OutputViewerMainForm() { Persistent = true };
        private readonly RunningProcesses runningProcesses = new RunningProcesses();
        private readonly ScratchPadForm scratchPad = new ScratchPadForm() { Persistent = true };
        private readonly SCide.MainForm scideForm = new SCide.MainForm() { Persistent = true };

        /// <summary>
        /// Enqueuing requests to updated the ListView
        /// </summary>
        private readonly ConcurrentQueue<ListViewItemUpdateRequest> listViewItemUpdateRequests = new ConcurrentQueue<ListViewItemUpdateRequest>();

        /// <summary>
        /// Holds the references to running monitor threads, in order to abort them upon configuration reload
        /// </summary>
        private IList<Thread> activeThreads = new List<Thread>();

        /// <summary>
        /// Is it the first launch or the configuration has been reloaded?
        /// </summary>
        private bool firstLaunch = true;

        /// <summary>
        /// Holds the custom title to append to the main window and messages
        /// </summary>
        private String customTitle;

        /// <summary>
        /// Multi-threading bug of WebRequest work-around
        /// </summary>
        private readonly Object lockObject = new Object();

        /// <summary>
        /// Multi-threading bug of WebRequest, alternative work-around
        /// </summary>
        private int inflightRequests = 0;

        /// <summary>
        /// The last started item, in order to support launches enqueuing
        /// </summary>
        private ListViewItem lastStartedItem;

        private class ListViewItemUpdateRequest
        {
            public ListViewItem ListViewItem { get; set; }
            public String Status { get; set; }
            public Color Color { get; set; }
        }

        /// <summary>
        /// Configuration file name, could be a command line parameter
        /// </summary>
        private String configurationFile = "QuickManagerConfig.xml";

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(String configurationFile)
        {
            InitializeComponent();

            if (!String.IsNullOrWhiteSpace(configurationFile) && File.Exists(configurationFile))
            {
                this.configurationFile = configurationFile;
            }
        }

        private void ShowInPrimaryScreen()
        {
            var wa = Screen.PrimaryScreen.WorkingArea;
            this.Width = Math.Min(1000, (int)((double)(wa.Width - 10) / 1.61803398874));
            this.Height = 460;
            this.Left = wa.Width - this.Width - 10;
            this.Top = wa.Height - this.Height - 30;
        }

        void MainFormLoad(object sender, EventArgs e)
        {
            UpdateTitle();

            UpdateTimerInterval();

            ShowInPrimaryScreen();

            // hide process details
            splitContainer1.Panel2Collapsed = true;

            ReloadConfig();
        }

        /// <summary>
        /// Reload the configuration file, terminates active threads and detaches active processes
        /// </summary>
        private void ReloadConfig()
        {
            foreach (Thread t in activeThreads)
            {
                try
                {
                    t.Abort();
                }
                catch (ThreadAbortException tax)
                {
                    logger.Warn("", tax);
                }
            }

            activeThreads.Clear();

            if (File.Exists(configurationFile))
            {
                xQuickManagerConfig.Load(configurationFile);

                this.environmentConfig = new EnvironmentConfig(xQuickManagerConfig);
                this.processConfigurationManager = new ProcessConfigurationManager(this.environmentConfig);

                this.customTitle = xmlConfigHelper.ReadString(xQuickManagerConfig.DocumentElement, "title");

                if (firstLaunch && !String.IsNullOrWhiteSpace(customTitle))
                {
                    this.notifyIcon.Text += " | " + customTitle;
                    this.notifyIcon.BalloonTipTitle += " | " + customTitle;
                    this.outputViewer.CustomTitle = customTitle;
                    this.scideForm.CustomTitle = customTitle;
                    this.scratchPad.CustomTitle = customTitle;
                }

                if (lstEvents.Items.Count > 0)
                {
                    lstEvents.Items.Clear();
                }

                IList<LaunchInfo> launchInfos = processConfigurationManager.ReadLaunchInfos(xQuickManagerConfig);

                foreach (LaunchInfo launchInfo in launchInfos.OrderBy(p => p.OrderBy).ThenBy(p => p.Id))
                {
                    ListViewItem li = lstEvents.Items.Add(launchInfo.Id);
                    li.SubItems.Add("...");
                    li.SubItems.Add(launchInfo.Url);

                    ItemConfig itemConfig = processConfigurationManager.ReadItemConfig(xQuickManagerConfig, launchInfo);

                    if (itemConfig.Startable)
                    {
                        li.SubItems.Add(itemConfig.ProcessStartInfo.WorkingDirectory);
                    }

                    li.Tag = itemConfig;
                }

                foreach (ListViewItem li in lstEvents.Items)
                {
                    ItemConfig itemConfig = li.Tag as ItemConfig;

                    if (!String.IsNullOrWhiteSpace(itemConfig.MonitorConfig.Url))
                    {
                        Thread thread = new Thread(new ParameterizedThreadStart(HandleUrl));
                        thread.IsBackground = true;
                        activeThreads.Add(thread);
                        thread.Start(li);
                    }

                    if (firstLaunch &&
                        itemConfig.CanStart &&
                        itemConfig.AutoStart)
                    {
                        li.Selected = true;

                        StartSelectedItem();
                    }
                }

                if (firstLaunch)
                {
                    // open logs only on first launch

                    foreach (XmlNode x in xQuickManagerConfig.SelectNodes("//logs/log/path"))
                    {
                        String filePath = x.InnerText;

                        if (xmlConfigHelper.ReadBool(x.ParentNode, "@autoStart", true) && File.Exists(filePath))
                        {
                            ShowOutputWindow();

                            outputViewer.OpenFile(
                                environmentConfig.Expand(
                                filePath, xmlConfigHelper.ReadString(x.ParentNode, "@env")),
                                xmlConfigHelper.ReadString(x.ParentNode, "@logName"));
                        }
                    }
                }

                lstEvents.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
                lstEvents.Columns[0].Width += 10;

                lstEvents.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                lstEvents.Columns[2].Width += 80;

                lstEvents.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.ColumnContent);
                lstEvents.Columns[3].Width += 80;

                //int totalWidth = 0;
                //foreach (ColumnHeader col in lstEvents.Columns)
                //{
                //    totalWidth += col.Width;
                //}

                //this.Width = totalWidth;
            }

            ClearSelection();

            firstLaunch = false;
        }

        void UpdateListViewItem(ListViewItemUpdateRequest listViewItemUpdateRequest)
        {
            if (!AppContext.ContainerExiting(this) &&
                   listViewItemUpdateRequest != null &&
                   listViewItemUpdateRequest.ListViewItem != null)
            {
                Invoke(
                    new MethodInvoker(
                        delegate
                        {
                            if (!AppContext.ContainerExiting(this))
                            {
                                listViewItemUpdateRequests.Enqueue(listViewItemUpdateRequest);
                            }
                        }));
            }
        }

        void Notify(String msg, ToolTipIcon notifyIcon)
        {
            if (!AppContext.ContainerExiting(this))
            {
                Invoke(new MethodInvoker(delegate
                {
                    this.notifyIcon.BalloonTipTitle = String.IsNullOrWhiteSpace(customTitle) ? "QuickManager" : "QuickManager | " + customTitle;
                    this.notifyIcon.BalloonTipText = "\r\n" + msg + "\r\n ";
                    this.notifyIcon.BalloonTipIcon = notifyIcon;
                    this.notifyIcon.ShowBalloonTip(1000000000);
                }));
            }
        }

        /// <summary>
        /// Thread-run monitor
        /// </summary>
        /// <param name="lio">ListViewItem</param>
        void HandleUrl(Object lio)
        {
            ListViewItem li = lio as ListViewItem;
            ItemConfig itemConfig = li.Tag as ItemConfig;
            MonitorConfig monitorConfig = itemConfig.MonitorConfig;

            /// Was available?
            bool previousStatus = false;
            String previousStatusMessage = String.Empty;

            while (true)
            {
                /// Is it currently available?
                bool currentStatus = false;
                String currentStatusMessage = String.Empty;

                // all this is because of a WebRequest bug TODO rewrite a small HttpClient
                lock (lockObject)
                {
                    // This is redundant, since the lock makes its job
                    if (inflightRequests == 0)
                    {
                        try
                        {
                            Interlocked.Increment(ref inflightRequests);

                            //logger.DebugFormat("InflightRequests {0}, URL {1}, Create", inflightRequests, monitorConfig.Url);

                            WebRequest request = WebRequest.Create(monitorConfig.Url);
                            request.Timeout = (int)timUpdateUI.Interval;

                            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                            {
                                if (HttpStatusCode.OK == response.StatusCode)
                                {
                                    currentStatus = true;
                                    currentStatusMessage = "" + response.StatusCode;
                                }
                                else
                                {
                                    currentStatus = false;
                                }
                            }
                        }
                        catch (WebException we)
                        {
                            currentStatus = false;

                            if (we != null && we.Response != null)
                            {
                                currentStatusMessage = "N/A - " + ((HttpWebResponse)we.Response).StatusCode;
                            }
                            else
                            {
                                currentStatusMessage = "N/A";
                            }
                        }
                        catch (Exception ex2)
                        {
                            currentStatus = false;
                            currentStatusMessage = "N/A - " + ex2.Message;
                        }
                        finally
                        {
                            Interlocked.Decrement(ref inflightRequests);
                            //logger.DebugFormat("InflightRequests {0}, URL {1}, Decrement", inflightRequests, monitorConfig.Url);
                        }
                    }
                    else
                    {
                        currentStatus = false;
                        currentStatusMessage = "Waiting " + inflightRequests;

                        //logger.DebugFormat("InflightRequests {0}, URL {1}, Wait", inflightRequests, monitorConfig.Url);
                    }
                }


                Thread.Sleep(2000);

                if (currentStatus)
                {
                    UpdateListViewItem(
                        new ListViewItemUpdateRequest()
                        {
                            ListViewItem = li,
                            Status = currentStatusMessage,
                            Color = Color.LightGreen
                        });
                }
                else
                {
                    UpdateListViewItem(
                        new ListViewItemUpdateRequest()
                        {
                            ListViewItem = li,
                            Status = currentStatusMessage,
                            // if the process is started, show the blue bg
                            Color = itemConfig.Process != null ? Color.SkyBlue : Color.LightCoral
                        });
                }

                if (currentStatus == true && previousStatus == false)
                {
                    Notify(monitorConfig.Id + " is now available", ToolTipIcon.Info);
                }
                else if (currentStatus == false && previousStatus == true)
                {
                    Notify(monitorConfig.Id + " is not available", ToolTipIcon.Error);
                }

                previousStatus = currentStatus;
                previousStatusMessage = currentStatusMessage;

                Thread.Sleep((int)numInterval.Value);
            }
        }

        void LstEventsMouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListView currentListView = sender as ListView;
            ListViewHitTestInfo currentItem = currentListView.HitTest(e.Location);

            if (currentItem != null && currentItem.Item != null)
            {
                MonitorConfig monitorConfig = (currentItem.Item.Tag as ItemConfig).MonitorConfig;

                if (!String.IsNullOrWhiteSpace(monitorConfig.Url))
                {
                    Process.Start(
                        xQuickManagerConfig.SelectSingleNode("//action[@default='true']").InnerText,
                        monitorConfig.Url);
                }
            }
        }

        void NotifyIcon1BalloonTipClicked(object sender, EventArgs e)
        {
            ShowForm(this);
        }

        void CkOnTopCheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = ckOnTop.Checked;
        }


        /// <summary>
        /// Application shutdown
        /// </summary>
        private void DoExit()
        {
            AppContext.IsContainerExiting = true;
            scideForm.Dispose();
            scratchPad.Dispose();
            outputViewer.Dispose();
            runningProcesses.Dispose();

            Application.Exit();
        }

        void BtnExitClick(object sender, EventArgs e)
        {
            DoExit();
        }

        /// <summary>
        /// Starts the browser on the selected item's url
        /// </summary>
        void BtnLaunchBrowserClick(object sender, EventArgs e)
        {
            if (HasSelectedItem)
            {
                MonitorConfig monitorConfig = SelectedItemConfig.MonitorConfig;

                if (!String.IsNullOrWhiteSpace(monitorConfig.Url))
                {
                    Process.Start(
                        xQuickManagerConfig.SelectSingleNode("//action[@id='" + (sender as Control).Name.Split('_')[1] + "']").InnerText,
                        monitorConfig.Url);
                }
            }
        }

        void TrkOpacityScroll(object sender, EventArgs e)
        {
            this.Opacity = trkOpacity.Value / 100.0;
        }

        void BtnToTrayClick(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// Updates buttons' status based on current selection
        /// </summary>
        void LstEventsItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            UpdateSelectionStatus();
        }

        void UpdateSelectionStatus()
        {
            ListViewItem li = SelectedItem;
            ItemConfig itemConfig = SelectedItemConfig;

            btnStart.Enabled = false;
            btnStop.Enabled = false;
            btnRestart.Enabled = false;
            prpProcessInfo.SelectedObject = null;
            splitContainer1.Panel2Collapsed = true;

            if (itemConfig != null)
            {
                txtSelectedItem.Text = itemConfig.MonitorConfig.Id;

                btnStart.Enabled = itemConfig.CanStart;
                btnStop.Enabled = itemConfig.CanStop;
                btnRestart.Enabled = itemConfig.CanRestart;

                if (itemConfig.Started && ckProcInfo.Checked)
                {
                    prpProcessInfo.SelectedObject = itemConfig.Process;
                    splitContainer1.Panel2Collapsed = false;
                }

                prpProcessInfo.Refresh();

                if (!String.IsNullOrWhiteSpace(itemConfig.MonitorConfig.Url))
                {
                    pnlUrlButtons.Enabled = true;
                }
                else
                {
                    pnlUrlButtons.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Unselect any ListViewItem
        /// </summary>
        void ClearSelection()
        {
            Invoke(new MethodInvoker(delegate
            {
                lstEvents.SelectedItems.Clear();
                lstEvents.SelectedIndices.Clear();

                foreach (ListViewItem li in lstEvents.Items)
                {
                    li.Selected = false;
                }

                lstEvents.Update();

                pnlUrlButtons.Enabled = false;
                btnStart.Enabled = false;
                btnStop.Enabled = false;
                btnRestart.Enabled = false;
                txtSelectedItem.Clear();
            }));
        }

        void BtnStartClick(object sender, EventArgs e)
        {
            StartSelectedItem();
        }

        private void StartSelectedItem()
        {
            if (CanSelectedItemStart)
            {
                var currentItem = SelectedItem;

                ClearSelection();

                StartItem(currentItem);
            }
        }

        void BtnRestartClick(object sender, EventArgs e)
        {
            if (HasSelectedItem)
            {
                btnRestart.Enabled = false;
                btnStart.Enabled = false;

                ListViewItem li = SelectedItem;
                ItemConfig itemConfig = SelectedItemConfig;

                if (itemConfig != null)
                {
                    if (itemConfig.Process != null && !itemConfig.Process.HasExited)
                    {
                        itemConfig.Restart = true;

                        StopSelectedItem(true);
                    }
                    else
                    {
                        itemConfig.Restart = false;

                        StartItem(li);
                    }
                }

                ClearSelection();
            }
        }

        void BtnStopClick(object sender, EventArgs e)
        {
            StopSelectedItem(false);
        }

        private void StopSelectedItem()
        {
            StopSelectedItem(false);
        }

        private void StopSelectedItem(bool restart)
        {
            if (CanSelectedItemStop)
            {
                var currentItemConfig = SelectedItemConfig;

                ClearSelection();

                currentItemConfig.Restart = restart;

                logger.DebugFormat("Stopping [{0}] [{1}]", currentItemConfig.MonitorConfig.Id, currentItemConfig.Process != null ? currentItemConfig.Process.ToString() : String.Empty);

                var stopThread = new Thread(new ParameterizedThreadStart(StopItem));
                stopThread.IsBackground = true;
                stopThread.Start(currentItemConfig);
            }
        }

        private void StopAllItems()
        {
            ClearSelection();

            foreach (ListViewItem li in lstEvents.Items)
            {
                ItemConfig currentItemConfig = li.Tag as ItemConfig;

                if (currentItemConfig != null && currentItemConfig.StartAll && currentItemConfig.CanStop)
                {
                    logger.DebugFormat("Stopping [{0}] [{1}]", currentItemConfig.MonitorConfig.Id, currentItemConfig.Process != null ? currentItemConfig.Process.ToString() : String.Empty);

                    var stopThread = new Thread(new ParameterizedThreadStart(StopItem));
                    stopThread.IsBackground = true;
                    stopThread.Start(currentItemConfig);
                }
            }
        }

        private void StartAllItems()
        {
            ClearSelection();

            foreach (ListViewItem li in lstEvents.Items)
            {
                ItemConfig currentItemConfig = li.Tag as ItemConfig;

                if (currentItemConfig != null && currentItemConfig.StartAll && currentItemConfig.CanStart)
                {
                    StartItem(li);
                }
            }
        }

        /// <summary>
        /// Start an Item belonging to a ListViewItem
        /// </summary>
        /// <param name="li">The selected ListViewItem</param>
        private void StartItem(ListViewItem li)
        {
            ItemConfig itemConfig = li.Tag as ItemConfig;

            ClearSelection();

            if (itemConfig != null && itemConfig.CanStart)
            {
                ShowOutputWindow();

                outputViewer.SelectTab(itemConfig.LogName);

                lastStartedItem = li;

                itemConfig.Process = new Process()
                {
                    StartInfo = itemConfig.ProcessStartInfo
                };

                itemConfig.Process.EnableRaisingEvents = true;
                itemConfig.Process.Exited += delegate(object sender_ex, EventArgs e_ex)
                {
                    logger.Debug("Process exit event");

                    if (itemConfig.Process != null && itemConfig.Process.HasExited)
                    {
                        if (AppContext.ContainerExiting(new ContainerControl[] { this, outputViewer }))
                        {
                            return;
                        }

                        // the exit event was being processed before the output queue was being shown in the outputViewer
                        Thread.Sleep(1000 + timUpdateUI.Interval);

                        outputViewer.AppendMsg(
                            itemConfig.LogName,
                            Environment.NewLine +
                            "<<<<" + Environment.NewLine +
                            " " + DateTime.Now.ToString("HH:mm:ss") + Environment.NewLine +
                            " Elapsed      : " + DateTime.Now.Subtract(itemConfig.StartTime).ToString(@"hh\:mm\:ss") + Environment.NewLine +
                            " Exited PID   : " + itemConfig.Process.Id + Environment.NewLine +
                            " Exit Code    : " + itemConfig.Process.ExitCode + Environment.NewLine +
                            " Working Dir  : " + itemConfig.ProcessStartInfo.WorkingDirectory + Environment.NewLine +
                            " Command Line : " + itemConfig.ProcessStartInfo.FileName + " " + itemConfig.ProcessStartInfo.Arguments + Environment.NewLine +
                            "<<<<",
                            OutputKind.STDOUT);

                        UpdateListViewItem(
                            new ListViewItemUpdateRequest()
                            {
                                ListViewItem = li,
                                Status = "Exit Code " + itemConfig.Process.ExitCode,
                                Color = Color.LightGray
                            });
                    }

                    itemConfig.Process = null;

                    if (itemConfig.Restart)
                    {
                        Invoke(new MethodInvoker(delegate { StartItem(li); }));
                    }
                    else if (itemConfig.StartNext != null)
                    {
                        StartItem(itemConfig.StartNext);
                    }

                    itemConfig.StartNext = null;
                    itemConfig.Restart = false;
                };

                if (itemConfig.ProcessStartInfo.CreateNoWindow)
                {
                    itemConfig.Process.ErrorDataReceived += delegate(object sender_ed, DataReceivedEventArgs e_ed)
                    {
                        if (!AppContext.ContainerExiting(new ContainerControl[] { this, outputViewer }))
                        {
                            outputViewer.AppendMsg(itemConfig.LogName, e_ed.Data, OutputKind.STDERR);
                        }
                    };

                    itemConfig.Process.OutputDataReceived += delegate(object sender_od, DataReceivedEventArgs e_od)
                    {
                        if (!AppContext.ContainerExiting(new ContainerControl[] { this, outputViewer }))
                        {
                            outputViewer.AppendMsg(itemConfig.LogName, e_od.Data, OutputKind.STDOUT);
                        }
                    };
                }

                itemConfig.StartTime = DateTime.Now;
                itemConfig.Process.Start();

                PrintStartedProcessInfo(itemConfig);

                if (itemConfig.ProcessStartInfo.CreateNoWindow)
                {
                    itemConfig.Process.BeginErrorReadLine();
                    itemConfig.Process.BeginOutputReadLine();
                }

                UpdateListViewItem(
                    new ListViewItemUpdateRequest()
                    {
                        ListViewItem = li,
                        Status = "Started",
                        Color = Color.LightGreen
                    });

                // bring the main window on top anyway, to start another item
                this.Activate();
            }
        }

        void StopItem(Object _itemConfig)
        {
            ItemConfig itemConfig = _itemConfig as ItemConfig;

            bool terminated = false;

            if (itemConfig.ProcessStopInfo != null)
            {
                if (itemConfig.ProcessStopInfo.ProcessStopKind == ProcessStopKind.TCP)
                {
                    terminated = processStopper.StopProcessWithTCP(itemConfig);
                }
                else if (itemConfig.ProcessStopInfo.ProcessStartInfo != null &&
                    itemConfig.ProcessStopInfo.ProcessStopKind == ProcessStopKind.PROCESS)
                {
                    ShowOutputWindow();

                    terminated = processStopper.StopProcessWithProcess(itemConfig, outputViewer, (int)numInterval.Value * 2);
                }
            }

            logger.DebugFormat("Terminated [{0}]", terminated);

            if (!terminated &&
                itemConfig.ProcessStartInfo != null &&
                itemConfig.Process != null)
            {
                try
                {
                    if (itemConfig.ProcessStartInfo.CreateNoWindow == false &&
                        itemConfig.Process.MainWindowHandle != IntPtr.Zero)
                    {
                        itemConfig.Process.CloseMainWindow();
                    }
                    else if (itemConfig.Process != null && !itemConfig.Process.HasExited)
                    {
                        processStopper.KillProcessTree(itemConfig.Process);
                    }
                }
                catch (InvalidOperationException ioex)
                {
                    logger.Error("", ioex);
                }
                catch (Exception ex)
                {
                    logger.Error("", ex);
                }
            }
        }

        private void PrintStartedProcessInfo(ItemConfig itemConfig)
        {
            // list the actual environment used to start the process, after variables expansion
            IDictionary<String, String> envd = new Dictionary<String, String>();

            foreach (var kv in itemConfig.ProcessStartInfo.EnvironmentVariables)
            {
                envd.Add(((DictionaryEntry)kv).Key.ToString(), ((DictionaryEntry)kv).Value.ToString());
            }

            StringBuilder env = new StringBuilder();
            foreach (var kv in envd.OrderBy(k => k.Key))
            {
                env.AppendLine("    " + kv.Key + " = " + kv.Value);
            }

            outputViewer.AppendMsg(itemConfig.LogName,
                ">>>>" + Environment.NewLine +
                " " + DateTime.Now.ToString("HH:mm:ss") + Environment.NewLine +
                " Started PID  : " + itemConfig.Process.Id + Environment.NewLine +
                " Working Dir  : " + itemConfig.ProcessStartInfo.WorkingDirectory + Environment.NewLine +
                " Command Line : " + itemConfig.ProcessStartInfo.FileName + " " + itemConfig.ProcessStartInfo.Arguments + Environment.NewLine +
                " Env          : " + Environment.NewLine +
                  env + Environment.NewLine +
                " Started PID  : " + itemConfig.Process.Id + Environment.NewLine +
                " Working Dir  : " + itemConfig.ProcessStartInfo.WorkingDirectory + Environment.NewLine +
                " Command Line : " + itemConfig.ProcessStartInfo.FileName + " " + itemConfig.ProcessStartInfo.Arguments + Environment.NewLine +
                " " + DateTime.Now.ToString("HH:mm:ss") + Environment.NewLine +
                ">>>>" + Environment.NewLine,
                OutputKind.STDOUT);
        }

        private void ShowOutputWindow()
        {
            ShowForm(outputViewer);
        }

        /// <summary>
        /// Lists the configured environments, pre-expansion
        /// </summary>
        private void ListEnvironments()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var env in environmentConfig.Environments.OrderBy(e => e.Key))
            {
                sb.AppendLine("Environment [" + env.Key + "], " + env.Value.Count + " Variables");

                foreach (var varInEnv in env.Value.OrderBy(e => e.Key))
                {
                    sb.AppendLine("    " + varInEnv.Key + " = " + varInEnv.Value);
                }

                sb.AppendLine("");
            }

            ShowOutputWindow();

            outputViewer.AppendMsg("Environments", sb.ToString(), OutputKind.STDOUT);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F12)
            {
                ListEnvironments();
                return false;
            }
            else if (keyData == Keys.F10)
            {
                LaunchExplorer();
                return false;
            }
            else if (keyData == Keys.F9 || keyData == (Keys.F9 | Keys.Shift))
            {
                LaunchCommandPrompt(keyData == (Keys.F9 | Keys.Shift));
                return false;
            }
            else if (keyData == Keys.F2)
            {
                StartSelectedItem();
                return false;
            }
            else if (keyData == (Keys.F2 | Keys.Shift))
            {
                StartAllItems();
                return false;
            }
            else if (keyData == Keys.F3)
            {
                StopSelectedItem();
                return false;
            }
            else if (keyData == (Keys.F3 | Keys.Shift))
            {
                StopAllItems();
                return false;
            }
            else if (keyData == Keys.F4)
            {
                if (btnRestart.Enabled)
                {
                    BtnRestartClick(this, null);
                }
                return false;
            }
            else if (keyData == Keys.F6)
            {
                if (btnStart.Enabled)
                {
                    EnqueueItem();
                }
                return false;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        /// <summary>
        /// Enqueue an Item for execution, after another stops
        /// </summary>
        private void EnqueueItem()
        {
            if (lastStartedItem != null && HasSelectedItem)
            {
                ItemConfig itemConfig = SelectedItemConfig;
                ItemConfig lastItemConfig = lastStartedItem.Tag as ItemConfig;

                if (itemConfig != null && itemConfig.Startable &&
                    lastItemConfig != null && lastItemConfig.Startable)
                {
                    lastItemConfig.StartNext = SelectedItem;

                    // set as lastStartedItem the item being enqueued
                    // in this way one can create different queues based on F2, F6, .. sequences
                    lastStartedItem = lastItemConfig.StartNext;

                    logger.DebugFormat("LastStartedItem is now {0}", lastStartedItem);
                }
            }

            ClearSelection();
        }

        /// <summary>
        /// Open a command prompt on the selected item's path
        /// </summary>
        private void LaunchCommandPrompt(bool copyCommand)
        {
            if (HasSelectedItem)
            {
                externalLauncher.LaunchCommandPrompt(SelectedItemConfig, copyCommand);
            }
        }

        /// <summary>
        /// Open an explorer window on the selected item's path
        /// </summary>
        private void LaunchExplorer()
        {
            if (HasSelectedItem)
            {
                externalLauncher.LaunchExplorer(SelectedItemConfig);
            }
        }

        void BtnOutputClick(object sender, EventArgs e)
        {
            ShowOutputWindow();
        }

        void BtnProcessesClick(object sender, EventArgs e)
        {
            ShowForm(runningProcesses);
        }

        void CkTaskbarCheckedChanged(object sender, EventArgs e)
        {
            this.ShowInTaskbar = ckTaskbar.Checked;
        }

        readonly PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        readonly Microsoft.VisualBasic.Devices.ComputerInfo computerInfo = new Microsoft.VisualBasic.Devices.ComputerInfo();

        /// <summary>
        /// Update window's title
        /// </summary>
        void UpdateTitle()
        {
            String title = "QuickManager " + Assembly.GetEntryAssembly().GetName().Version +
                (Environment.Is64BitProcess ? " | 64bit" : " | 32bit") +
                " | uptime " + TimeSpan.FromMilliseconds(Environment.TickCount).ToString(@"dd\.hh\:mm") + " | " +
                (Math.Round(cpuCounter.NextValue()) + "%").PadLeft(3) + " | " +
                ((computerInfo.TotalPhysicalMemory - computerInfo.AvailablePhysicalMemory) / 1024 / 1024) + "Mb";

            if (!String.IsNullOrWhiteSpace(customTitle))
            {
                title += " | " + customTitle;
            }

            if (this.Text != title)
            {
                this.Text = title;
            }
        }

        /// <summary>
        /// Updates the text and colors of the list view items
        /// </summary>
        void TimUpdateUITick(object sender, EventArgs e)
        {
            UpdateTitle();

            if (listViewItemUpdateRequests.Count > 0)
            {
                ListViewItemUpdateRequest liur;

                while (listViewItemUpdateRequests.TryDequeue(out liur))
                {
                    if (liur != null &&
                        liur.ListViewItem != null &&
                        (liur.ListViewItem.SubItems[1].Text != liur.Status ||
                        liur.ListViewItem.BackColor != liur.Color))
                    {
                        liur.ListViewItem.SubItems[1].Text = liur.Status;
                        liur.ListViewItem.BackColor = liur.Color;
                    }
                }
            }
        }

        private void UpdateTimerInterval()
        {
            timUpdateUI.Interval = (int)((decimal)numInterval.Value / (decimal)2.8);
        }

        void NumIntervalValueChanged(object sender, EventArgs e)
        {
            UpdateTimerInterval();
        }

        void BtnJsonViewerClick(object sender, EventArgs e)
        {
            EPocalipse.Json.JsonView.MainForm jsonView = new EPocalipse.Json.JsonView.MainForm() { CustomTitle = customTitle };
            jsonView.Show();
            jsonView.Activate();
        }

        void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            DoExit();
        }

        void NotifyIcon1MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ShowForm(this);
            }
        }

        void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            if (!AppContext.IsContainerExiting)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        void NotifyIcon1MouseMove(object sender, MouseEventArgs e)
        {
            ShowForm(this);
        }

        void RebootToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Reboot?", "Confirm",
                    MessageBoxButtons.YesNo))
            {
                new Platform.System().Reboot();
            }
        }

        void ShutdownToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Shutdown?", "Confirm",
                    MessageBoxButtons.YesNo))
            {
                new Platform.System().Poweroff();
            }
        }

        void LogoffToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Logoff?", "Confirm",
                    MessageBoxButtons.YesNo))
            {
                new Platform.System().Logoff();
            }
        }

        void NetConnectionsToolStripMenuItemClick(object sender, EventArgs e)
        {
            Process.Start(
                Environment.SystemDirectory + "\\control.exe", "netconnections");
        }

        void BtnScratchPadClick(object sender, EventArgs e)
        {
            ShowForm(scratchPad);
        }

        private void btnXmlExplorer_Click(object sender, EventArgs e)
        {
        }

        private void btnScintilla_Click(object sender, EventArgs e)
        {
            ShowForm(scideForm);
        }

        private void ShowForm(Form form)
        {
            if (form.WindowState == FormWindowState.Minimized && form.WindowState != FormWindowState.Maximized)
            {
                form.WindowState = FormWindowState.Normal;

                form.Top = 10;
                form.Left = 10;
            }

            form.Show();
            form.Activate();
        }

        private void portScannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new NetworkProbe().Show();
        }

        private void ckProcInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckProcInfo.Checked)
            {
                splitContainer1.Panel2Collapsed = true;
            }
        }

        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {
            ConsoleMainForm c = new ConsoleMainForm();
            c.Show();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool hasActiveProcess = false;
            StringBuilder sbProcesses = new StringBuilder();

            foreach (ListViewItem li in lstEvents.Items)
            {
                ItemConfig itemConfig = li.Tag as ItemConfig;

                if (itemConfig != null && itemConfig.Started)
                {
                    hasActiveProcess = true;

                    sbProcesses.AppendLine(" " + itemConfig.MonitorConfig.Id);
                }
            }

            if (!hasActiveProcess ||
                DialogResult.Yes == MessageBox.Show(
                "Reload configuration?" +
                Environment.NewLine +
                "The running processes will be detached. " +
                "They will still be running, but their output will be detached and their status will not be updated." +
                Environment.NewLine +
                "It is reccomended to stop first any process launched from QuickManager, " +
                "reload the configuration, and then start the processes again, in order to keep the process attached." +
                Environment.NewLine + Environment.NewLine +
                "Detected Running:" + Environment.NewLine +
                sbProcesses,
               "Reload",
               MessageBoxButtons.YesNo))
            {
                ReloadConfig();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(scideForm);
            scideForm.OpenFile(configurationFile);
            scideForm.SetLanguage("xml");
        }

        private void explorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "/Select,\"" + configurationFile + "\"");
        }

        private void programFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "/Select,\"" + Application.ExecutablePath + "\"");
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            lstEvents.Focus();
        }

        private void configurationToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if (HasSelectedItem)
            {
                configurationToolStripMenuItem.DropDownItems.Clear();

                foreach (String configFile in SelectedItemConfig.ConfigurationFiles)
                {
                    {
                        var configurationToolStripMenuSubItem = configurationToolStripMenuItem.DropDownItems.Add(configFile + " | E&xplorer");

                        configurationToolStripMenuSubItem.Enabled = File.Exists(configFile);

                        if (configurationToolStripMenuSubItem.Enabled)
                        {
                            configurationToolStripMenuSubItem.Tag = configFile;
                            configurationToolStripMenuSubItem.Click += (sender1, e1) =>
                            {
                                Process.Start("explorer.exe", "/Select,\"" + configurationToolStripMenuSubItem.Tag + "\"");
                            };
                        }
                    }

                    {
                        var configurationToolStripMenuSubItem = configurationToolStripMenuItem.DropDownItems.Add(configFile + " | E&dit");

                        configurationToolStripMenuSubItem.Enabled = File.Exists(configFile);

                        if (configurationToolStripMenuSubItem.Enabled)
                        {
                            configurationToolStripMenuSubItem.Tag = configFile;
                            configurationToolStripMenuSubItem.Click += (sender1, e1) =>
                            {
                                ShowForm(scideForm);
                                scideForm.OpenFile(configurationToolStripMenuSubItem.Tag.ToString());
                            };
                        }
                    }

                }
            }
        }

        private bool HasSelectedItem
        {
            get
            {
                return lstEvents.SelectedItems.Count > 0;
            }
        }

        private bool CanSelectedItemStart
        {
            get
            {
                return HasSelectedItem && SelectedItemConfig.CanStart;
            }
        }

        private bool CanSelectedItemStop
        {
            get
            {
                return HasSelectedItem && SelectedItemConfig.CanStop;
            }
        }

        private ListViewItem SelectedItem
        {
            get
            {
                if (HasSelectedItem)
                {
                    return lstEvents.SelectedItems[0];
                }

                return null;
            }
        }

        private ItemConfig SelectedItemConfig
        {
            get
            {
                if (HasSelectedItem)
                {
                    return lstEvents.SelectedItems[0].Tag as ItemConfig;
                }

                return null;
            }
        }

        private void lstEventsMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!HasSelectedItem)
            {
                e.Cancel = true;
                return;
            }

            configurationToolStripMenuItem.Enabled = SelectedItemConfig.ConfigurationFiles.Count > 0;
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(this);
        }

        private void showInPrimaryScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowInPrimaryScreen();
            ShowForm(this);
        }

    }
}
