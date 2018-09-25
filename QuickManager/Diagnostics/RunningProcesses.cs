using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Management;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using log4net;
using Itlezy.Common.Platform;
using Itlezy.Common.Diagnostics;

namespace Itlezy.App.QuickManager.Diagnostics.UI
{
    public partial class RunningProcesses : Form
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(RunningProcesses));

        private readonly ProcessStopper processStopper = new ProcessStopper();

        private class TagItem
        {
            public int ProcessId { get; set; }
            public String ExeName { get; set; }
            public String ExePath { get; set; }
            public String CommandLine { get; set; }
            public String WorkingDir { get; set; }
        }

        private readonly String actionXmlTemplate =
            "<action id=\"\">" + Environment.NewLine +
            "	<launch>" + Environment.NewLine +
            "		<exe>{0}</exe>" + Environment.NewLine +
            "		<parms>{1}</parms>" + Environment.NewLine +
            "		<workingDir>{2}</workingDir>" + Environment.NewLine +
            "		<createNoWindow>true</createNoWindow>" + Environment.NewLine +
            "	</launch>" + Environment.NewLine +
            "</action>";

        public RunningProcesses()
        {
            InitializeComponent();
        }

        void BtnRefreshClick(object sender, EventArgs e)
        {
            RefreshProcesses();
        }

        private void RefreshProcesses()
        {
            lstProcesses.Items.Clear();

            var wmiQueryString = "SELECT ProcessId, ExecutablePath, CommandLine FROM Win32_Process";
            using (var searcher = new ManagementObjectSearcher(wmiQueryString))
            using (var results = searcher.Get())
            {
                var query = from p in Process.GetProcesses()
                            join mo in results.Cast<ManagementObject>()
                            on p.Id equals (int)(uint)mo["ProcessId"]
                            where (!String.IsNullOrWhiteSpace((string)mo["ExecutablePath"]))
                            orderby Path.GetFileName((string)mo["ExecutablePath"])
                            select new
                        {
                            Process = p,
                            Path = (string)mo["ExecutablePath"] ?? String.Empty,
                            CommandLine = (string)mo["CommandLine"] ?? String.Empty,
                        };

                foreach (var item in query)
                {
                    TagItem ti = new TagItem()
                    {
                        ProcessId = item.Process.Id,
                        ExeName = Path.GetFileName(item.Path),
                        ExePath = item.Path,
                        CommandLine = item.CommandLine
                    };

                    try
                    {
                        ti.WorkingDir = ProcessUtilities.GetCurrentDirectory(item.Process.Id);
                    }
                    catch (Exception)
                    {
                        ti.WorkingDir = String.Empty;
                    }

                    if (ti.WorkingDir.ToLower().Contains("\\windows\\"))
                    {
                        ti.WorkingDir = String.Empty; //TODO for some processes (maybe 32 bit) is not accurate
                    }


                    ListViewItem li = lstProcesses.Items.Add("" + ti.ProcessId);
                    li.Tag = ti;
                    li.SubItems.Add(ti.ExeName);
                    li.SubItems.Add(ti.ExePath);
                    li.SubItems.Add(ti.WorkingDir);

                    li.SubItems.Add(ti.CommandLine);
                    li.SubItems.Add("");
                }
            }

            lstProcesses.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            lstProcesses.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
            lstProcesses.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.ColumnContent);
            lstProcesses.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Hide();
            }
            else if (keyData == Keys.F10)
            {
                BtnLocateClick(this, null);
            }
            else if (keyData == Keys.F9)
            {
                BtnPromptClick(this, null);
            }
            else if (keyData == Keys.K)
            {
                BtnKillClick(this, null);
            }
            else if (keyData == Keys.F5)
            {
                BtnRefreshClick(this, null);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        void BtnCopySelectedClick(object sender, EventArgs e)
        {
            if (lstProcesses.SelectedItems.Count > 0)
            {
                TagItem ti = lstProcesses.SelectedItems[0].Tag as TagItem;

                ClipboardHelper.SetText(
                    String.Format(
                        actionXmlTemplate,
                        ti.ExePath,
                        ti.CommandLine,
                        ti.WorkingDir
                    ));
            }
        }


        void BtnKillClick(object sender, EventArgs e)
        {
            if (lstProcesses.SelectedItems.Count > 0)
            {
                TagItem ti = lstProcesses.SelectedItems[0].Tag as TagItem;

                if (ti.ProcessId > 0)
                {
                    try
                    {
                        Process p = Process.GetProcessById(ti.ProcessId);

                        if (p != null)
                        {
                            processStopper.KillProcessTree(p);
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error("", ex);
                    }

                    Thread.Sleep(500);

                    RefreshProcesses();
                }
            }
        }

        void BtnLocateClick(object sender, EventArgs e)
        {
            if (lstProcesses.SelectedItems.Count > 0)
            {
                TagItem ti = lstProcesses.SelectedItems[0].Tag as TagItem;
                Process.Start("explorer.exe", "/Select,\"" + ti.ExePath + "\"");
            }
        }

        void BtnPromptClick(object sender, EventArgs e)
        {
            if (lstProcesses.SelectedItems.Count > 0)
            {
                TagItem ti = lstProcesses.SelectedItems[0].Tag as TagItem;
                Process.Start(
                    new ProcessStartInfo()
                    {
                        FileName = Environment.GetEnvironmentVariable("ComSpec"),
                        WorkingDirectory = Path.GetDirectoryName(ti.ExePath)
                    });
            }
        }

        void RunningProcessesFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        void CkTaskbarCheckedChanged(object sender, EventArgs e)
        {
            this.ShowInTaskbar = ckTaskbar.Checked;
        }

        void RunningProcessesActivated(object sender, EventArgs e)
        {
            RefreshProcesses();
        }

        void CkOnTopCheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = ckOnTop.Checked;
        }

        private void RunningProcesses_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
