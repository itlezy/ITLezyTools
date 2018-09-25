using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Itlezy.App.Console.UI
{
    public partial class ConsoleMainForm : Form
    {
        public ConsoleMainForm()
        {
            InitializeComponent();
        }

        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTab();
        }

        private void NewTab()
        {
            TabPage t = new TabPage("Tab " + (tabConsole.TabPages.Count + 1) + " (" + DateTime.Now.ToString("HH:mm:ss") + ")");
            ConsoleUserControl u = new ConsoleUserControl();
            tabConsole.TabPages.Add(t);
            u.Dock = DockStyle.Fill;
            t.Controls.Add(u);
            tabConsole.SelectedTab = t;

            u.CommandEditor.Select();
            u.OutputViewer.ItemId = t.Text;
            // lower the timer interval
            u.OutputViewer.timUpdateText.Interval = 1000;
        }

        private void ConsoleForm_Load(object sender, EventArgs e)
        {
            NewTab();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentConsole.CommandEditor.Focus();
        }

        private ConsoleUserControl CurrentConsole
        {
            get
            {
                return tabConsole.SelectedTab.Controls[0] as ConsoleUserControl;
            }
        }

        private void ckOnTop_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = ckOnTop.Checked;
        }
    }
}
