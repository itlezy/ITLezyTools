/*
 * Created by SharpDevelop.
 * Date: 3/5/2014
 * Time: 8:40 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ScreenLocker
{
	partial class LockScreenForm
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
            this.timOnTop = new System.Windows.Forms.Timer(this.components);
            this.lblInput = new System.Windows.Forms.Label();
            this.lblMouseMove = new System.Windows.Forms.Label();
            this.timDelay = new System.Windows.Forms.Timer(this.components);
            this.timChangeColor = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timOnTop
            // 
            this.timOnTop.Enabled = true;
            this.timOnTop.Interval = 3000;
            this.timOnTop.Tick += new System.EventHandler(this.TimOnTopTick);
            // 
            // lblInput
            // 
            this.lblInput.Font = new System.Drawing.Font("Consolas", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInput.ForeColor = System.Drawing.Color.Lime;
            this.lblInput.Location = new System.Drawing.Point(87, 155);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(250, 80);
            this.lblInput.TabIndex = 0;
            this.lblInput.Visible = false;
            // 
            // lblMouseMove
            // 
            this.lblMouseMove.Font = new System.Drawing.Font("Consolas", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMouseMove.ForeColor = System.Drawing.Color.Lime;
            this.lblMouseMove.Location = new System.Drawing.Point(87, 62);
            this.lblMouseMove.Name = "lblMouseMove";
            this.lblMouseMove.Size = new System.Drawing.Size(250, 80);
            this.lblMouseMove.TabIndex = 1;
            this.lblMouseMove.Visible = false;
            // 
            // timDelay
            // 
            this.timDelay.Interval = 6000;
            this.timDelay.Tick += new System.EventHandler(this.timDelay_Tick);
            // 
            // timChangeColor
            // 
            this.timChangeColor.Enabled = true;
            this.timChangeColor.Interval = 30000;
            this.timChangeColor.Tick += new System.EventHandler(this.timChangeColor_Tick);
            // 
            // LockScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1253, 570);
            this.ControlBox = false;
            this.Controls.Add(this.lblMouseMove);
            this.Controls.Add(this.lblInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LockScreenForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ScreenLocker";
            this.TopMost = true;
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainFormMouseMove);
            this.ResumeLayout(false);

        }
		private System.Windows.Forms.Label lblMouseMove;
		private System.Windows.Forms.Label lblInput;
		private System.Windows.Forms.Timer timOnTop;
        private System.Windows.Forms.Timer timDelay;
        private System.Windows.Forms.Timer timChangeColor;
	}
}
