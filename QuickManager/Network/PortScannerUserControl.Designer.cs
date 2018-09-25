namespace Itlezy.App.Network.UI
{
    partial class PortScannerUserControl
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
            this.txtHostStart = new System.Windows.Forms.TextBox();
            this.txtPortStart = new System.Windows.Forms.TextBox();
            this.btnScan = new System.Windows.Forms.Button();
            this.lstScanResult = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timUpdateResults = new System.Windows.Forms.Timer(this.components);
            this.bkgScan = new System.ComponentModel.BackgroundWorker();
            this.txtPortEnd = new System.Windows.Forms.TextBox();
            this.grpScan = new System.Windows.Forms.GroupBox();
            this.ckOpenOnly = new System.Windows.Forms.CheckBox();
            this.tltHelp = new System.Windows.Forms.ToolTip(this.components);
            this.grpScan.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtHostStart
            // 
            this.txtHostStart.Location = new System.Drawing.Point(6, 19);
            this.txtHostStart.Name = "txtHostStart";
            this.txtHostStart.Size = new System.Drawing.Size(200, 20);
            this.txtHostStart.TabIndex = 1;
            this.tltHelp.SetToolTip(this.txtHostStart, "Hostname or IP");
            // 
            // txtPortStart
            // 
            this.txtPortStart.Location = new System.Drawing.Point(212, 19);
            this.txtPortStart.MaxLength = 5;
            this.txtPortStart.Name = "txtPortStart";
            this.txtPortStart.Size = new System.Drawing.Size(100, 20);
            this.txtPortStart.TabIndex = 2;
            this.tltHelp.SetToolTip(this.txtPortStart, "Start Port");
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(6, 45);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(75, 23);
            this.btnScan.TabIndex = 4;
            this.btnScan.Text = "Sca&n";
            this.tltHelp.SetToolTip(this.btnScan, "Scan - press ESC to cancel");
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // lstScanResult
            // 
            this.lstScanResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lstScanResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstScanResult.FullRowSelect = true;
            this.lstScanResult.GridLines = true;
            this.lstScanResult.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstScanResult.Location = new System.Drawing.Point(0, 83);
            this.lstScanResult.MultiSelect = false;
            this.lstScanResult.Name = "lstScanResult";
            this.lstScanResult.Size = new System.Drawing.Size(885, 544);
            this.lstScanResult.TabIndex = 20;
            this.lstScanResult.UseCompatibleStateImageBehavior = false;
            this.lstScanResult.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Host";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Port";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Open";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Probed";
            this.columnHeader4.Width = 80;
            // 
            // timUpdateResults
            // 
            this.timUpdateResults.Enabled = true;
            this.timUpdateResults.Interval = 3000;
            this.timUpdateResults.Tick += new System.EventHandler(this.timUpdateResults_Tick);
            // 
            // bkgScan
            // 
            this.bkgScan.WorkerReportsProgress = true;
            this.bkgScan.WorkerSupportsCancellation = true;
            this.bkgScan.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkgScan_DoWork);
            this.bkgScan.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bkgScan_RunWorkerCompleted);
            // 
            // txtPortEnd
            // 
            this.txtPortEnd.Location = new System.Drawing.Point(318, 19);
            this.txtPortEnd.MaxLength = 5;
            this.txtPortEnd.Name = "txtPortEnd";
            this.txtPortEnd.Size = new System.Drawing.Size(100, 20);
            this.txtPortEnd.TabIndex = 3;
            this.tltHelp.SetToolTip(this.txtPortEnd, "End Port (optional)");
            // 
            // grpScan
            // 
            this.grpScan.Controls.Add(this.ckOpenOnly);
            this.grpScan.Controls.Add(this.txtHostStart);
            this.grpScan.Controls.Add(this.txtPortEnd);
            this.grpScan.Controls.Add(this.btnScan);
            this.grpScan.Controls.Add(this.txtPortStart);
            this.grpScan.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpScan.Location = new System.Drawing.Point(0, 0);
            this.grpScan.Name = "grpScan";
            this.grpScan.Size = new System.Drawing.Size(885, 83);
            this.grpScan.TabIndex = 5;
            this.grpScan.TabStop = false;
            this.grpScan.Text = "Scan";
            // 
            // ckOpenOnly
            // 
            this.ckOpenOnly.AutoSize = true;
            this.ckOpenOnly.Location = new System.Drawing.Point(212, 45);
            this.ckOpenOnly.Name = "ckOpenOnly";
            this.ckOpenOnly.Size = new System.Drawing.Size(117, 17);
            this.ckOpenOnly.TabIndex = 5;
            this.ckOpenOnly.Text = "List open ports onl&y";
            this.ckOpenOnly.UseVisualStyleBackColor = true;
            this.ckOpenOnly.CheckedChanged += new System.EventHandler(this.ckOpenOnly_CheckedChanged);
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
            // PortScannerUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstScanResult);
            this.Controls.Add(this.grpScan);
            this.Name = "PortScannerUserControl";
            this.Size = new System.Drawing.Size(885, 627);
            this.Load += new System.EventHandler(this.PortScannerUserControl_Load);
            this.grpScan.ResumeLayout(false);
            this.grpScan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtHostStart;
        private System.Windows.Forms.TextBox txtPortStart;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.ListView lstScanResult;
        private System.Windows.Forms.Timer timUpdateResults;
        private System.ComponentModel.BackgroundWorker bkgScan;
        private System.Windows.Forms.TextBox txtPortEnd;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox grpScan;
        private System.Windows.Forms.ToolTip tltHelp;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.CheckBox ckOpenOnly;
    }
}
