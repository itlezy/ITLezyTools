using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EPocalipse.Json.Viewer;
using System.IO;
using Itlezy.Common.Platform;
using Itlezy.Common.JSON;

namespace EPocalipse.Json.JsonView
{
    public partial class MainForm : Form
    {
        public string CustomTitle { get; set; }
        private IJsonItemsSource jsonItemsSource;
        private IList<JsonItem> jsonItemsCache;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(bool persistent)
        {
            InitializeComponent();

            this.Persistent = persistent;
        }

        public MainForm(IJsonItemsSource jsonItemsSource)
        {
            InitializeComponent();

            this.jsonItemsSource = jsonItemsSource;
        }

        private void LoadFromString(String jsonString)
        {
            if (!String.IsNullOrEmpty(jsonString))
            {
                JsonViewer.ShowTab(Tabs.Viewer);
                JsonViewer.Json = jsonString;

                JsonItem jsonItem = new JsonItem()
                {
                    JsonString = jsonString
                };

                ListViewItem li = new ListViewItem(jsonItem.JsonAbbrev);
                li.Tag = jsonItem;

                lstJsonItems.Items.Add(li);
            }
        }

        private void LoadFromFile(String fileName)
        {
            LoadFromString(File.ReadAllText(fileName));
        }

        private void LoadFromClipboard()
        {
            LoadFromString(ClipboardHelper.GetText());
        }

        private void ReloadFromJsonItems(IList<JsonItem> jsonItems)
        {
            jsonItemsCache = jsonItems;

            if (jsonItems == null || jsonItems.Count == 0)
            {
                lstJsonItems.Items.Clear();
                return;
            }

            splitContainer1.Panel1Collapsed = false;

            int previousSelected = 0;

            if (lstJsonItems.SelectedItems.Count > 0)
            {
                previousSelected = lstJsonItems.Items.Count - lstJsonItems.SelectedItems[0].Index;
            }

            lstJsonItems.BeginUpdate();

            var listViewItems = new List<ListViewItem>();

            lstJsonItems.Items.Clear();

            foreach (JsonItem jsonItem in jsonItems)
            {
                // filter based on textbox content
                if (!String.IsNullOrEmpty(txtFilterJsonItems.Text) &&
                    jsonItem.JsonString.IndexOf(txtFilterJsonItems.Text, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    continue;
                }

                ListViewItem li = new ListViewItem(listViewItems.Count.ToString("D04") + " : " + jsonItem.JsonAbbrev);
                li.Tag = jsonItem;

                if (jsonItem.JsonString.Contains("jsonrpc"))
                {
                    if (jsonItem.JsonString.Contains("method"))
                    {
                        // request
                        li.BackColor = Color.SkyBlue;
                    }
                    else if (jsonItem.JsonString.Contains("result"))
                    {
                        // response
                        li.BackColor = Color.LightGreen;
                    }
                    else if (jsonItem.JsonString.Contains("error"))
                    {
                        // response
                        li.BackColor = Color.LightCoral;
                    }
                }

                listViewItems.Insert(0, li);
            }

            lstJsonItems.Items.AddRange(listViewItems.ToArray());

            int reselectIndex = lstJsonItems.Items.Count - previousSelected;

            if (reselectIndex >= 0 &&
                reselectIndex < lstJsonItems.Items.Count &&
                previousSelected < lstJsonItems.Items.Count)
            {
                lstJsonItems.Items[reselectIndex].Selected = true;
            }

            lstJsonItems.EndUpdate();

            if (lstJsonItems.SelectedItems.Count > 0)
            {
                lstJsonItems.TopItem = lstJsonItems.SelectedItems[0];
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //JsonViewer.ShowTab(Tabs.Text);

            if (lstJsonItems.Items.Count == 0)
            {
                splitContainer1.Panel1Collapsed = true;
            }

            lstJsonItems.Columns[0].Width = lstJsonItems.Width - 5;

            if (jsonItemsSource != null)
            {
                ReloadFromJsonItems(jsonItemsSource.JsonItems);
            }

            reloadJsonItemsToolStripMenuItem.Visible = jsonItemsSource != null;

            if (!String.IsNullOrWhiteSpace(CustomTitle))
            {
                this.Text += " | " + CustomTitle;
            }
        }

        /// <summary>
        /// Closes the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Menu item File > Exit</remarks>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Open File Dialog  for Yahoo! Pipe files or JSON files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Menu item File > Open</remarks>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter =
                "Yahoo! Pipe files (*.run)|*.run|json files (*.json)|*.json|All files (*.*)|*.*";
            dialog.InitialDirectory = Application.StartupPath;
            dialog.Title = "Select a JSON file";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.LoadFromFile(dialog.FileName);
            }
        }


