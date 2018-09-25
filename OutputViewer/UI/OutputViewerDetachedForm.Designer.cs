namespace Itlezy.App.OutputViewer.UI
{
	partial class OutputViewerDetachedForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutputViewerDetachedForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckOnTop = new System.Windows.Forms.CheckBox();
            this.ckTaskbar = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ckOnTop);
            this.panel1.Controls.Add(this.ckTaskbar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1272, 30);
            this.panel1.TabIndex = 0;
            // 
            // ckOnTop
            // 
            this.ckOnTop.Location = new System.Drawing.Point(82, 3);
            this.ckOnTop.Name = "ckOnTop";
            this.ckOnTop.Size = new System.Drawing.Size(104, 24);
            this.ckOnTop.TabIndex = 12;
            this.ckOnTop.Text = "On To&p";
            this.ckOnTop.UseVisualStyleBackColor = true;
            this.ckOnTop.CheckedChanged += new System.EventHandler(this.CkOnTopCheckedChanged);
            // 
            // ckTaskbar
            // 
            this.ckTaskbar.Checked = true;
            this.ckTaskbar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckTaskbar.Location = new System.Drawing.Point(3, 3);
            this.ckTaskbar.Name = "ckTaskbar";
            this.ckTaskbar.Size = new System.Drawing.Size(104, 24);
            this.ckTaskbar.TabIndex = 11;
            this.ckTaskbar.Text = "Task&bar";
            this.ckTaskbar.UseVisualStyleBackColor = true;
            this.ckTaskbar.CheckedChanged += new System.EventHandler(this.CkTaskbarCheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1272, 711);
            this.panel2.TabIndex = 1;
            // 
            // OutputViewerDetachedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 741);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "OutputViewerDetachedForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OutputViewerDetachedForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.CheckBox ckOnTop;
		private System.Windows.Forms.CheckBox ckTaskbar;
		private System.Windows.Forms.Panel panel1;
	}
}
