using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;

namespace BatteryMeter
{
    public partial class BatteryMeterMainForm : Form
    {
        PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        PerformanceCounter bandwidthCounter = new PerformanceCounter("Network Interface", "Bytes Total/sec", ConfigurationManager.AppSettings["network"]);
        PerformanceCounter diskCounter = new PerformanceCounter("LogicalDisk", "Disk Bytes/sec", "_Total");

        ComputerInfo computerInfo = new ComputerInfo();

        public BatteryMeterMainForm()
        {
            InitializeComponent();
        }

        void UpdateBatteryStatus()
        {
            txtBatteryStatus.Select(0, 0);
            HideCaret(txtBatteryStatus.Handle);

            var info = new StringBuilder();
            var width = 10;

            var scale = 0.0;
            if (!Double.TryParse(ConfigurationManager.AppSettings["scale"], out scale))
            {
                scale = 1.3;
            }

            if (ConfigurationManager.AppSettings["battery"] != null)
            {
                info.Append(
                    SystemInformation.PowerStatus.BatteryLifeRemaining / 60 + "m " +
                    SystemInformation.PowerStatus.BatteryLifePercent * 100 + "%");

                width += (int)(90 * scale);
            }

            if (ConfigurationManager.AppSettings["memory"] != null)
            {
                info.Append(" m:" +
                    ((computerInfo.TotalPhysicalMemory - computerInfo.AvailablePhysicalMemory) / 1024 / 1024) + "Mb");

                width += (int)(80 * scale);
            }

            if (ConfigurationManager.AppSettings["cpu"] != null)
            {
                info.Append(" c:" +
                    Math.Round(cpuCounter.NextValue()).ToString().PadLeft(3) + "%");

                width += (int)(40 * scale);
            }

            if (ConfigurationManager.AppSettings["disk"] != null)
            {
                info.Append(" d:" +
                    Math.Round(diskCounter.NextValue() / 1024 / 1024).ToString().PadLeft(3) + "Mb/s");

                width += (int)(40 * scale);
            }

            if (ConfigurationManager.AppSettings["network"] != null)
            {
                info.Append(" b:" +
                    Math.Round(bandwidthCounter.NextValue() / 1024).ToString().PadLeft(4) + "kb/s");

                width += (int)(90 * scale);
            }

            if (ConfigurationManager.AppSettings["date"] != null)
            {
                info.Append(" " +
                    DateTime.Today.ToString(ConfigurationManager.AppSettings["date"]));

                width += (int)(80 * scale);
            }

            txtBatteryStatus.Text = info.ToString().Trim();

            txtBatteryStatus.Select(0, 0);
            HideCaret(txtBatteryStatus.Handle);

            if (this.Width != width) { this.Width = width; }
        }

        private void timUpdateBatteryStatus_Tick(object sender, EventArgs e)
        {
            UpdateBatteryStatus();
        }

        private void InitializeFormSize()
        {
            var wa = Screen.PrimaryScreen.WorkingArea;
            this.Left = wa.Width - 880;
            this.Top = wa.Height - this.Height;

            this.Width = 10;

            this.TopMost = false;
            this.TopMost = true;
        }

        private void BatteryMeterMainForm_Load(object sender, EventArgs e)
        {
            InitializeFormSize();
            UpdateBatteryStatus();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                    this.Top = this.Top- 30;
                    break;

                case Keys.Down:
                    this.Top = this.Top + 30;
                    break;

                case Keys.Left:
                    this.Left = this.Left - 30;
                    break;

                case Keys.Right:
                    this.Left = this.Left + 30;
                    break;

                case Keys.R:
                    InitializeFormSize();
                    UpdateBatteryStatus();
                    break;

                case Keys.C:
                    Clipboard.SetText(txtBatteryStatus.Text);
                    break;

                case Keys.Q:
                case Keys.X:
                    Application.Exit();
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32")]
        private static extern bool HideCaret(IntPtr hWnd);

        void HandleMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
