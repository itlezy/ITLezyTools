namespace Itlezy.App.QuickManager.ScratchPad.UI
{
	partial class ScratchPadForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScratchPadForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlslblEditorInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toCodeStringWithCRLFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toCodeStringWithLFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toCodeStringOneLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toCodeStringSingleQuoteWithCRLFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toCodeStringSingleQuoteWithLFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toCodeStringSingleQuoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.trimLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trimEndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trimLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trimBothToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toBase64ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromBase64ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toURLEncodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromURLEncodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toHTMLEscapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromHTMLEscapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.hTMLAttributeEncodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.javaScriptStringEncodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlcmbEncoding = new System.Windows.Forms.ToolStripComboBox();
            this.tlsOnTop = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstClipboardHistory = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.timCheckClipboard = new System.Windows.Forms.Timer(this.components);
            this.tltHelp = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlslblEditorInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 719);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1016, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tlslblEditorInfo
            // 
            this.tlslblEditorInfo.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlslblEditorInfo.Name = "tlslblEditorInfo";
            this.tlslblEditorInfo.Size = new System.Drawing.Size(98, 17);
            this.tlslblEditorInfo.Text = "<Editor Info>";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.clearHistoryToolStripMenuItem,
            this.clearTextToolStripMenuItem,
            this.formatToolStripMenuItem,
            this.utilToolStripMenuItem,
            this.tlcmbEncoding,
            this.tlsOnTop});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1016, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTabToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 21);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newTabToolStripMenuItem
            // 
            this.newTabToolStripMenuItem.Name = "newTabToolStripMenuItem";
            this.newTabToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.newTabToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.newTabToolStripMenuItem.Text = "New &Tab";
            this.newTabToolStripMenuItem.Click += new System.EventHandler(this.NewTabToolStripMenuItemClick);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
            // 
            // clearHistoryToolStripMenuItem
            // 
            this.clearHistoryToolStripMenuItem.Name = "clearHistoryToolStripMenuItem";
            this.clearHistoryToolStripMenuItem.Size = new System.Drawing.Size(81, 21);
            this.clearHistoryToolStripMenuItem.Text = "Clear &History";
            this.clearHistoryToolStripMenuItem.ToolTipText = "Clear the ClipBoard history";
            this.clearHistoryToolStripMenuItem.Click += new System.EventHandler(this.ClearHistoryToolStripMenuItemClick);
            // 
            // clearTextToolStripMenuItem
            // 
            this.clearTextToolStripMenuItem.Name = "clearTextToolStripMenuItem";
            this.clearTextToolStripMenuItem.Size = new System.Drawing.Size(69, 21);
            this.clearTextToolStripMenuItem.Text = "Clear Te&xt";
            this.clearTextToolStripMenuItem.ToolTipText = "Clear current Editor content";
            this.clearTextToolStripMenuItem.Click += new System.EventHandler(this.ClearTextToolStripMenuItemClick);
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xMLToolStripMenuItem,
            this.jSONToolStripMenuItem,
            this.toolStripSeparator4,
            this.toCodeStringWithCRLFToolStripMenuItem,
            this.toCodeStringWithLFToolStripMenuItem,
            this.toCodeStringOneLineToolStripMenuItem,
            this.toolStripSeparator5,
            this.toCodeStringSingleQuoteWithCRLFToolStripMenuItem,
            this.toCodeStringSingleQuoteWithLFToolStripMenuItem,
            this.toCodeStringSingleQuoteToolStripMenuItem,
            this.toolStripSeparator6,
            this.trimLinesToolStripMenuItem});
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(53, 21);
            this.formatToolStripMenuItem.Text = "Format";
            // 
            // xMLToolStripMenuItem
            // 
            this.xMLToolStripMenuItem.Name = "xMLToolStripMenuItem";
            this.xMLToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.xMLToolStripMenuItem.Text = "XML";
            this.xMLToolStripMenuItem.Click += new System.EventHandler(this.XMLToolStripMenuItemClick);
            // 
            // jSONToolStripMenuItem
            // 
            this.jSONToolStripMenuItem.Name = "jSONToolStripMenuItem";
            this.jSONToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.jSONToolStripMenuItem.Text = "JSON";
            this.jSONToolStripMenuItem.Click += new System.EventHandler(this.jSONToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(257, 6);
            // 
            // toCodeStringWithCRLFToolStripMenuItem
            // 
            this.toCodeStringWithCRLFToolStripMenuItem.Name = "toCodeStringWithCRLFToolStripMenuItem";
            this.toCodeStringWithCRLFToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.toCodeStringWithCRLFToolStripMenuItem.Text = "To Code String with CRLF";
            this.toCodeStringWithCRLFToolStripMenuItem.Click += new System.EventHandler(this.ToCodeStringWithCRLFToolStripMenuItemClick);
            // 
            // toCodeStringWithLFToolStripMenuItem
            // 
            this.toCodeStringWithLFToolStripMenuItem.Name = "toCodeStringWithLFToolStripMenuItem";
            this.toCodeStringWithLFToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.toCodeStringWithLFToolStripMenuItem.Text = "To Code String with LF";
            this.toCodeStringWithLFToolStripMenuItem.Click += new System.EventHandler(this.ToCodeStringWithLFToolStripMenuItemClick);
            // 
            // toCodeStringOneLineToolStripMenuItem
            // 
            this.toCodeStringOneLineToolStripMenuItem.Name = "toCodeStringOneLineToolStripMenuItem";
            this.toCodeStringOneLineToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.toCodeStringOneLineToolStripMenuItem.Text = "To Code String";
            this.toCodeStringOneLineToolStripMenuItem.Click += new System.EventHandler(this.ToCodeStringOneLineToolStripMenuItemClick);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(257, 6);
            // 
            // toCodeStringSingleQuoteWithCRLFToolStripMenuItem
            // 
            this.toCodeStringSingleQuoteWithCRLFToolStripMenuItem.Name = "toCodeStringSingleQuoteWithCRLFToolStripMenuItem";
            this.toCodeStringSingleQuoteWithCRLFToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.toCodeStringSingleQuoteWithCRLFToolStripMenuItem.Text = "To Code String Single Quote with CRLF";
            this.toCodeStringSingleQuoteWithCRLFToolStripMenuItem.Click += new System.EventHandler(this.toCodeStringSingleQuoteWithCRLFToolStripMenuItem_Click);
            // 
            // toCodeStringSingleQuoteWithLFToolStripMenuItem
            // 
            this.toCodeStringSingleQuoteWithLFToolStripMenuItem.Name = "toCodeStringSingleQuoteWithLFToolStripMenuItem";
            this.toCodeStringSingleQuoteWithLFToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.toCodeStringSingleQuoteWithLFToolStripMenuItem.Text = "To Code String Single Quote with LF";
            this.toCodeStringSingleQuoteWithLFToolStripMenuItem.Click += new System.EventHandler(this.toCodeStringSingleQuoteWithLFToolStripMenuItem_Click);
            // 
            // toCodeStringSingleQuoteToolStripMenuItem
            // 
            this.toCodeStringSingleQuoteToolStripMenuItem.Name = "toCodeStringSingleQuoteToolStripMenuItem";
            this.toCodeStringSingleQuoteToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.toCodeStringSingleQuoteToolStripMenuItem.Text = "To Code String Single Quote";
            this.toCodeStringSingleQuoteToolStripMenuItem.Click += new System.EventHandler(this.toCodeStringSingleQuoteToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(257, 6);
            // 
            // trimLinesToolStripMenuItem
            // 
            this.trimLinesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trimEndToolStripMenuItem,
            this.trimLeftToolStripMenuItem,
            this.trimBothToolStripMenuItem});
            this.trimLinesToolStripMenuItem.Name = "trimLinesToolStripMenuItem";
            this.trimLinesToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.trimLinesToolStripMenuItem.Text = "Trim Lines";
            // 
            // trimEndToolStripMenuItem
            // 
            this.trimEndToolStripMenuItem.Name = "trimEndToolStripMenuItem";
            this.trimEndToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.trimEndToolStripMenuItem.Text = "Trim Right";
            this.trimEndToolStripMenuItem.Click += new System.EventHandler(this.TrimEndToolStripMenuItemClick);
            // 
            // trimLeftToolStripMenuItem
            // 
            this.trimLeftToolStripMenuItem.Name = "trimLeftToolStripMenuItem";
            this.trimLeftToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.trimLeftToolStripMenuItem.Text = "Trim Left";
            this.trimLeftToolStripMenuItem.Click += new System.EventHandler(this.TrimLeftToolStripMenuItemClick);
            // 
            // trimBothToolStripMenuItem
            // 
            this.trimBothToolStripMenuItem.Name = "trimBothToolStripMenuItem";
            this.trimBothToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.trimBothToolStripMenuItem.Text = "Trim Both";
            this.trimBothToolStripMenuItem.Click += new System.EventHandler(this.TrimBothToolStripMenuItemClick);
            // 
            // utilToolStripMenuItem
            // 
            this.utilToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toBase64ToolStripMenuItem,
            this.fromBase64ToolStripMenuItem,
            this.toolStripSeparator1,
            this.toURLEncodeToolStripMenuItem,
            this.fromURLEncodeToolStripMenuItem,
            this.toolStripSeparator2,
            this.toHTMLEscapeToolStripMenuItem,
            this.fromHTMLEscapeToolStripMenuItem,
            this.toolStripSeparator3,
            this.hTMLAttributeEncodeToolStripMenuItem,
            this.javaScriptStringEncodeToolStripMenuItem});
            this.utilToolStripMenuItem.Name = "utilToolStripMenuItem";
            this.utilToolStripMenuItem.Size = new System.Drawing.Size(54, 21);
            this.utilToolStripMenuItem.Text = "&Encode";
            // 
            // toBase64ToolStripMenuItem
            // 
            this.toBase64ToolStripMenuItem.Name = "toBase64ToolStripMenuItem";
            this.toBase64ToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.toBase64ToolStripMenuItem.Text = "To &Base64";
            this.toBase64ToolStripMenuItem.Click += new System.EventHandler(this.ToBase64ToolStripMenuItemClick);
            // 
            // fromBase64ToolStripMenuItem
            // 
            this.fromBase64ToolStripMenuItem.Name = "fromBase64ToolStripMenuItem";
            this.fromBase64ToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.fromBase64ToolStripMenuItem.Text = "From B&ase64";
            this.fromBase64ToolStripMenuItem.Click += new System.EventHandler(this.FromBase64ToolStripMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(190, 6);
            // 
            // toURLEncodeToolStripMenuItem
            // 
            this.toURLEncodeToolStripMenuItem.Name = "toURLEncodeToolStripMenuItem";
            this.toURLEncodeToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.toURLEncodeToolStripMenuItem.Text = "To &URL Encode";
            this.toURLEncodeToolStripMenuItem.Click += new System.EventHandler(this.ToURLEncodeToolStripMenuItemClick);
            // 
            // fromURLEncodeToolStripMenuItem
            // 
            this.fromURLEncodeToolStripMenuItem.Name = "fromURLEncodeToolStripMenuItem";
            this.fromURLEncodeToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.fromURLEncodeToolStripMenuItem.Text = "From U&RL Encode";
            this.fromURLEncodeToolStripMenuItem.Click += new System.EventHandler(this.FromURLEncodeToolStripMenuItemClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(190, 6);
            // 
            // toHTMLEscapeToolStripMenuItem
            // 
            this.toHTMLEscapeToolStripMenuItem.Name = "toHTMLEscapeToolStripMenuItem";
            this.toHTMLEscapeToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.toHTMLEscapeToolStripMenuItem.Text = "To &HTML Encode";
            this.toHTMLEscapeToolStripMenuItem.Click += new System.EventHandler(this.ToHTMLEscapeToolStripMenuItemClick);
            // 
            // fromHTMLEscapeToolStripMenuItem
            // 
            this.fromHTMLEscapeToolStripMenuItem.Name = "fromHTMLEscapeToolStripMenuItem";
            this.fromHTMLEscapeToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.fromHTMLEscapeToolStripMenuItem.Text = "From H&TML Encode";
            this.fromHTMLEscapeToolStripMenuItem.Click += new System.EventHandler(this.FromHTMLEscapeToolStripMenuItemClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(190, 6);
            // 
            // hTMLAttributeEncodeToolStripMenuItem
            // 
            this.hTMLAttributeEncodeToolStripMenuItem.Name = "hTMLAttributeEncodeToolStripMenuItem";
            this.hTMLAttributeEncodeToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.hTMLAttributeEncodeToolStripMenuItem.Text = "HT&ML Attribute Encode";
            this.hTMLAttributeEncodeToolStripMenuItem.Click += new System.EventHandler(this.HTMLAttributeEncodeToolStripMenuItemClick);
            // 
            // javaScriptStringEncodeToolStripMenuItem
            // 
            this.javaScriptStringEncodeToolStripMenuItem.Name = "javaScriptStringEncodeToolStripMenuItem";
            this.javaScriptStringEncodeToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.javaScriptStringEncodeToolStripMenuItem.Text = "&JavaScript String Encode";
            this.javaScriptStringEncodeToolStripMenuItem.Click += new System.EventHandler(this.JavaScriptStringEncodeToolStripMenuItemClick);
            // 
            // tlcmbEncoding
            // 
            this.tlcmbEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tlcmbEncoding.Items.AddRange(new object[] {
            "ASCII",
            "Windows-1251",
            "Windows-1252",
            "UTF-8",
            "UTF-16"});
            this.tlcmbEncoding.Name = "tlcmbEncoding";
            this.tlcmbEncoding.Size = new System.Drawing.Size(121, 21);
            // 
            // tlsOnTop
            // 
            this.tlsOnTop.CheckOnClick = true;
            this.tlsOnTop.Name = "tlsOnTop";
            this.tlsOnTop.Size = new System.Drawing.Size(54, 21);
            this.tlsOnTop.Text = "On To&p";
            this.tlsOnTop.CheckedChanged += new System.EventHandler(this.TlsOnTopCheckedChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstClipboardHistory);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1016, 694);
            this.splitContainer1.SplitterDistance = 337;
            this.splitContainer1.TabIndex = 2;
            // 
            // lstClipboardHistory
            // 
            this.lstClipboardHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstClipboardHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstClipboardHistory.FormattingEnabled = true;
            this.lstClipboardHistory.ItemHeight = 15;
            this.lstClipboardHistory.Location = new System.Drawing.Point(0, 0);
            this.lstClipboardHistory.Name = "lstClipboardHistory";
            this.lstClipboardHistory.Size = new System.Drawing.Size(337, 694);
            this.lstClipboardHistory.TabIndex = 0;
            this.tltHelp.SetToolTip(this.lstClipboardHistory, "DoubleClick to append to current Editor\r\nRightClick to copy to Clipboard");
            this.lstClipboardHistory.DoubleClick += new System.EventHandler(this.LstClipboardHistoryDoubleClick);
            this.lstClipboardHistory.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstClipboardHistory_MouseDown);
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(675, 694);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1SelectedIndexChanged);
            // 
            // timCheckClipboard
            // 
            this.timCheckClipboard.Enabled = true;
            this.timCheckClipboard.Interval = 12000;
            this.timCheckClipboard.Tick += new System.EventHandler(this.TimCheckClipboardTick);
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
            // ScratchPadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 741);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScratchPadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scratch Pad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScratchPadFormFormClosing);
            this.Load += new System.EventHandler(this.ScratchPadFormLoad);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.ToolStripMenuItem tlsOnTop;
		private System.Windows.Forms.ToolStripMenuItem trimBothToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem trimLeftToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem trimEndToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem trimLinesToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel tlslblEditorInfo;
		private System.Windows.Forms.ToolStripMenuItem toCodeStringOneLineToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toCodeStringWithLFToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toCodeStringWithCRLFToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem xMLToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem formatToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem javaScriptStringEncodeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hTMLAttributeEncodeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fromHTMLEscapeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toHTMLEscapeToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem fromURLEncodeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toURLEncodeToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripComboBox tlcmbEncoding;
		private System.Windows.Forms.ToolStripMenuItem fromBase64ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toBase64ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem utilToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newTabToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.ToolStripMenuItem clearTextToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clearHistoryToolStripMenuItem;
		private System.Windows.Forms.ListBox lstClipboardHistory;
		private System.Windows.Forms.Timer timCheckClipboard;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem toCodeStringSingleQuoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toCodeStringSingleQuoteWithCRLFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toCodeStringSingleQuoteWithLFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jSONToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolTip tltHelp;
	}
}
