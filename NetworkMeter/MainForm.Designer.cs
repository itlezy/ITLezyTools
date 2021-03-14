namespace LezyNetworkMeter
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.bandwChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblMaxReceived = new System.Windows.Forms.Label();
            this.lblMaxSent = new System.Windows.Forms.Label();
            this.lblMaxTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bandwChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bandwChart
            // 
            chartArea1.Name = "ChartArea1";
            this.bandwChart.ChartAreas.Add(chartArea1);
            this.bandwChart.Cursor = System.Windows.Forms.Cursors.Cross;
            this.bandwChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bandwChart.Location = new System.Drawing.Point(0, 0);
            this.bandwChart.Name = "bandwChart";
            this.bandwChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.bandwChart.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Navy,
        System.Drawing.Color.RoyalBlue,
        System.Drawing.Color.DodgerBlue};
            this.bandwChart.Size = new System.Drawing.Size(728, 240);
            this.bandwChart.TabIndex = 0;
            this.bandwChart.Text = "bandwChart";
            // 
            // timerUpdate
            // 
            this.timerUpdate.Interval = 2100;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.bandwChart);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblMaxReceived);
            this.splitContainer1.Panel2.Controls.Add(this.lblMaxSent);
            this.splitContainer1.Panel2.Controls.Add(this.lblMaxTotal);
            this.splitContainer1.Size = new System.Drawing.Size(728, 310);
            this.splitContainer1.SplitterDistance = 240;
            this.splitContainer1.TabIndex = 1;
            // 
            // lblMaxReceived
            // 
            this.lblMaxReceived.AutoSize = true;
            this.lblMaxReceived.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxReceived.Location = new System.Drawing.Point(12, 25);
            this.lblMaxReceived.Name = "lblMaxReceived";
            this.lblMaxReceived.Size = new System.Drawing.Size(28, 15);
            this.lblMaxReceived.TabIndex = 2;
            this.lblMaxReceived.Text = "Max";
            // 
            // lblMaxSent
            // 
            this.lblMaxSent.AutoSize = true;
            this.lblMaxSent.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxSent.Location = new System.Drawing.Point(12, 8);
            this.lblMaxSent.Name = "lblMaxSent";
            this.lblMaxSent.Size = new System.Drawing.Size(28, 15);
            this.lblMaxSent.TabIndex = 1;
            this.lblMaxSent.Text = "Max";
            // 
            // lblMaxTotal
            // 
            this.lblMaxTotal.AutoSize = true;
            this.lblMaxTotal.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxTotal.Location = new System.Drawing.Point(12, 42);
            this.lblMaxTotal.Name = "lblMaxTotal";
            this.lblMaxTotal.Size = new System.Drawing.Size(28, 15);
            this.lblMaxTotal.TabIndex = 0;
            this.lblMaxTotal.Text = "Max";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 310);
            this.Controls.Add(this.splitContainer1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Meter";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bandwChart)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart bandwChart;
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblMaxTotal;
        private System.Windows.Forms.Label lblMaxReceived;
        private System.Windows.Forms.Label lblMaxSent;
    }
}

