using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Itlezy.Common.Platform;

namespace Itlezy.App.OutputViewer.UI
{
    public enum OutputKind
    {
        STDOUT, STDERR
    }

    public partial class OutputViewerMainForm : Form
    {
        private readonly IDictionary<String, OutputViewerUserControl> existingViewers = new Dictionary<String, OutputViewerUserControl>();

        public bool Persistent
        {
            get;
            set;
        }

        private void AppendMsgI(String itemId, String msg, OutputKind kind)
        {
            OutputViewerUserControl outputViewerUserControl = null;

            if (existingViewers.Keys.Contains(itemId))
            {
                outputViewerUserControl = existingViewers[itemId];
            }
            else
            {
                TabPage tabPage = new TabPage(itemId);
                tabPage.Tag = itemId;

                outputViewerUserControl = new OutputViewerUserControl() { ItemId = itemId, CustomTitle = CustomTitle };
                existingViewers.Add(itemId, outputViewerUserControl);

                outputViewerUserControl.Dock = DockStyle.Fill;
                tabPage.Controls.Add(outputViewerUserControl);

                outputViewerUserControl.NewContent += delegate()
                {
                    Invoke(new MethodInvoker(delegate
                    {
                        if (!tabContainer.SelectedTab.Equals(tabPage) && !tabPage.Text.EndsWith(" *"))
                        {
                            tabPage.Text += " *";
                        }
                    }));
                };

                tabPage.Enter += delegate(object sender, EventArgs e)
                {
                    Invoke(new MethodInvoker(delegate
                    {
                        if (tabPage.Text.EndsWith(" *"))
                        {
                            tabPage.Text = tabPage.Text.Remove(tabPage.Text.Length - 2);
                        }
                    }));
                };

                tabContainer.TabPages.Add(tabPage);
                tabContainer.SelectedTab = tabPage;
            }

            if (!AppContext.ContainerExiting(new ContainerControl[] { this, outputViewerUserControl }))
            {
                outputViewerUserControl.AppendMsg(msg, kind);
            }
        }

        public void AppendMsg(String itemId, String msg, OutputKind kind)
        {
            if (!AppContext.ContainerExiting(this))
            {
                Invoke(new MethodInvoker(delegate
                {
                    if (!AppContext.ContainerExiting(this))
                    {
                        AppendMsgI(itemId, msg, kind);
                    }
                }));
            }
        }

        public OutputViewerMainForm()
        {
            InitializeComponent();
        }

        void CkOnTopCheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = ckOnTop.Checked;
        }

