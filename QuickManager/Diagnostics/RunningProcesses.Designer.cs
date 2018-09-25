namespace Itlezy.App.QuickManager.Diagnostics.UI
{
	partial class RunningProcesses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RunningProcesses));
            this.lstProcesses = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckOnTop = new System.Windows.Forms.CheckBox();
            this.ckTaskbar = new System.Windows.Forms.CheckBox();
            this.btnPrompt = new System.Windows.Forms.Button();
            this.btnLocate = new System.Windows.Forms.Button();
            this.btnKill = new System.Windows.Forms.Button();
            this.btnCopySelected = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tltHelp = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstProcesses
            // 
            this.lstProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader4,
            this.columnHeader6});
            this.lstProcesses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstProcesses.FullRowSelect = true;
            this.lstProcesses.GridLines = true;
            this.lstProcesses.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstProcesses.HideSelection = false;
            this.lstProcesses.Location = new System.Drawing.Point(0, 0);
            this.lstProcesses.MultiSelect = false;
            this.lstProcesses.Name = "lstProcesses";
            this.lstProcesses.Size = new System.Drawing.Size(1016, 711);
            this.lstProcesses.TabIndex = 20;
            this.tltHelp.SetToolTip(this.lstProcesses, "Keyboard Shortcuts\r\nK : Kill Process\r\nF5 : Refresh\r\nF9 : Command Prompt\r\nF10 : Ex" +
        "plorer\r\n\r\nPress ALT for more");
            this.lstProcesses.UseCompatibleStateImageBehavior = false;
            this.lstProcesses.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "PID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Executable";
            this.columnHeader2.Width = 130;
            // 
            // columnHeader3
            // 
            this.columnHeader3.DisplayIndex = 3;
            this.columnHeader3.Text = "ImagePath";
            this.columnHeader3.Width = 250;
            // 
            // columnHeader5
            // 
            this.columnHeader5.DisplayIndex = 4;
            this.columnHeader5.Text = "Working Directory";
            this.columnHeader5.Width = 250;
            // 
            // columnHeader4
            // 
            this.columnHeader4.DisplayIndex = 5;
            this.columnHeader4.Text = "Command Line";
            this.columnHeader4.Width = 800;
            // 
            // columnHeader6
            // 
            this.columnHeader6.DisplayIndex = 2;
            this.columnHeader6.Text = "Type";
            this.columnHeader6.Width = 110;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(3, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefreshClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ckOnTop);
            this.panel1.Controls.Add(this.ckTaskbar);
            this.panel1.Controls.Add(this.btnPrompt);
            this.panel1.Controls.Add(this.btnLocate);
            this.panel1.Controls.Add(this.btnKill);
            this.panel1.Controls.Add(this.btnCopySelected);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 30);
            this.panel1.TabIndex = 2;
            // 
            // ckOnTop
            // 
            this.ckOnTop.Location = new System.Drawing.Point(657, 3);
            this.ckOnTop.Name = "ckOnTop";
            this.ckOnTop.Size = new System.Drawing.Size(104, 24);
            this.ckOnTop.TabIndex = 7;
            this.ckOnTop.Text = "On To&p";
            this.ckOnTop.UseVisualStyleBackColor = true;
            this.ckOnTop.CheckedChanged += new System.EventHandler(this.CkOnTopCheckedChanged);
            // 
            // ckTaskbar
            // 
            this.ckTaskbar.Checked = true;
            this.ckTaskbar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckTaskbar.Location = new System.Drawing.Point(584, 3);
            this.ckTaskbar.Name = "ckTaskbar";
            this.ckTaskbar.Size = new System.Drawing.Size(66, 24);
            this.ckTaskbar.TabIndex = 6;
            this.ckTaskbar.Text = "Task&bar";
            this.ckTaskbar.UseVisualStyleBackColor = true;
            this.ckTaskbar.CheckedChanged += new System.EventHandler(this.CkTaskbarCheckedChanged);
            // 
            // btnPrompt
            // 
            this.btnPrompt.Image = ((System.Drawing.Image)(resources.GetObject("btnPrompt.Image")));
            this.btnPrompt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrompt.Location = new System.Drawing.Point(467, 3);
            this.btnPrompt.Name = "btnPrompt";
            this.btnPrompt.Size = new System.Drawing.Size(110, 23);
            this.btnPrompt.TabIndex = 5;
            this.btnPrompt.Text = "&Prompt";
            this.btnPrompt.UseVisualStyleBackColor = true;
            this.btnPrompt.Click += new System.EventHandler(this.BtnPromptClick);
            // 
            // btnLocate
            // 
            this.btnLocate.Image = ((System.Drawing.Image)(resources.GetObject("btnLocate.Image")));
            this.btnLocate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLocate.Location = new System.Drawing.Point(351, 3);
            this.btnLocate.Name = "btnLocate";
            this.btnLocate.Size = new System.Drawing.Size(110, 23);
            this.btnLocate.TabIndex = 4;
            this.btnLocate.Text = "&Locate";
            this.tltHelp.SetToolTip(this.btnLocate, "Launch Explorer targeting the selected file");
            this.btnLocate.UseVisualStyleBackColor = true;
            this.btnLocate.Click += new System.EventHandler(this.BtnLocateClick);
            // 
            // btnKill
            // 
            this.btnKill.Image = ((System.Drawing.Image)(resources.GetObject("btnKill.Image")));
            this.btnKill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKill.Location = new System.Drawing.Point(235, 3);
            this.btnKill.Name = "btnKill";
            this.btnKill.Size = new System.Drawing.Size(110, 23);
            this.btnKill.TabIndex = 3;
            this.btnKill.Text = "&Kill";
            this.btnKill.UseVisualStyleBackColor = true;
            this.btnKill.Click += new System.EventHandler(this.BtnKillClick);
            // 
            // btnCopySelected
            // 
            this.btnCopySelected.Image = ((System.Drawing.Image)(resources.GetObject("btnCopySelected.Image")));
            this.btnCopySelected.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopySelected.Location = new System.Drawing.Point(119, 3);
            this.btnCopySelected.Name = "btnCopySelected";
            this.btnCopySelected.Size = new System.Drawing.Size(110, 23);
            this.btnCopySelected.TabIndex = 2;
            this.btnCopySelected.Text = "&Copy";
            this.btnCopySelected.UseVisualStyleBackColor = true;
            this.btnCopySelected.Click += new System.EventHandler(this.BtnCopySelectedClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lstProcesses);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1016, 711);
            this.panel2.TabIndex = 3;
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
            // RunningProcesses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 741);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "RunningProcesses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Processes";
            this.Activated += new System.EventHandler(this.RunningProcessesActivated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RunningProcessesFormClosing);
            this.Load += new System.EventHandler(this.RunningProcesses_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.CheckBox ckOnTop;
		private System.Windows.Forms.CheckBox ckTaskbar;
		private System.Windows.Forms.Button btnPrompt;
		private System.Windows.Forms.Button btnLocate;
		private System.Windows.Forms.Button btnKill;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.Button btnCopySelected;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ListView lstProcesses;
        private System.Windows.Forms.ToolTip tltHelp;
	
	}
}
