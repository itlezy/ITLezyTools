namespace Itlezy.App.OutputViewer.UI
{
	partial class OutputViewerUserControl
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (tailMonitor != null)
			{
				tailMonitor.Dispose();
			}
			
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutputViewerUserControl));
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.jSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jSONViewerListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTop = new System.Windows.Forms.Panel();
            this.incrementalSearcher = new ScintillaNET.IncrementalSearcher();
            this.txtOutput = new ScintillaNET.Scintilla();
            this.btnJsonViewerList = new System.Windows.Forms.Button();
            this.ckAutoScroll = new System.Windows.Forms.CheckBox();
            this.txtErrorCount = new System.Windows.Forms.TextBox();
            this.btnMark = new System.Windows.Forms.Button();
            this.btnMailTo = new System.Windows.Forms.Button();
            this.btnScrollToTop = new System.Windows.Forms.Button();
            this.btnScrollToTail = new System.Windows.Forms.Button();
            this.txtRegexGroup = new System.Windows.Forms.TextBox();
            this.txtMessagesLen = new System.Windows.Forms.TextBox();
            this.btnFilterInfo = new System.Windows.Forms.Button();
            this.btnFilterError = new System.Windows.Forms.Button();
            this.btnFilterWarn = new System.Windows.Forms.Button();
            this.txtOutputLen = new System.Windows.Forms.TextBox();
            this.btnNotepad = new System.Windows.Forms.Button();
            this.lblFontSize = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.numFontSize = new System.Windows.Forms.NumericUpDown();
            this.ckWrap = new System.Windows.Forms.CheckBox();
            this.ckTail = new System.Windows.Forms.CheckBox();
            this.ckCase = new System.Windows.Forms.CheckBox();
            this.timUpdateText = new System.Windows.Forms.Timer(this.components);
            this.tltHelp = new System.Windows.Forms.ToolTip(this.components);
            this.ctxMenu.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jSONToolStripMenuItem,
            this.jSONViewerListToolStripMenuItem,
            this.xMLToolStripMenuItem});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ctxMenu.Size = new System.Drawing.Size(155, 70);
            // 
            // jSONToolStripMenuItem
            // 
            this.jSONToolStripMenuItem.Name = "jSONToolStripMenuItem";
            this.jSONToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.jSONToolStripMenuItem.Text = "&JSON";
            this.jSONToolStripMenuItem.Click += new System.EventHandler(this.JSONToolStripMenuItemClick);
            // 
            // jSONViewerListToolStripMenuItem
            // 
            this.jSONViewerListToolStripMenuItem.Name = "jSONViewerListToolStripMenuItem";
            this.jSONViewerListToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.jSONViewerListToolStripMenuItem.Text = "JSON &Viewer List";
            this.jSONViewerListToolStripMenuItem.Click += new System.EventHandler(this.JSONViewerListToolStripMenuItemClick);
            // 
            // xMLToolStripMenuItem
            // 
            this.xMLToolStripMenuItem.Name = "xMLToolStripMenuItem";
            this.xMLToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.xMLToolStripMenuItem.Text = "&XML";
            this.xMLToolStripMenuItem.Click += new System.EventHandler(this.XMLToolStripMenuItemClick);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.incrementalSearcher);
            this.panelTop.Controls.Add(this.btnJsonViewerList);
            this.panelTop.Controls.Add(this.ckAutoScroll);
            this.panelTop.Controls.Add(this.txtErrorCount);
            this.panelTop.Controls.Add(this.btnMark);
            this.panelTop.Controls.Add(this.btnMailTo);
            this.panelTop.Controls.Add(this.btnScrollToTop);
            this.panelTop.Controls.Add(this.btnScrollToTail);
            this.panelTop.Controls.Add(this.txtRegexGroup);
            this.panelTop.Controls.Add(this.txtMessagesLen);
            this.panelTop.Controls.Add(this.btnFilterInfo);
            this.panelTop.Controls.Add(this.btnFilterError);
            this.panelTop.Controls.Add(this.btnFilterWarn);
            this.panelTop.Controls.Add(this.txtOutputLen);
            this.panelTop.Controls.Add(this.btnNotepad);
            this.panelTop.Controls.Add(this.lblFontSize);
            this.panelTop.Controls.Add(this.btnSave);
            this.panelTop.Controls.Add(this.btnCopy);
            this.panelTop.Controls.Add(this.btnClear);
            this.panelTop.Controls.Add(this.numFontSize);
            this.panelTop.Controls.Add(this.ckWrap);
            this.panelTop.Controls.Add(this.ckTail);
            this.panelTop.Controls.Add(this.ckCase);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1185, 60);
            this.panelTop.TabIndex = 1;
            // 
            // incrementalSearcher
            // 
            this.incrementalSearcher.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.incrementalSearcher.AutoPosition = false;
            this.incrementalSearcher.BackColor = System.Drawing.SystemColors.Control;
            this.incrementalSearcher.ContentSearchTerm = "";
            this.incrementalSearcher.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.incrementalSearcher.Location = new System.Drawing.Point(383, 1);
            this.incrementalSearcher.Margin = new System.Windows.Forms.Padding(0);
            this.incrementalSearcher.Name = "incrementalSearcher";
            this.incrementalSearcher.Scintilla = this.txtOutput;
            this.incrementalSearcher.Size = new System.Drawing.Size(418, 25);
            this.incrementalSearcher.TabIndex = 14;
            this.incrementalSearcher.ToolItem = true;
            this.incrementalSearcher.Search += new ScintillaNET.IncrementalSearcher.SearchEventHandler(this.incrementalSearcher_Search);
            // 
            // txtOutput
            // 
            this.txtOutput.AcceptsTab = false;
            this.txtOutput.Caret.CurrentLineBackgroundColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtOutput.Caret.HighlightCurrentLine = true;
            this.txtOutput.ContextMenuStrip = this.ctxMenu;
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.DocumentNavigation.IsEnabled = false;
            this.txtOutput.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.IsBraceMatching = true;
            this.txtOutput.LineWrapping.VisualFlags = ScintillaNET.LineWrappingVisualFlags.End;
            this.txtOutput.Location = new System.Drawing.Point(0, 60);
            this.txtOutput.Margins.Margin0.IsClickable = true;
            this.txtOutput.Margins.Margin0.Width = 60;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(1185, 361);
            this.txtOutput.Styles.BraceBad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtOutput.Styles.BraceBad.Size = 11F;
            this.txtOutput.Styles.BraceLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtOutput.Styles.BraceLight.Size = 11F;
            this.txtOutput.Styles.ControlChar.Size = 11F;
            this.txtOutput.Styles.Default.BackColor = System.Drawing.SystemColors.Window;
            this.txtOutput.Styles.Default.Size = 11F;
            this.txtOutput.Styles.IndentGuide.Size = 11F;
            this.txtOutput.Styles.LastPredefined.Size = 11F;
            this.txtOutput.Styles.LineNumber.CharacterSet = ScintillaNET.CharacterSet.Ansi;
            this.txtOutput.Styles.LineNumber.FontName = "Consolas";
            this.txtOutput.Styles.LineNumber.Size = 9.75F;
            this.txtOutput.Styles.Max.Size = 11F;
            this.txtOutput.TabIndex = 41;
            this.txtOutput.MarginClick += new System.EventHandler<ScintillaNET.MarginClickEventArgs>(this.txtOutput_MarginClick);
            this.txtOutput.Scroll += new System.EventHandler<System.Windows.Forms.ScrollEventArgs>(this.txtOutput_Scroll);
            this.txtOutput.SelectionChanged += new System.EventHandler(this.txtOutput_SelectionChanged);
            this.txtOutput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOutput_KeyDown);
            this.txtOutput.Resize += new System.EventHandler(this.txtOutput_Resize);
            // 
            // btnJsonViewerList
            // 
            this.btnJsonViewerList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJsonViewerList.BackColor = System.Drawing.SystemColors.Control;
            this.btnJsonViewerList.Image = ((System.Drawing.Image)(resources.GetObject("btnJsonViewerList.Image")));
            this.btnJsonViewerList.Location = new System.Drawing.Point(855, 3);
            this.btnJsonViewerList.Name = "btnJsonViewerList";
            this.btnJsonViewerList.Size = new System.Drawing.Size(23, 23);
            this.btnJsonViewerList.TabIndex = 100;
            this.tltHelp.SetToolTip(this.btnJsonViewerList, "JSON Viewer");
            this.btnJsonViewerList.UseVisualStyleBackColor = false;
            this.btnJsonViewerList.Click += new System.EventHandler(this.btnJsonViewerList_Click);
            // 
            // ckAutoScroll
            // 
            this.ckAutoScroll.Checked = true;
            this.ckAutoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckAutoScroll.Location = new System.Drawing.Point(320, 3);
            this.ckAutoScroll.Name = "ckAutoScroll";
            this.ckAutoScroll.Size = new System.Drawing.Size(57, 24);
            this.ckAutoScroll.TabIndex = 12;
            this.ckAutoScroll.Text = "Sc&roll";
            this.tltHelp.SetToolTip(this.ckAutoScroll, "Autoscroll to tail");
            this.ckAutoScroll.UseVisualStyleBackColor = true;
            // 
            // txtErrorCount
            // 
            this.txtErrorCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtErrorCount.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtErrorCount.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtErrorCount.Location = new System.Drawing.Point(884, 32);
            this.txtErrorCount.Name = "txtErrorCount";
            this.txtErrorCount.ReadOnly = true;
            this.txtErrorCount.Size = new System.Drawing.Size(81, 22);
            this.txtErrorCount.TabIndex = 99;
            this.txtErrorCount.TabStop = false;
            this.txtErrorCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tltHelp.SetToolTip(this.txtErrorCount, "Error Count (includes Warnings)");
            // 
            // btnMark
            // 
            this.btnMark.BackColor = System.Drawing.SystemColors.Control;
            this.btnMark.Image = ((System.Drawing.Image)(resources.GetObject("btnMark.Image")));
            this.btnMark.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMark.Location = new System.Drawing.Point(195, 32);
            this.btnMark.Name = "btnMark";
            this.btnMark.Size = new System.Drawing.Size(90, 23);
            this.btnMark.TabIndex = 6;
            this.btnMark.Text = "Mar&k";
            this.tltHelp.SetToolTip(this.btnMark, "Write a timestamp marker to the log window");
            this.btnMark.UseVisualStyleBackColor = false;
            this.btnMark.Click += new System.EventHandler(this.BtnMarkClick);
            // 
            // btnMailTo
            // 
            this.btnMailTo.Image = ((System.Drawing.Image)(resources.GetObject("btnMailTo.Image")));
            this.btnMailTo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMailTo.Location = new System.Drawing.Point(195, 3);
            this.btnMailTo.Name = "btnMailTo";
            this.btnMailTo.Size = new System.Drawing.Size(90, 23);
            this.btnMailTo.TabIndex = 3;
            this.btnMailTo.Text = "&Mail";
            this.tltHelp.SetToolTip(this.btnMailTo, "Send content via e-mail");
            this.btnMailTo.UseVisualStyleBackColor = true;
            this.btnMailTo.Click += new System.EventHandler(this.BtnMailToClick);
            // 
            // btnScrollToTop
            // 
            this.btnScrollToTop.BackColor = System.Drawing.SystemColors.Control;
            this.btnScrollToTop.Image = ((System.Drawing.Image)(resources.GetObject("btnScrollToTop.Image")));
            this.btnScrollToTop.Location = new System.Drawing.Point(290, 3);
            this.btnScrollToTop.Name = "btnScrollToTop";
            this.btnScrollToTop.Size = new System.Drawing.Size(23, 23);
            this.btnScrollToTop.TabIndex = 10;
            this.tltHelp.SetToolTip(this.btnScrollToTop, "Go to the top (and suspend tailing)");
            this.btnScrollToTop.UseVisualStyleBackColor = false;
            this.btnScrollToTop.Click += new System.EventHandler(this.BtnScrollToTopClick);
            // 
            // btnScrollToTail
            // 
            this.btnScrollToTail.BackColor = System.Drawing.SystemColors.Control;
            this.btnScrollToTail.Image = ((System.Drawing.Image)(resources.GetObject("btnScrollToTail.Image")));
            this.btnScrollToTail.Location = new System.Drawing.Point(290, 32);
            this.btnScrollToTail.Name = "btnScrollToTail";
            this.btnScrollToTail.Size = new System.Drawing.Size(23, 23);
            this.btnScrollToTail.TabIndex = 11;
            this.tltHelp.SetToolTip(this.btnScrollToTail, "Go to the end (and resume tailing)");
            this.btnScrollToTail.UseVisualStyleBackColor = false;
            this.btnScrollToTail.Click += new System.EventHandler(this.BtnScrollToTailClick);
            // 
            // txtRegexGroup
            // 
            this.txtRegexGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegexGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtRegexGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtRegexGroup.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegexGroup.Location = new System.Drawing.Point(416, 32);
            this.txtRegexGroup.Name = "txtRegexGroup";
            this.txtRegexGroup.Size = new System.Drawing.Size(270, 22);
            this.txtRegexGroup.TabIndex = 15;
            this.tltHelp.SetToolTip(this.txtRegexGroup, "ENTER Filters text and copy to Clipboard\r\nSHIFT+ENTER Filters text and launch in " +
        "Notepad\r\nCTRL+SHIFT+ENTER Splits text based on RegEx groups, i.e. (ERROR)(.*) an" +
        "d launch in Notepad");
            this.txtRegexGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtRegexGroupKeyDown);
            // 
            // txtMessagesLen
            // 
            this.txtMessagesLen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessagesLen.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtMessagesLen.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessagesLen.Location = new System.Drawing.Point(1082, 32);
            this.txtMessagesLen.Name = "txtMessagesLen";
            this.txtMessagesLen.ReadOnly = true;
            this.txtMessagesLen.Size = new System.Drawing.Size(100, 22);
            this.txtMessagesLen.TabIndex = 99;
            this.txtMessagesLen.TabStop = false;
            this.txtMessagesLen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tltHelp.SetToolTip(this.txtMessagesLen, "Buffered lines");
            // 
            // btnFilterInfo
            // 
            this.btnFilterInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilterInfo.BackColor = System.Drawing.SystemColors.Control;
            this.btnFilterInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnFilterInfo.Image")));
            this.btnFilterInfo.Location = new System.Drawing.Point(884, 3);
            this.btnFilterInfo.Name = "btnFilterInfo";
            this.btnFilterInfo.Size = new System.Drawing.Size(23, 23);
            this.btnFilterInfo.TabIndex = 21;
            this.tltHelp.SetToolTip(this.btnFilterInfo, "Extract INFO level messages to Notepad");
            this.btnFilterInfo.UseVisualStyleBackColor = false;
            this.btnFilterInfo.Click += new System.EventHandler(this.BtnFilterInfoClick);
            // 
            // btnFilterError
            // 
            this.btnFilterError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilterError.BackColor = System.Drawing.SystemColors.Control;
            this.btnFilterError.Image = ((System.Drawing.Image)(resources.GetObject("btnFilterError.Image")));
            this.btnFilterError.Location = new System.Drawing.Point(942, 3);
            this.btnFilterError.Name = "btnFilterError";
            this.btnFilterError.Size = new System.Drawing.Size(23, 23);
            this.btnFilterError.TabIndex = 23;
            this.tltHelp.SetToolTip(this.btnFilterError, "Extract ERROR level messages to Notepad");
            this.btnFilterError.UseVisualStyleBackColor = false;
            this.btnFilterError.Click += new System.EventHandler(this.BtnFilterErrorClick);
            // 
            // btnFilterWarn
            // 
            this.btnFilterWarn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilterWarn.BackColor = System.Drawing.SystemColors.Control;
            this.btnFilterWarn.Image = ((System.Drawing.Image)(resources.GetObject("btnFilterWarn.Image")));
            this.btnFilterWarn.Location = new System.Drawing.Point(913, 3);
            this.btnFilterWarn.Name = "btnFilterWarn";
            this.btnFilterWarn.Size = new System.Drawing.Size(23, 23);
            this.btnFilterWarn.TabIndex = 22;
            this.tltHelp.SetToolTip(this.btnFilterWarn, "Extract WARN level messages to Notepad");
            this.btnFilterWarn.UseVisualStyleBackColor = false;
            this.btnFilterWarn.Click += new System.EventHandler(this.BtnFilterWarnClick);
            // 
            // txtOutputLen
            // 
            this.txtOutputLen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputLen.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtOutputLen.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutputLen.Location = new System.Drawing.Point(1082, 5);
            this.txtOutputLen.Name = "txtOutputLen";
            this.txtOutputLen.ReadOnly = true;
            this.txtOutputLen.Size = new System.Drawing.Size(100, 22);
            this.txtOutputLen.TabIndex = 99;
            this.txtOutputLen.TabStop = false;
            this.txtOutputLen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tltHelp.SetToolTip(this.txtOutputLen, "Lines displayed");
            // 
            // btnNotepad
            // 
            this.btnNotepad.Image = ((System.Drawing.Image)(resources.GetObject("btnNotepad.Image")));
            this.btnNotepad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNotepad.Location = new System.Drawing.Point(3, 32);
            this.btnNotepad.Name = "btnNotepad";
            this.btnNotepad.Size = new System.Drawing.Size(90, 23);
            this.btnNotepad.TabIndex = 4;
            this.btnNotepad.Text = "&Notepad";
            this.tltHelp.SetToolTip(this.btnNotepad, "Open in Notepad (current selection or entire content)");
            this.btnNotepad.UseVisualStyleBackColor = true;
            this.btnNotepad.Click += new System.EventHandler(this.BtnNotepadClick);
            // 
            // lblFontSize
            // 
            this.lblFontSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFontSize.Location = new System.Drawing.Point(973, 8);
            this.lblFontSize.Name = "lblFontSize";
            this.lblFontSize.Size = new System.Drawing.Size(55, 19);
            this.lblFontSize.TabIndex = 25;
            this.lblFontSize.Text = "Font Si&ze";
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(99, 32);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
            // 
            // btnCopy
            // 
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopy.Location = new System.Drawing.Point(99, 3);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(90, 23);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "&Copy";
            this.tltHelp.SetToolTip(this.btnCopy, "Copy selection or entire content");
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.BtnCopyClick);
            // 
            // btnClear
            // 
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(3, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "C&lear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClearClick);
            // 
            // numFontSize
            // 
            this.numFontSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numFontSize.Location = new System.Drawing.Point(1034, 6);
            this.numFontSize.Maximum = new decimal(new int[] {
            36,
            0,
            0,
            0});
            this.numFontSize.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numFontSize.Name = "numFontSize";
            this.numFontSize.Size = new System.Drawing.Size(42, 20);
            this.numFontSize.TabIndex = 26;
            this.numFontSize.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.numFontSize.ValueChanged += new System.EventHandler(this.NumFontSizeValueChanged);
            // 
            // ckWrap
            // 
            this.ckWrap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckWrap.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckWrap.Location = new System.Drawing.Point(1019, 32);
            this.ckWrap.Name = "ckWrap";
            this.ckWrap.Size = new System.Drawing.Size(57, 24);
            this.ckWrap.TabIndex = 27;
            this.ckWrap.Text = "&Wrap";
            this.ckWrap.UseVisualStyleBackColor = true;
            this.ckWrap.CheckedChanged += new System.EventHandler(this.CkWrapCheckedChanged);
            // 
            // ckTail
            // 
            this.ckTail.Checked = true;
            this.ckTail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckTail.Location = new System.Drawing.Point(320, 32);
            this.ckTail.Name = "ckTail";
            this.ckTail.Size = new System.Drawing.Size(57, 24);
            this.ckTail.TabIndex = 13;
            this.ckTail.Text = "&Tail";
            this.tltHelp.SetToolTip(this.ckTail, "Suspend / Resume tailing\r\n\r\nBy suspending the tailing the output will be buffered" +
        "");
            this.ckTail.UseVisualStyleBackColor = true;
            this.ckTail.CheckedChanged += new System.EventHandler(this.CkTailCheckedChanged);
            // 
            // ckCase
            // 
            this.ckCase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckCase.Location = new System.Drawing.Point(692, 32);
            this.ckCase.Name = "ckCase";
            this.ckCase.Size = new System.Drawing.Size(56, 24);
            this.ckCase.TabIndex = 20;
            this.ckCase.Text = "Cas&e";
            this.ckCase.UseVisualStyleBackColor = true;
            this.ckCase.CheckedChanged += new System.EventHandler(this.ckCase_CheckedChanged);
            // 
            // timUpdateText
            // 
            this.timUpdateText.Enabled = true;
            this.timUpdateText.Interval = 2000;
            this.timUpdateText.Tick += new System.EventHandler(this.TimUpdateTextTick);
            // 
            // tltHelp
            // 
            this.tltHelp.AutomaticDelay = 2000;
            this.tltHelp.AutoPopDelay = 20000;
            this.tltHelp.InitialDelay = 2000;
            this.tltHelp.IsBalloon = true;
            this.tltHelp.ReshowDelay = 1000;
            this.tltHelp.UseAnimation = false;
            this.tltHelp.UseFading = false;
            // 
            // OutputViewerUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.panelTop);
            this.Name = "OutputViewerUserControl";
            this.Size = new System.Drawing.Size(1185, 421);
            this.Load += new System.EventHandler(this.OutputViewerUserControlLoad);
            this.ctxMenu.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).EndInit();
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.Button btnMailTo;
		private System.Windows.Forms.Button btnScrollToTop;
		private System.Windows.Forms.Button btnScrollToTail;
		private System.Windows.Forms.TextBox txtRegexGroup;
        private System.Windows.Forms.TextBox txtMessagesLen;
		private System.Windows.Forms.ContextMenuStrip ctxMenu;
		private System.Windows.Forms.CheckBox ckCase;
		private System.Windows.Forms.Button btnMark;
		private System.Windows.Forms.Button btnFilterInfo;
		private System.Windows.Forms.Button btnFilterError;
		private System.Windows.Forms.Button btnFilterWarn;
        private System.Windows.Forms.TextBox txtOutputLen;
		private System.Windows.Forms.Button btnNotepad;
		private System.Windows.Forms.Label lblFontSize;
        private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCopy;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.CheckBox ckTail;
		private System.Windows.Forms.NumericUpDown numFontSize;
		private System.Windows.Forms.CheckBox ckWrap;
        private System.Windows.Forms.Panel panelTop;
        private ScintillaNET.Scintilla txtOutput;
        private System.Windows.Forms.TextBox txtErrorCount;
        private System.Windows.Forms.ToolTip tltHelp;
        private System.Windows.Forms.CheckBox ckAutoScroll;
        private System.Windows.Forms.Button btnJsonViewerList;
        public System.Windows.Forms.Timer timUpdateText;
        private ScintillaNET.IncrementalSearcher incrementalSearcher;
        private System.Windows.Forms.ToolStripMenuItem jSONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jSONViewerListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xMLToolStripMenuItem;
	}
}