        void OutputViewerFormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Persistent)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        void OutputViewerLoad(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(CustomTitle))
            {
                this.Text += " | " + CustomTitle;
            }

            UpdateButtonStatus();

            var wa = Screen.FromControl(this).WorkingArea;
            this.Width = wa.Width - 20;
            this.Left = 10;
            this.Top = 30;
        }

        void CkTaskbarCheckedChanged(object sender, EventArgs e)
        {
            this.ShowInTaskbar = ckTaskbar.Checked;
        }

        void BtnOpenClick(object sender, EventArgs e)
        {
            OpenFiles();
        }

        private void OpenFiles()
        {
            using (OpenFileDialog of = new OpenFileDialog())
            {
                of.Multiselect = true;

                if (DialogResult.OK == of.ShowDialog())
                {
                    foreach (String fileName in of.FileNames)
                    {
                        OpenFile(fileName);
                    }
                }
            }
        }

        public void OpenFile(String filePath)
        {
            OpenFile(filePath, String.Empty);
        }

        public void OpenFile(String filePath, String tabName)
        {
            FileInfo fi = new FileInfo(filePath);
            tabName = (tabName == String.Empty) ? fi.Directory.Name + " | " + fi.Name : tabName;
            AppendMsg(tabName, "Tailing file " + fi.FullName, OutputKind.STDOUT);

            OutputViewerUserControl outputViewerUserControl = existingViewers[tabName];

            if (outputViewerUserControl != null)
            {
                outputViewerUserControl.Tail(fi.FullName);
            }

            UpdateButtonStatus();
        }

        void BtnCloseClick(object sender, EventArgs e)
        {
            OutputViewerUserControl outputViewerUserControl = existingViewers[tabContainer.SelectedTab.Tag as String];

            if (outputViewerUserControl != null)
            {
                existingViewers.Remove(outputViewerUserControl.ItemId);

                OutputViewerDetachedForm parent = null;

                if (outputViewerUserControl.Parent != null &&
                    outputViewerUserControl.Parent.Parent != null)
                {
                    parent = outputViewerUserControl.Parent.Parent as OutputViewerDetachedForm;
                }

                outputViewerUserControl.DisposeTail();
                outputViewerUserControl.Dispose();

                if (parent is OutputViewerDetachedForm)
                {
                    // not necessary, 'cause the close is disabled anyway for a detached form
                    parent.Dispose();
                }

                TabPage selectedTab = tabContainer.SelectedTab;
                tabContainer.TabPages.Remove(selectedTab);
            }
        }

        void TabContainerSelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonStatus();

            foreach (TabPage tabPage in tabContainer.TabPages)
            {
                OutputViewerUserControl outputViewerUserControl = existingViewers[tabPage.Tag as String];

                if (tabPage.Equals(tabContainer.SelectedTab))
                {
                    outputViewerUserControl.Resume();
                    outputViewerUserControl.FocusOutput();
                }
                else
                {
                    if (HasTabPageControls(tabPage))
                    {
                        outputViewerUserControl.Pause();
                    }
                }
            }
        }

        /// <summary>
        /// Has the tab page been detached?
        /// </summary>
        private bool HasTabPageControls(TabPage t)
        {
            return (t != null && t.Controls.Count > 0);
        }

        private void UpdateButtonStatus()
        {
            btnClose.Enabled = (tabContainer.SelectedTab != null &&
                tabContainer.SelectedTab.Text.Contains(" | ") &&
                HasTabPageControls(tabContainer.SelectedTab));

            btnDetach.Enabled = (tabContainer.SelectedTab != null &&
                HasTabPageControls(tabContainer.SelectedTab));
        }

        void BtnDetachClick(object sender, EventArgs e)
        {
            if (tabContainer.SelectedTab != null && HasTabPageControls(tabContainer.SelectedTab))
            {
                OutputViewerUserControl outputViewerUserControl = tabContainer.SelectedTab.Controls[0] as OutputViewerUserControl;

                if (outputViewerUserControl != null)
                {
                    OutputViewerDetachedForm outputViewerDetachedForm = new OutputViewerDetachedForm();
                    outputViewerDetachedForm.Closing += delegate(object sender1, CancelEventArgs e1)
                    {
                        if (!this.Disposing && !this.IsDisposed)
                        {
                            // Attach back to the tab
                            OutputViewerUserControl outputViewerUserControlE = outputViewerDetachedForm.Controls[0].Controls[0] as OutputViewerUserControl;
                            if (outputViewerUserControlE != null)
                            {
                                foreach (TabPage tabPage in tabContainer.TabPages)
                                {
                                    if (!HasTabPageControls(tabPage) &&
                                        outputViewerUserControlE.ItemId == (tabPage.Tag as String))
                                    {
                                        tabPage.Controls.Add(outputViewerUserControlE);
                                        break;
                                    }
                                }
                            }
                        }

                        UpdateButtonStatus();
                    };

                    tabContainer.SelectedTab.Controls.Remove(outputViewerUserControl);
                    outputViewerDetachedForm.Controls[0].Controls.Add(outputViewerUserControl);
                    outputViewerDetachedForm.Text = outputViewerUserControl.ItemId + " | " + CustomTitle;
                    outputViewerDetachedForm.Show();
                }
            }

            UpdateButtonStatus();
        }

        void BtnClearAllClick(object sender, EventArgs e)
        {
            foreach (TabPage tabPage in tabContainer.TabPages)
            {
                OutputViewerUserControl outputViewerUserControl = existingViewers[tabPage.Tag as String];

                outputViewerUserControl.ClearOutput(true);

                if (tabPage.Text.EndsWith(" *"))
                {
                    tabPage.Text = tabPage.Text.Remove(tabPage.Text.Length - 2);
                }
            }
        }

        private void OutputViewer_Activated(object sender, EventArgs e)
        {
            UpdateButtonStatus();
        }

        public void SelectTab(String logName)
        {
            foreach (TabPage tabPage in tabContainer.TabPages)
            {
                if (logName == tabPage.Tag as String)
                {
                    tabContainer.SelectedTab = tabPage;
                    break;
                }
            }
        }

        private void ActivateTab(int tabNum)
        {
            if (tabNum >= 0 && tabNum < tabContainer.TabPages.Count)
            {
                tabContainer.SelectedTab = tabContainer.TabPages[tabNum];
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.D1 | Keys.Control:
                    ActivateTab(0);
                    break;
                case Keys.D2 | Keys.Control:
                    ActivateTab(1);
                    break;
                case Keys.D3 | Keys.Control:
                    ActivateTab(2);
                    break;
                case Keys.D4 | Keys.Control:
                    ActivateTab(3);
                    break;
                case Keys.D5 | Keys.Control:
                    ActivateTab(4);
                    break;
                case Keys.D6 | Keys.Control:
                    ActivateTab(5);
                    break;
                case Keys.D7 | Keys.Control:
                    ActivateTab(6);
                    break;
                case Keys.D8 | Keys.Control:
                    ActivateTab(7);
                    break;
                case Keys.D9 | Keys.Control:
                    ActivateTab(8);
                    break;
                case Keys.D0 | Keys.Control:
                    ActivateTab(9);
                    break;
                //case Keys.O | Keys.Control:
                //    OpenFiles();
                //    return false;
                case Keys.F4 | Keys.Control:
                    // TODO awful
                    if (btnClose.Enabled)
                    {
                        BtnCloseClick(this, null);
                    }
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public string CustomTitle { get; set; }
    }
}