        /// <summary>
        /// Selects all text in the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Menu item Edit > Select All</remarks>
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control c;
            c = this.JsonViewer.Controls.Find("txtJson", true)[0];
            ((RichTextBox)c).SelectAll();
        }

        /// <summary>
        /// Deletes selected text in the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Menu item Edit > Delete</remarks>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control c;
            c = this.JsonViewer.Controls.Find("txtJson", true)[0];
            string text;
            if (((RichTextBox)c).SelectionLength > 0)
                text = ((RichTextBox)c).SelectedText;
            else
                text = ((RichTextBox)c).Text;
            ((RichTextBox)c).SelectedText = "";
        }

        /// <summary>
        /// Pastes text in the clipboard into the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Menu item Edit > Paste</remarks>
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control c;
            c = this.JsonViewer.Controls.Find("txtJson", true)[0];
            ((RichTextBox)c).Paste();
        }

        /// <summary>
        /// Copies text in the textbox into the clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Menu item Edit > Copy</remarks>
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control c;
            c = this.JsonViewer.Controls.Find("txtJson", true)[0];
            ((RichTextBox)c).Copy();
        }

        /// <summary>
        /// Cuts selected text from the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Menu item Edit > Cut</remarks>
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control c;
            c = this.JsonViewer.Controls.Find("txtJson", true)[0];
            ((RichTextBox)c).Cut();
        }

        /// <summary>
        /// Undo the last action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Menu item Edit > Undo</remarks>
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control c;
            c = this.JsonViewer.Controls.Find("txtJson", true)[0];
            ((RichTextBox)c).Undo();
        }

        /// <summary>
        /// Displays the find prompt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Menu item Viewer > Find</remarks>
        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control c;
            c = this.JsonViewer.Controls.Find("pnlFind", true)[0];
            ((Panel)c).Visible = true;
            Control t;
            t = this.JsonViewer.Controls.Find("txtFind", true)[0];
            ((TextBox)t).Focus();
        }

        /// <summary>
        /// Expands all the nodes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Menu item Viewer > Expand All</remarks>
        /// <!---->
        private void expandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control c;
            c = this.JsonViewer.Controls.Find("tvJson", true)[0];
            ((TreeView)c).BeginUpdate();
            try
            {
                if (((TreeView)c).SelectedNode != null)
                {
                    TreeNode topNode = ((TreeView)c).TopNode;
                    ((TreeView)c).SelectedNode.ExpandAll();
                    ((TreeView)c).TopNode = topNode;
                }
            }
            finally
            {
                ((TreeView)c).EndUpdate();
            }
        }

        /// <summary>
        /// Copies a node
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Menu item Viewer > Copy</remarks>
        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Control c;
            c = this.JsonViewer.Controls.Find("tvJson", true)[0];
            TreeNode node = ((TreeView)c).SelectedNode;
            if (node != null)
            {
                ClipboardHelper.SetText(node.Text);
            }
        }

        /// <summary>
        /// Copies just the node's value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Menu item Viewer > Copy Value</remarks>
        /// <!-- JsonViewerTreeNode had to be made public to be accessible here -->
        private void copyValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control c;
            c = this.JsonViewer.Controls.Find("tvJson", true)[0];
            JsonViewerTreeNode node = (JsonViewerTreeNode)((TreeView)c).SelectedNode;
            if (node != null && node.JsonObject.Value != null)
            {
                ClipboardHelper.SetText(node.JsonObject.Value.ToString());
            }
        }

        private bool Persistent
        {
            get;
            set;
        }

        void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            lstJsonItems.Items.Clear();

            if (this.Persistent)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        void TlsTaskbarCheckedChanged(object sender, EventArgs e)
        {
            this.ShowInTaskbar = tlsTaskbar.Checked;
        }

        void TlsOnTopClick(object sender, EventArgs e)
        {
            this.TopMost = tlsOnTop.Checked;
        }

        void LstJsonItemsSelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstJsonItems.SelectedItems.Count > 0)
            {
                JsonItem jsonItem = lstJsonItems.SelectedItems[0].Tag as JsonItem;

                JsonViewer.ShowTab(Tabs.Viewer);
                JsonViewer.Json = jsonItem.JsonString;
            }
        }

        void ReloadJsonItemsToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (jsonItemsSource != null)
            {
                ReloadFromJsonItems(jsonItemsSource.JsonItems);
            }
        }

        private void lstJsonItems_Resize(object sender, EventArgs e)
        {
            lstJsonItems.Columns[0].Width = lstJsonItems.Width - 5;
        }

        private void txtFilterJsonItems_TextChanged(object sender, EventArgs e)
        {
            if (jsonItemsSource != null)
            {
                ReloadFromJsonItems(jsonItemsCache);
            }
        }
    }
}