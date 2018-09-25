namespace Itlezy.App.QuickManager.UI
{
	partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lstEvents = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstEventsMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.explorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.netConnectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portScannerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton4 = new System.Windows.Forms.ToolStripDropDownButton();
            this.shutdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rebootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconcontextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInPrimaryScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lnkHelp = new System.Windows.Forms.LinkLabel();
            this.ckProcInfo = new System.Windows.Forms.CheckBox();
            this.btnScintilla = new System.Windows.Forms.Button();
            this.btnScratchPad = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.ckTaskbar = new System.Windows.Forms.CheckBox();
            this.btnJsonViewer = new System.Windows.Forms.Button();
            this.txtSelectedItem = new System.Windows.Forms.TextBox();
            this.btnProcesses = new System.Windows.Forms.Button();
            this.btnOutput = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.pnlUrlButtons = new System.Windows.Forms.Panel();
            this.btnLaunch_ch = new System.Windows.Forms.Button();
            this.btnLaunch_ff = new System.Windows.Forms.Button();
            this.btnLaunch_ie = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnToTray = new System.Windows.Forms.Button();
            this.numInterval = new System.Windows.Forms.NumericUpDown();
            this.trkOpacity = new System.Windows.Forms.TrackBar();
            this.btnExit = new System.Windows.Forms.Button();
            this.ckOnTop = new System.Windows.Forms.CheckBox();
            this.lblInterval = new System.Windows.Forms.Label();
            this.timUpdateUI = new System.Windows.Forms.Timer(this.components);
            this.tltHelp = new System.Windows.Forms.ToolTip(this.components);
            this.prpProcessInfo = new System.Windows.Forms.PropertyGrid();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstEventsMenuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.notifyIconcontextMenuStrip.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlUrlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstEvents
            // 
            this.lstEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5});
            this.lstEvents.ContextMenuStrip = this.lstEventsMenuStrip;
            this.lstEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstEvents.FullRowSelect = true;
            this.lstEvents.GridLines = true;
            this.lstEvents.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstEvents.HideSelection = false;
            this.lstEvents.Location = new System.Drawing.Point(0, 0);
            this.lstEvents.Name = "lstEvents";
            this.lstEvents.Size = new System.Drawing.Size(776, 331);
            this.lstEvents.TabIndex = 20;
            this.lstEvents.UseCompatibleStateImageBehavior = false;
            this.lstEvents.View = System.Windows.Forms.View.Details;
            this.lstEvents.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.LstEventsItemSelectionChanged);
            this.lstEvents.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LstEventsMouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Item";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Status";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "URL";
            this.columnHeader4.Width = 600;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Working Directory";
            this.columnHeader5.Width = 500;
            // 
            // lstEventsMenuStrip
            // 
            this.lstEventsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurationToolStripMenuItem});
            this.lstEventsMenuStrip.Name = "lstEventsMenuStrip";
            this.lstEventsMenuStrip.Size = new System.Drawing.Size(140, 26);
            this.lstEventsMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.lstEventsMenuStrip_Opening);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.configurationToolStripMenuItem.Text = "Confi&guration";
            this.configurationToolStripMenuItem.DropDownOpening += new System.EventHandler(this.configurationToolStripMenuItem_DropDownOpening);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton3,
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton4});
            this.statusStrip.Location = new System.Drawing.Point(0, 411);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1074, 22);
            this.statusStrip.TabIndex = 90;
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.ShowDropDownArrow = false;
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(67, 20);
            this.toolStripDropDownButton2.Text = "Te&rminal";
            this.toolStripDropDownButton2.Click += new System.EventHandler(this.toolStripDropDownButton2_Click);
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadToolStripMenuItem,
            this.editToolStripMenuItem,
            this.explorerToolStripMenuItem,
            this.programFolderToolStripMenuItem});
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(85, 20);
            this.toolStripDropDownButton3.Text = "Confi&guration";
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.reloadToolStripMenuItem.Text = "&Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // explorerToolStripMenuItem
            // 
            this.explorerToolStripMenuItem.Name = "explorerToolStripMenuItem";
            this.explorerToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.explorerToolStripMenuItem.Text = "Find in &Explorer";
            this.explorerToolStripMenuItem.Click += new System.EventHandler(this.explorerToolStripMenuItem_Click);
            // 
            // programFolderToolStripMenuItem
            // 
            this.programFolderToolStripMenuItem.Name = "programFolderToolStripMenuItem";
            this.programFolderToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.programFolderToolStripMenuItem.Text = "Program &Folder";
            this.programFolderToolStripMenuItem.Click += new System.EventHandler(this.programFolderToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.netConnectionsToolStripMenuItem,
            this.portScannerToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(60, 20);
            this.toolStripDropDownButton1.Text = "Net&work";
            // 
            // netConnectionsToolStripMenuItem
            // 
            this.netConnectionsToolStripMenuItem.Name = "netConnectionsToolStripMenuItem";
            this.netConnectionsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.netConnectionsToolStripMenuItem.Text = "&Net Connections";
            this.netConnectionsToolStripMenuItem.Click += new System.EventHandler(this.NetConnectionsToolStripMenuItemClick);
            // 
            // portScannerToolStripMenuItem
            // 
            this.portScannerToolStripMenuItem.Name = "portScannerToolStripMenuItem";
            this.portScannerToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.portScannerToolStripMenuItem.Text = "&Port Scanner";
            this.portScannerToolStripMenuItem.Click += new System.EventHandler(this.portScannerToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton4
            // 
            this.toolStripDropDownButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shutdownToolStripMenuItem,
            this.rebootToolStripMenuItem,
            this.logoffToolStripMenuItem});
            this.toolStripDropDownButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton4.Image")));
            this.toolStripDropDownButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton4.Name = "toolStripDropDownButton4";
            this.toolStripDropDownButton4.Size = new System.Drawing.Size(55, 20);
            this.toolStripDropDownButton4.Text = "S&ystem";
            // 
            // shutdownToolStripMenuItem
            // 
            this.shutdownToolStripMenuItem.Name = "shutdownToolStripMenuItem";
            this.shutdownToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.shutdownToolStripMenuItem.Text = "&Shutdown";
            this.shutdownToolStripMenuItem.Click += new System.EventHandler(this.ShutdownToolStripMenuItemClick);
            // 
            // rebootToolStripMenuItem
            // 
            this.rebootToolStripMenuItem.Name = "rebootToolStripMenuItem";
            this.rebootToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.rebootToolStripMenuItem.Text = "&Reboot";
            this.rebootToolStripMenuItem.Click += new System.EventHandler(this.RebootToolStripMenuItemClick);
            // 
            // logoffToolStripMenuItem
            // 
            this.logoffToolStripMenuItem.Name = "logoffToolStripMenuItem";
            this.logoffToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.logoffToolStripMenuItem.Text = "&Logoff";
            this.logoffToolStripMenuItem.Click += new System.EventHandler(this.LogoffToolStripMenuItemClick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipTitle = "QuickManager";
            this.notifyIcon.ContextMenuStrip = this.notifyIconcontextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "QuickManager";
            this.notifyIcon.Visible = true;
            this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.NotifyIcon1BalloonTipClicked);
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1MouseClick);
            this.notifyIcon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1MouseMove);
            // 
            // notifyIconcontextMenuStrip
            // 
            this.notifyIconcontextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.showInPrimaryScreenToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.notifyIconcontextMenuStrip.Name = "contextMenuStrip1";
            this.notifyIconcontextMenuStrip.Size = new System.Drawing.Size(186, 70);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.showToolStripMenuItem.Text = "Sho&w";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // showInPrimaryScreenToolStripMenuItem
            // 
            this.showInPrimaryScreenToolStripMenuItem.Name = "showInPrimaryScreenToolStripMenuItem";
            this.showInPrimaryScreenToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.showInPrimaryScreenToolStripMenuItem.Text = "Show in primar&y screen";
            this.showInPrimaryScreenToolStripMenuItem.Click += new System.EventHandler(this.showInPrimaryScreenToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lnkHelp);
            this.pnlTop.Controls.Add(this.ckProcInfo);
            this.pnlTop.Controls.Add(this.btnScintilla);
            this.pnlTop.Controls.Add(this.btnScratchPad);
            this.pnlTop.Controls.Add(this.btnRestart);
            this.pnlTop.Controls.Add(this.ckTaskbar);
            this.pnlTop.Controls.Add(this.btnJsonViewer);
            this.pnlTop.Controls.Add(this.txtSelectedItem);
            this.pnlTop.Controls.Add(this.btnProcesses);
            this.pnlTop.Controls.Add(this.btnOutput);
            this.pnlTop.Controls.Add(this.btnStop);
            this.pnlTop.Controls.Add(this.pnlUrlButtons);
            this.pnlTop.Controls.Add(this.btnStart);
            this.pnlTop.Controls.Add(this.btnToTray);
            this.pnlTop.Controls.Add(this.numInterval);
            this.pnlTop.Controls.Add(this.trkOpacity);
            this.pnlTop.Controls.Add(this.btnExit);
            this.pnlTop.Controls.Add(this.ckOnTop);
            this.pnlTop.Controls.Add(this.lblInterval);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1074, 80);
            this.pnlTop.TabIndex = 2;
            // 
            // lnkHelp
            // 
            this.lnkHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkHelp.AutoSize = true;
            this.lnkHelp.Location = new System.Drawing.Point(952, 54);
            this.lnkHelp.Name = "lnkHelp";
            this.lnkHelp.Size = new System.Drawing.Size(13, 13);
            this.lnkHelp.TabIndex = 54;
            this.lnkHelp.TabStop = true;
            this.lnkHelp.Text = "?";
            this.tltHelp.SetToolTip(this.lnkHelp, resources.GetString("lnkHelp.ToolTip"));
            // 
            // ckProcInfo
            // 
            this.ckProcInfo.Location = new System.Drawing.Point(765, 14);
            this.ckProcInfo.Name = "ckProcInfo";
            this.ckProcInfo.Size = new System.Drawing.Size(95, 22);
            this.ckProcInfo.TabIndex = 42;
            this.ckProcInfo.Text = "Proc&. Info";
            this.ckProcInfo.UseVisualStyleBackColor = true;
            this.ckProcInfo.CheckedChanged += new System.EventHandler(this.ckProcInfo_CheckedChanged);
            // 
            // btnScintilla
            // 
            this.btnScintilla.Image = ((System.Drawing.Image)(resources.GetObject("btnScintilla.Image")));
            this.btnScintilla.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScintilla.Location = new System.Drawing.Point(668, 45);
            this.btnScintilla.Name = "btnScintilla";
            this.btnScintilla.Size = new System.Drawing.Size(80, 30);
            this.btnScintilla.TabIndex = 15;
            this.btnScintilla.Text = "Sc&ide";
            this.tltHelp.SetToolTip(this.btnScintilla, "ScidE Text Editor");
            this.btnScintilla.UseVisualStyleBackColor = true;
            this.btnScintilla.Click += new System.EventHandler(this.btnScintilla_Click);
            // 
            // btnScratchPad
            // 
            this.btnScratchPad.Image = ((System.Drawing.Image)(resources.GetObject("btnScratchPad.Image")));
            this.btnScratchPad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScratchPad.Location = new System.Drawing.Point(582, 45);
            this.btnScratchPad.Name = "btnScratchPad";
            this.btnScratchPad.Size = new System.Drawing.Size(80, 30);
            this.btnScratchPad.TabIndex = 13;
            this.btnScratchPad.Text = "Pa&d";
            this.tltHelp.SetToolTip(this.btnScratchPad, "Scratch Pad");
            this.btnScratchPad.UseVisualStyleBackColor = true;
            this.btnScratchPad.Click += new System.EventHandler(this.BtnScratchPadClick);
            // 
            // btnRestart
            // 
            this.btnRestart.Image = ((System.Drawing.Image)(resources.GetObject("btnRestart.Image")));
            this.btnRestart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRestart.Location = new System.Drawing.Point(218, 45);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(100, 30);
            this.btnRestart.TabIndex = 6;
            this.btnRestart.Text = "F4 &Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.BtnRestartClick);
            // 
            // ckTaskbar
            // 
            this.ckTaskbar.Location = new System.Drawing.Point(622, 14);
            this.ckTaskbar.Name = "ckTaskbar";
            this.ckTaskbar.Size = new System.Drawing.Size(69, 22);
            this.ckTaskbar.TabIndex = 40;
            this.ckTaskbar.Text = "Task&bar";
            this.ckTaskbar.UseVisualStyleBackColor = true;
            this.ckTaskbar.CheckedChanged += new System.EventHandler(this.CkTaskbarCheckedChanged);
            // 
            // btnJsonViewer
            // 
            this.btnJsonViewer.Image = ((System.Drawing.Image)(resources.GetObject("btnJsonViewer.Image")));
            this.btnJsonViewer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJsonViewer.Location = new System.Drawing.Point(410, 45);
            this.btnJsonViewer.Name = "btnJsonViewer";
            this.btnJsonViewer.Size = new System.Drawing.Size(80, 30);
            this.btnJsonViewer.TabIndex = 10;
            this.btnJsonViewer.Text = "&JSON";
            this.tltHelp.SetToolTip(this.btnJsonViewer, "Launch the JSON Viewer");
            this.btnJsonViewer.UseVisualStyleBackColor = true;
            this.btnJsonViewer.Click += new System.EventHandler(this.BtnJsonViewerClick);
            // 
            // txtSelectedItem
            // 
            this.txtSelectedItem.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtSelectedItem.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSelectedItem.Location = new System.Drawing.Point(324, 12);
            this.txtSelectedItem.Name = "txtSelectedItem";
            this.txtSelectedItem.ReadOnly = true;
            this.txtSelectedItem.Size = new System.Drawing.Size(206, 25);
            this.txtSelectedItem.TabIndex = 7;
            // 
            // btnProcesses
            // 
            this.btnProcesses.Image = ((System.Drawing.Image)(resources.GetObject("btnProcesses.Image")));
            this.btnProcesses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcesses.Location = new System.Drawing.Point(496, 45);
            this.btnProcesses.Name = "btnProcesses";
            this.btnProcesses.Size = new System.Drawing.Size(80, 30);
            this.btnProcesses.TabIndex = 12;
            this.btnProcesses.Text = "Proc&s";
            this.tltHelp.SetToolTip(this.btnProcesses, "Running Processes");
            this.btnProcesses.UseVisualStyleBackColor = true;
            this.btnProcesses.Click += new System.EventHandler(this.BtnProcessesClick);
            // 
            // btnOutput
            // 
            this.btnOutput.Image = ((System.Drawing.Image)(resources.GetObject("btnOutput.Image")));
            this.btnOutput.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOutput.Location = new System.Drawing.Point(324, 45);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(80, 30);
            this.btnOutput.TabIndex = 9;
            this.btnOutput.Text = "O&utput";
            this.tltHelp.SetToolTip(this.btnOutput, "Show the Log Viewer");
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.BtnOutputClick);
            // 
            // btnStop
            // 
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStop.Location = new System.Drawing.Point(112, 45);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 30);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "F3 Sto&p";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStopClick);
            // 
            // pnlUrlButtons
            // 
            this.pnlUrlButtons.Controls.Add(this.btnLaunch_ch);
            this.pnlUrlButtons.Controls.Add(this.btnLaunch_ff);
            this.pnlUrlButtons.Controls.Add(this.btnLaunch_ie);
            this.pnlUrlButtons.Location = new System.Drawing.Point(3, 5);
            this.pnlUrlButtons.Name = "pnlUrlButtons";
            this.pnlUrlButtons.Size = new System.Drawing.Size(318, 39);
            this.pnlUrlButtons.TabIndex = 11;
            // 
            // btnLaunch_ch
            // 
            this.btnLaunch_ch.Image = ((System.Drawing.Image)(resources.GetObject("btnLaunch_ch.Image")));
            this.btnLaunch_ch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLaunch_ch.Location = new System.Drawing.Point(3, 4);
            this.btnLaunch_ch.Name = "btnLaunch_ch";
            this.btnLaunch_ch.Size = new System.Drawing.Size(100, 30);
            this.btnLaunch_ch.TabIndex = 1;
            this.btnLaunch_ch.Text = "C&hrome";
            this.btnLaunch_ch.UseVisualStyleBackColor = true;
            this.btnLaunch_ch.Click += new System.EventHandler(this.BtnLaunchBrowserClick);
            // 
            // btnLaunch_ff
            // 
            this.btnLaunch_ff.Image = ((System.Drawing.Image)(resources.GetObject("btnLaunch_ff.Image")));
            this.btnLaunch_ff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLaunch_ff.Location = new System.Drawing.Point(109, 4);
            this.btnLaunch_ff.Name = "btnLaunch_ff";
            this.btnLaunch_ff.Size = new System.Drawing.Size(100, 30);
            this.btnLaunch_ff.TabIndex = 2;
            this.btnLaunch_ff.Text = "Fire&fox";
            this.btnLaunch_ff.UseVisualStyleBackColor = true;
            this.btnLaunch_ff.Click += new System.EventHandler(this.BtnLaunchBrowserClick);
            // 
            // btnLaunch_ie
            // 
            this.btnLaunch_ie.Image = ((System.Drawing.Image)(resources.GetObject("btnLaunch_ie.Image")));
            this.btnLaunch_ie.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLaunch_ie.Location = new System.Drawing.Point(215, 4);
            this.btnLaunch_ie.Name = "btnLaunch_ie";
            this.btnLaunch_ie.Size = new System.Drawing.Size(100, 30);
            this.btnLaunch_ie.TabIndex = 3;
            this.btnLaunch_ie.Text = "Exp&lorer";
            this.btnLaunch_ie.UseVisualStyleBackColor = true;
            this.btnLaunch_ie.Click += new System.EventHandler(this.BtnLaunchBrowserClick);
            // 
            // btnStart
            // 
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStart.Location = new System.Drawing.Point(6, 45);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 30);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "F2 &Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStartClick);
            // 
            // btnToTray
            // 
            this.btnToTray.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToTray.Image = ((System.Drawing.Image)(resources.GetObject("btnToTray.Image")));
            this.btnToTray.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnToTray.Location = new System.Drawing.Point(971, 45);
            this.btnToTray.Name = "btnToTray";
            this.btnToTray.Size = new System.Drawing.Size(100, 30);
            this.btnToTray.TabIndex = 53;
            this.btnToTray.Text = "Tra&y";
            this.tltHelp.SetToolTip(this.btnToTray, "Minimize to Tray");
            this.btnToTray.UseVisualStyleBackColor = true;
            this.btnToTray.Click += new System.EventHandler(this.BtnToTrayClick);
            // 
            // numInterval
            // 
            this.numInterval.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numInterval.Location = new System.Drawing.Point(536, 16);
            this.numInterval.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.numInterval.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numInterval.Name = "numInterval";
            this.numInterval.Size = new System.Drawing.Size(80, 20);
            this.numInterval.TabIndex = 8;
            this.numInterval.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numInterval.ValueChanged += new System.EventHandler(this.NumIntervalValueChanged);
            // 
            // trkOpacity
            // 
            this.trkOpacity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trkOpacity.Location = new System.Drawing.Point(865, 3);
            this.trkOpacity.Maximum = 100;
            this.trkOpacity.Minimum = 10;
            this.trkOpacity.Name = "trkOpacity";
            this.trkOpacity.Size = new System.Drawing.Size(100, 42);
            this.trkOpacity.TabIndex = 50;
            this.trkOpacity.TickFrequency = 5;
            this.trkOpacity.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tltHelp.SetToolTip(this.trkOpacity, "Window Transparency");
            this.trkOpacity.Value = 100;
            this.trkOpacity.Scroll += new System.EventHandler(this.TrkOpacityScroll);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(971, 9);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 30);
            this.btnExit.TabIndex = 51;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExitClick);
            // 
            // ckOnTop
            // 
            this.ckOnTop.Location = new System.Drawing.Point(697, 14);
            this.ckOnTop.Name = "ckOnTop";
            this.ckOnTop.Size = new System.Drawing.Size(69, 22);
            this.ckOnTop.TabIndex = 41;
            this.ckOnTop.Text = "O&n Top";
            this.ckOnTop.UseVisualStyleBackColor = true;
            this.ckOnTop.CheckedChanged += new System.EventHandler(this.CkOnTopCheckedChanged);
            // 
            // lblInterval
            // 
            this.lblInterval.Location = new System.Drawing.Point(534, 2);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(100, 21);
            this.lblInterval.TabIndex = 7;
            this.lblInterval.Text = "Refresh Inter&val";
            // 
            // timUpdateUI
            // 
            this.timUpdateUI.Enabled = true;
            this.timUpdateUI.Interval = 1600;
            this.timUpdateUI.Tick += new System.EventHandler(this.TimUpdateUITick);
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
            // prpProcessInfo
            // 
            this.prpProcessInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prpProcessInfo.Location = new System.Drawing.Point(0, 0);
            this.prpProcessInfo.Name = "prpProcessInfo";
            this.prpProcessInfo.Size = new System.Drawing.Size(294, 331);
            this.prpProcessInfo.TabIndex = 40;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 80);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstEvents);
            this.splitContainer1.Panel1MinSize = 500;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.prpProcessInfo);
            this.splitContainer1.Panel2MinSize = 100;
            this.splitContainer1.Size = new System.Drawing.Size(1074, 331);
            this.splitContainer1.SplitterDistance = 776;
            this.splitContainer1.TabIndex = 18;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 433);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1082, 350);
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuickManager";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.lstEventsMenuStrip.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.notifyIconcontextMenuStrip.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlUrlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkOpacity)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        private System.Windows.Forms.Button btnScratchPad;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
		private System.Windows.Forms.Button btnRestart;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip notifyIconcontextMenuStrip;
        private System.Windows.Forms.Button btnJsonViewer;
		private System.Windows.Forms.Timer timUpdateUI;
		private System.Windows.Forms.CheckBox ckTaskbar;
		private System.Windows.Forms.TextBox txtSelectedItem;
		private System.Windows.Forms.Label lblInterval;
		private System.Windows.Forms.Button btnProcesses;
		private System.Windows.Forms.Button btnOutput;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Panel pnlUrlButtons;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Button btnToTray;
		private System.Windows.Forms.NumericUpDown numInterval;
		private System.Windows.Forms.TrackBar trkOpacity;
		private System.Windows.Forms.Button btnLaunch_ch;
		private System.Windows.Forms.Button btnLaunch_ff;
		private System.Windows.Forms.Button btnLaunch_ie;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.CheckBox ckOnTop;
		private System.Windows.Forms.Panel pnlTop;
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView lstEvents;
        private System.Windows.Forms.Button btnScintilla;
        private System.Windows.Forms.ToolTip tltHelp;
        private System.Windows.Forms.PropertyGrid prpProcessInfo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox ckProcInfo;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem netConnectionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portScannerToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton4;
        private System.Windows.Forms.ToolStripMenuItem shutdownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rebootToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem explorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programFolderToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip lstEventsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showInPrimaryScreenToolStripMenuItem;
        private System.Windows.Forms.LinkLabel lnkHelp;
		
	}
}
