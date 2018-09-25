namespace Itlezy.App.Network.UI
{
    partial class NetworkProbe
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetworkProbe));
            this.portScannerUserControl1 = new PortScannerUserControl();
            this.SuspendLayout();
            // 
            // portScannerUserControl1
            // 
            this.portScannerUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.portScannerUserControl1.Location = new System.Drawing.Point(0, 0);
            this.portScannerUserControl1.Name = "portScannerUserControl1";
            this.portScannerUserControl1.Size = new System.Drawing.Size(1016, 741);
            this.portScannerUserControl1.TabIndex = 0;
            // 
            // NetworkProbe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 741);
            this.Controls.Add(this.portScannerUserControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NetworkProbe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Port Scanner";
            this.ResumeLayout(false);

        }

        #endregion

        private PortScannerUserControl portScannerUserControl1;
    }
}