namespace EPocalipse.Json.Viewer
{
    partial class JsonViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JsonViewer));
            this.spcViewer = new System.Windows.Forms.SplitContainer();
            this.tvJson = new System.Windows.Forms.TreeView();
            this.mnuTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuFind = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExpandAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyName = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyValue = new System.Windows.Forms.ToolStripMenuItem();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.pnlFind = new System.Windows.Forms.Panel();
            this.ckAutoExpand = new System.Windows.Forms.CheckBox();
            this.lblFontSize = new System.Windows.Forms.Label();
            this.numFontSize = new System.Windows.Forms.NumericUpDown();
            this.ckSortNodes = new System.Windows.Forms.CheckBox();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.lblFind = new System.Windows.Forms.Label();
            this.pnlVisualizer = new System.Windows.Forms.Panel();
            this.mnuVisualizerPnl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuShowOnRight = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShowOnBottom = new System.Windows.Forms.ToolStripMenuItem();
            this.cbVisualizers = new System.Windows.Forms.ComboBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.pageTreeView = new System.Windows.Forms.TabPage();
            this.pageTextView = new System.Windows.Forms.TabPage();
            this.txtJson = new System.Windows.Forms.RichTextBox();
            this.lblError = new System.Windows.Forms.LinkLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExpandAll = new System.Windows.Forms.ToolStripButton();
            this.btnCollapseAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPaste = new System.Windows.Forms.ToolStripButton();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFormat = new System.Windows.Forms.ToolStripButton();
            this.btnStrip = new System.Windows.Forms.ToolStripSplitButton();
            this.btnStripToCurly = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStripToSqr = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.removenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSpecialCharsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnViewSelected = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.spcViewer)).BeginInit();
            this.spcViewer.Panel1.SuspendLayout();
            this.spcViewer.Panel2.SuspendLayout();
            this.spcViewer.SuspendLayout();
            this.mnuTree.SuspendLayout();
            this.pnlFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).BeginInit();
            this.mnuVisualizerPnl.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.pageTreeView.SuspendLayout();
            this.pageTextView.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // spcViewer
            // 
            this.spcViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcViewer.Location = new System.Drawing.Point(3, 3);
            this.spcViewer.Name = "spcViewer";
            // 
            // spcViewer.Panel1
            // 
            this.spcViewer.Panel1.Controls.Add(this.tvJson);
            this.spcViewer.Panel1.Controls.Add(this.pnlFind);
            // 
            // spcViewer.Panel2
            // 
            this.spcViewer.Panel2.Controls.Add(this.pnlVisualizer);
            this.spcViewer.Panel2.Controls.Add(this.cbVisualizers);
            this.spcViewer.Size = new System.Drawing.Size(950, 706);
            this.spcViewer.SplitterDistance = 674;
            this.spcViewer.TabIndex = 5;
            // 
            // tvJson
            // 
            this.tvJson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvJson.ContextMenuStrip = this.mnuTree;
            this.tvJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvJson.FullRowSelect = true;
            this.tvJson.HideSelection = false;
            this.tvJson.ImageIndex = 0;
            this.tvJson.ImageList = this.imgList;
            this.tvJson.Location = new System.Drawing.Point(0, 0);
            this.tvJson.Name = "tvJson";
            this.tvJson.SelectedImageIndex = 0;
            this.tvJson.Size = new System.Drawing.Size(674, 674);
            this.tvJson.TabIndex = 1;
            this.tvJson.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvJson_BeforeExpand);
            this.tvJson.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvJson_AfterSelect);
            this.tvJson.KeyDown += new System.Windows.Forms.KeyEventHandler(this.JsonViewer_KeyDown);
            this.tvJson.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvJson_MouseDown);
            // 
            // mnuTree
            // 
            this.mnuTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFind,
            this.mnuExpandAll,
            this.toolStripMenuItem1,
            this.mnuCopy,
            this.mnuCopyName,
            this.mnuCopyValue});
            this.mnuTree.Name = "mnuTree";
            this.mnuTree.Size = new System.Drawing.Size(130, 120);
            this.mnuTree.Opening += new System.ComponentModel.CancelEventHandler(this.mnuTree_Opening);
            // 
            // mnuFind
            // 
            this.mnuFind.Name = "mnuFind";
            this.mnuFind.Size = new System.Drawing.Size(129, 22);
            this.mnuFind.Text = "&Find";
            this.mnuFind.Click += new System.EventHandler(this.findToolStripMenuItem_Click);
            // 
            // mnuExpandAll
            // 
            this.mnuExpandAll.Name = "mnuExpandAll";
            this.mnuExpandAll.Size = new System.Drawing.Size(129, 22);
            this.mnuExpandAll.Text = "Expand &All";
            this.mnuExpandAll.Click += new System.EventHandler(this.expandallToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(126, 6);
            // 
            // mnuCopy
            // 
            this.mnuCopy.Name = "mnuCopy";
            this.mnuCopy.Size = new System.Drawing.Size(129, 22);
            this.mnuCopy.Text = "&Copy";
            this.mnuCopy.Click += new System.EventHandler(this.mnuCopy_Click);
            // 
            // mnuCopyName
            // 
            this.mnuCopyName.Name = "mnuCopyName";
            this.mnuCopyName.Size = new System.Drawing.Size(129, 22);
            this.mnuCopyName.Text = "Copy Name";
            this.mnuCopyName.Click += new System.EventHandler(this.mnuCopyName_Click);
            // 
            // mnuCopyValue
            // 
            this.mnuCopyValue.Name = "mnuCopyValue";
            this.mnuCopyValue.Size = new System.Drawing.Size(129, 22);
            this.mnuCopyValue.Text = "Copy &Value";
            this.mnuCopyValue.Click += new System.EventHandler(this.mnuCopyValue_Click);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.White;
            this.imgList.Images.SetKeyName(0, "obj.bmp");
            this.imgList.Images.SetKeyName(1, "array.bmp");
            this.imgList.Images.SetKeyName(2, "prop.bmp");
            // 
            // pnlFind
            // 
            this.pnlFind.Controls.Add(this.ckAutoExpand);
            this.pnlFind.Controls.Add(this.lblFontSize);
            this.pnlFind.Controls.Add(this.numFontSize);
            this.pnlFind.Controls.Add(this.txtFind);
            this.pnlFind.Controls.Add(this.lblFind);
            this.pnlFind.Controls.Add(this.ckSortNodes);
            this.pnlFind.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFind.Location = new System.Drawing.Point(0, 674);
            this.pnlFind.Name = "pnlFind";
            this.pnlFind.Size = new System.Drawing.Size(674, 32);
            this.pnlFind.TabIndex = 6;
            // 
            // ckAutoExpand
            // 
            this.ckAutoExpand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckAutoExpand.AutoSize = true;
            this.ckAutoExpand.Checked = true;
            this.ckAutoExpand.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckAutoExpand.Location = new System.Drawing.Point(505, 8);
            this.ckAutoExpand.Name = "ckAutoExpand";
            this.ckAutoExpand.Size = new System.Drawing.Size(87, 17);
            this.ckAutoExpand.TabIndex = 7;
            this.ckAutoExpand.Text = "Auto Expan&d";
            this.ckAutoExpand.UseVisualStyleBackColor = true;
            this.ckAutoExpand.CheckedChanged += new System.EventHandler(this.ckAutoExpand_CheckedChanged);
            // 
            // lblFontSize
            // 
            this.lblFontSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFontSize.AutoSize = true;
            this.lblFontSize.Location = new System.Drawing.Point(397, 9);
            this.lblFontSize.Name = "lblFontSize";
            this.lblFontSize.Size = new System.Drawing.Size(51, 13);
            this.lblFontSize.TabIndex = 4;
            this.lblFontSize.Text = "Font Si&ze";
            // 
            // numFontSize
            // 
            this.numFontSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numFontSize.Location = new System.Drawing.Point(451, 6);
            this.numFontSize.Maximum = new decimal(new int[] {
            36,
            0,
            0,
            0});
            this.numFontSize.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numFontSize.Name = "numFontSize";
            this.numFontSize.Size = new System.Drawing.Size(47, 20);
            this.numFontSize.TabIndex = 5;
            this.numFontSize.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numFontSize.ValueChanged += new System.EventHandler(this.numFontSize_ValueChanged);
            // 
            // ckSortNodes
            // 
            this.ckSortNodes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckSortNodes.AutoSize = true;
            this.ckSortNodes.Location = new System.Drawing.Point(595, 8);
            this.ckSortNodes.Name = "ckSortNodes";
            this.ckSortNodes.Size = new System.Drawing.Size(79, 17);
            this.ckSortNodes.TabIndex = 6;
            this.ckSortNodes.Text = "&Sort Nodes";
            this.ckSortNodes.UseVisualStyleBackColor = true;
            this.ckSortNodes.CheckedChanged += new System.EventHandler(this.ckSortNodes_CheckedChanged);
            // 
            // txtFind
            // 
            this.txtFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFind.Location = new System.Drawing.Point(32, 6);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(360, 20);
            this.txtFind.TabIndex = 3;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            this.txtFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyDown);
            // 
            // lblFind
            // 
            this.lblFind.AutoSize = true;
            this.lblFind.Location = new System.Drawing.Point(3, 9);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(27, 13);
            this.lblFind.TabIndex = 2;
            this.lblFind.Text = "&Find";
            // 
            // pnlVisualizer
            // 
            this.pnlVisualizer.ContextMenuStrip = this.mnuVisualizerPnl;
            this.pnlVisualizer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVisualizer.Location = new System.Drawing.Point(0, 21);
            this.pnlVisualizer.Name = "pnlVisualizer";
            this.pnlVisualizer.Size = new System.Drawing.Size(272, 685);
            this.pnlVisualizer.TabIndex = 6;
            // 
            // mnuVisualizerPnl
            // 
            this.mnuVisualizerPnl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShowOnRight,
            this.mnuShowOnBottom});
            this.mnuVisualizerPnl.Name = "mnuVisualizerPnl";
            this.mnuVisualizerPnl.Size = new System.Drawing.Size(109, 48);
            // 
            // mnuShowOnRight
            // 
            this.mnuShowOnRight.Checked = true;
            this.mnuShowOnRight.CheckOnClick = true;
            this.mnuShowOnRight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuShowOnRight.Name = "mnuShowOnRight";
            this.mnuShowOnRight.Size = new System.Drawing.Size(108, 22);
            this.mnuShowOnRight.Text = "&Right";
            this.mnuShowOnRight.Click += new System.EventHandler(this.rightToolStripMenuItem_Click);
            // 
            // mnuShowOnBottom
            // 
            this.mnuShowOnBottom.CheckOnClick = true;
            this.mnuShowOnBottom.Name = "mnuShowOnBottom";
            this.mnuShowOnBottom.Size = new System.Drawing.Size(108, 22);
            this.mnuShowOnBottom.Text = "&Bottom";
            this.mnuShowOnBottom.Click += new System.EventHandler(this.rightToolStripMenuItem_Click);
            // 
            // cbVisualizers
            // 
            this.cbVisualizers.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbVisualizers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVisualizers.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbVisualizers.FormattingEnabled = true;
            this.cbVisualizers.Location = new System.Drawing.Point(0, 0);
            this.cbVisualizers.Name = "cbVisualizers";
            this.cbVisualizers.Size = new System.Drawing.Size(272, 21);
            this.cbVisualizers.Sorted = true;
            this.cbVisualizers.TabIndex = 5;
            this.cbVisualizers.SelectedIndexChanged += new System.EventHandler(this.cbVisualizers_SelectedIndexChanged);
            this.cbVisualizers.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cbVisualizers_Format);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.pageTreeView);
            this.tabControl.Controls.Add(this.pageTextView);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 25);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(964, 738);
            this.tabControl.TabIndex = 10;
            // 
            // pageTreeView
            // 
            this.pageTreeView.Controls.Add(this.spcViewer);
            this.pageTreeView.Location = new System.Drawing.Point(4, 22);
            this.pageTreeView.Name = "pageTreeView";
            this.pageTreeView.Padding = new System.Windows.Forms.Padding(3);
            this.pageTreeView.Size = new System.Drawing.Size(956, 712);
            this.pageTreeView.TabIndex = 0;
            this.pageTreeView.Text = "Viewer";
            this.pageTreeView.UseVisualStyleBackColor = true;
            // 
            // pageTextView
            // 
            this.pageTextView.Controls.Add(this.txtJson);
            this.pageTextView.Controls.Add(this.lblError);
            this.pageTextView.Location = new System.Drawing.Point(4, 22);
            this.pageTextView.Name = "pageTextView";
            this.pageTextView.Padding = new System.Windows.Forms.Padding(3);
            this.pageTextView.Size = new System.Drawing.Size(956, 712);
            this.pageTextView.TabIndex = 1;
            this.pageTextView.Text = "Text";
            this.pageTextView.UseVisualStyleBackColor = true;
            // 
            // txtJson
            // 
            this.txtJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtJson.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJson.HideSelection = false;
            this.txtJson.Location = new System.Drawing.Point(3, 3);
            this.txtJson.Name = "txtJson";
            this.txtJson.Size = new System.Drawing.Size(950, 682);
            this.txtJson.TabIndex = 7;
            this.txtJson.Text = "";
            this.txtJson.SelectionChanged += new System.EventHandler(this.txtJson_SelectionChanged);
            this.txtJson.TextChanged += new System.EventHandler(this.txtJson_TextChanged);
            // 
            // lblError
            // 
            this.lblError.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.lblError.LinkColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(3, 685);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(950, 24);
            this.lblError.TabIndex = 5;
            this.lblError.TabStop = true;
            this.lblError.Text = "aa";
            this.lblError.VisitedLinkColor = System.Drawing.Color.Red;
            this.lblError.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblError_LinkClicked);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExpandAll,
            this.btnCollapseAll,
            this.toolStripSeparator2,
            this.btnPaste,
            this.btnCopy,
            this.toolStripSeparator1,
            this.btnFormat,
            this.btnStrip,
            this.toolStripSplitButton1,
            this.btnViewSelected});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(964, 25);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnExpandAll
            // 
            this.btnExpandAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExpandAll.Image = ((System.Drawing.Image)(resources.GetObject("btnExpandAll.Image")));
            this.btnExpandAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExpandAll.Name = "btnExpandAll";
            this.btnExpandAll.Size = new System.Drawing.Size(61, 22);
            this.btnExpandAll.Text = "E&xpand All";
            this.btnExpandAll.Click += new System.EventHandler(this.btnExpandAll_Click);
            // 
            // btnCollapseAll
            // 
            this.btnCollapseAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCollapseAll.Image = ((System.Drawing.Image)(resources.GetObject("btnCollapseAll.Image")));
            this.btnCollapseAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCollapseAll.Name = "btnCollapseAll";
            this.btnCollapseAll.Size = new System.Drawing.Size(65, 22);
            this.btnCollapseAll.Text = "Collap&se All";
            this.btnCollapseAll.Click += new System.EventHandler(this.btnCollapseAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPaste
            // 
            this.btnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPaste.Image = ((System.Drawing.Image)(resources.GetObject("btnPaste.Image")));
            this.btnPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(38, 22);
            this.btnPaste.Text = "&Paste";
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(36, 22);
            this.btnCopy.Text = "&Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnFormat
            // 
            this.btnFormat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFormat.Image = ((System.Drawing.Image)(resources.GetObject("btnFormat.Image")));
            this.btnFormat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFormat.Name = "btnFormat";
            this.btnFormat.Size = new System.Drawing.Size(45, 22);
            this.btnFormat.Text = "&Format";
            this.btnFormat.Click += new System.EventHandler(this.btnFormat_Click);
            // 
            // btnStrip
            // 
            this.btnStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStripToCurly,
            this.btnStripToSqr});
            this.btnStrip.Image = ((System.Drawing.Image)(resources.GetObject("btnStrip.Image")));
            this.btnStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStrip.Name = "btnStrip";
            this.btnStrip.Size = new System.Drawing.Size(71, 22);
            this.btnStrip.Text = "Stri&p to {}";
            // 
            // btnStripToCurly
            // 
            this.btnStripToCurly.Name = "btnStripToCurly";
            this.btnStripToCurly.Size = new System.Drawing.Size(122, 22);
            this.btnStripToCurly.Text = "Strip to {}";
            this.btnStripToCurly.Click += new System.EventHandler(this.btnStripToCurly_Click);
            // 
            // btnStripToSqr
            // 
            this.btnStripToSqr.Name = "btnStripToSqr";
            this.btnStripToSqr.Size = new System.Drawing.Size(122, 22);
            this.btnStripToSqr.Text = "Strip to []";
            this.btnStripToSqr.Click += new System.EventHandler(this.btnStripToSqr_Click);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removenToolStripMenuItem,
            this.removeSpecialCharsToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(130, 22);
            this.toolStripSplitButton1.Text = "Remove new lines (\\n)";
            // 
            // removenToolStripMenuItem
            // 
            this.removenToolStripMenuItem.Name = "removenToolStripMenuItem";
            this.removenToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.removenToolStripMenuItem.Text = "Remove new lines (\\n)";
            this.removenToolStripMenuItem.Click += new System.EventHandler(this.removeNewLineMenuItem_Click);
            // 
            // removeSpecialCharsToolStripMenuItem
            // 
            this.removeSpecialCharsToolStripMenuItem.Name = "removeSpecialCharsToolStripMenuItem";
            this.removeSpecialCharsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.removeSpecialCharsToolStripMenuItem.Text = "Remove special chars (\\)";
            this.removeSpecialCharsToolStripMenuItem.Click += new System.EventHandler(this.removeSpecialCharsToolStripMenuItem_Click);
            // 
            // btnViewSelected
            // 
            this.btnViewSelected.CheckOnClick = true;
            this.btnViewSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnViewSelected.Image = ((System.Drawing.Image)(resources.GetObject("btnViewSelected.Image")));
            this.btnViewSelected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnViewSelected.Name = "btnViewSelected";
            this.btnViewSelected.Size = new System.Drawing.Size(77, 22);
            this.btnViewSelected.Text = "View Selected";
            this.btnViewSelected.Click += new System.EventHandler(this.btnViewSelected_Click);
            // 
            // JsonViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip1);
            this.Name = "JsonViewer";
            this.Size = new System.Drawing.Size(964, 763);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.JsonViewer_KeyDown);
            this.spcViewer.Panel1.ResumeLayout(false);
            this.spcViewer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcViewer)).EndInit();
            this.spcViewer.ResumeLayout(false);
            this.mnuTree.ResumeLayout(false);
            this.pnlFind.ResumeLayout(false);
            this.pnlFind.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).EndInit();
            this.mnuVisualizerPnl.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.pageTreeView.ResumeLayout(false);
            this.pageTextView.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcViewer;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.TreeView tvJson;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage pageTreeView;
        private System.Windows.Forms.TabPage pageTextView;
        private System.Windows.Forms.LinkLabel lblError;
        private System.Windows.Forms.Panel pnlVisualizer;
        private System.Windows.Forms.Panel pnlFind;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.ContextMenuStrip mnuTree;
        private System.Windows.Forms.ToolStripMenuItem mnuFind;
        private System.Windows.Forms.ToolStripMenuItem mnuExpandAll;
        private System.Windows.Forms.ContextMenuStrip mnuVisualizerPnl;
        private System.Windows.Forms.ToolStripMenuItem mnuShowOnRight;
        private System.Windows.Forms.ToolStripMenuItem mnuShowOnBottom;
        private System.Windows.Forms.ComboBox cbVisualizers;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyValue;
        private System.Windows.Forms.RichTextBox txtJson;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyName;
        private System.Windows.Forms.CheckBox ckSortNodes;
        private System.Windows.Forms.Label lblFontSize;
        private System.Windows.Forms.NumericUpDown numFontSize;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnPaste;
        private System.Windows.Forms.ToolStripButton btnCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnFormat;
        private System.Windows.Forms.ToolStripSplitButton btnStrip;
        private System.Windows.Forms.ToolStripMenuItem btnStripToCurly;
        private System.Windows.Forms.ToolStripMenuItem btnStripToSqr;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem removenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSpecialCharsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnViewSelected;
        private System.Windows.Forms.ToolStripButton btnExpandAll;
        private System.Windows.Forms.ToolStripButton btnCollapseAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.CheckBox ckAutoExpand;

    }
}
