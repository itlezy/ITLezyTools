namespace Itlezy.App.OutputViewer.UI
{
	partial class OutputViewerMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutputViewerMainForm));
            this.tabContainer = new System.Windows.Forms.TabControl();
            this.ckOnTop = new System.Windows.Forms.CheckBox();
            this.ckTaskbar = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnDetach = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.tltHelp = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabContainer
            // 
            this.tabContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabContainer.Location = new System.Drawing.Point(0, 30);
            this.tabContainer.Name = "tabContainer";
            this.tabContainer.SelectedIndex = 0;
            this.tabContainer.Size = new System.Drawing.Size(1016, 493);
            this.tabContainer.TabIndex = 20;
            this.tabContainer.SelectedIndexChanged += new System.EventHandler(this.TabContainerSelectedIndexChanged);
            // 
            // ckOnTop
            // 
            this.ckOnTop.Location = new System.Drawing.Point(464, 4);
            this.ckOnTop.Name = "ckOnTop";
            this.ckOnTop.Size = new System.Drawing.Size(104, 24);
            this.ckOnTop.TabIndex = 6;
            this.ckOnTop.Text = "On To&p";
            this.ckOnTop.UseVisualStyleBackColor = true;
            this.ckOnTop.CheckedChanged += new System.EventHandler(this.CkOnTopCheckedChanged);
            // 
            // ckTaskbar
            // 
            this.ckTaskbar.Checked = true;
            this.ckTaskbar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckTaskbar.Location = new System.Drawing.Point(389, 4);
            this.ckTaskbar.Name = "ckTaskbar";
            this.ckTaskbar.Size = new System.Drawing.Size(69, 24);
            this.ckTaskbar.TabIndex = 5;
            this.ckTaskbar.Text = "Task&bar";
            this.ckTaskbar.UseVisualStyleBackColor = true;
            this.ckTaskbar.CheckedChanged += new System.EventHandler(this.CkTaskbarCheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClearAll);
            this.panel1.Controls.Add(this.btnDetach);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.ckOnTop);
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Controls.Add(this.ckTaskbar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 30);
            this.panel1.TabIndex = 1;
            // 
            // btnClearAll
            // 
            this.btnClearAll.Image = ((System.Drawing.Image)(resources.GetObject("btnClearAll.Image")));
            this.btnClearAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearAll.Location = new System.Drawing.Point(293, 4);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(90, 23);
            this.btnClearAll.TabIndex = 4;
            this.btnClearAll.Text = "Clear &All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.BtnClearAllClick);
            // 
            // btnDetach
            // 
            this.btnDetach.Image = ((System.Drawing.Image)(resources.GetObject("btnDetach.Image")));
            this.btnDetach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetach.Location = new System.Drawing.Point(197, 4);
            this.btnDetach.Name = "btnDetach";
            this.btnDetach.Size = new System.Drawing.Size(90, 23);
            this.btnDetach.TabIndex = 3;
            this.btnDetach.Text = "&Detach";
            this.tltHelp.SetToolTip(this.btnDetach, "Detach the current Tab and open it in a new Window.\r\nTo re-attach the Window back" +
        " to be a Tab, just close it.");
            this.btnDetach.UseVisualStyleBackColor = true;
            this.btnDetach.Click += new System.EventHandler(this.BtnDetachClick);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(101, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
            // 
            // btnOpen
            // 
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpen.Location = new System.Drawing.Point(5, 4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(90, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "&Open";
            this.tltHelp.SetToolTip(this.btnOpen, "Open a log file to tail");
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.BtnOpenClick);
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
            // OutputViewerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 523);
            this.Controls.Add(this.tabContainer);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1024, 400);
            this.Name = "OutputViewerMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OV";
            this.Activated += new System.EventHandler(this.OutputViewer_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OutputViewerFormClosing);
            this.Load += new System.EventHandler(this.OutputViewerLoad);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.Button btnClearAll;
		private System.Windows.Forms.Button btnDetach;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.CheckBox ckTaskbar;
		private System.Windows.Forms.CheckBox ckOnTop;
		private System.Windows.Forms.TabControl tabContainer;
        private System.Windows.Forms.ToolTip tltHelp;
	}
}
