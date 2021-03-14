using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;
using System.Collections.Concurrent;
using System.Net.NetworkInformation;
using System.Configuration;

namespace LezyNetworkMeter
{
    public partial class MainForm : Form
    {
        static String adapterName = ConfigurationManager.AppSettings["adapterName"];
        static String performanceCounterName = ConfigurationManager.AppSettings["performanceCounterName"];

        PerformanceCounter bandwidthCounterSent = new PerformanceCounter("Network Interface", "Bytes Sent/sec", performanceCounterName, true);
        PerformanceCounter bandwidthCounterReceived = new PerformanceCounter("Network Interface", "Bytes Received/sec", performanceCounterName, true);

        IList<String> bandwidthCounterX = new List<String>();

        IList<int> bandwidthCounterRecordsTotal = new List<int>();
        IList<int> bandwidthCounterRecordsSent = new List<int>();
        IList<int> bandwidthCounterRecordsReceived = new List<int>();

        int lastBndTotal = 0;
        int lastBndSent = 0;
        int lastBndReceived = 0;

        int maxBndTotal = 0;
        int maxBndSent = 0;
        int maxBndReceived = 0;

        Series seriesTotal = new Series("bndTotal");
        Series seriesSent = new Series("bndSent");
        Series seriesReceived = new Series("bndReceived");

        IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
        NetworkInterface adapter;

        bool resetStats = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            seriesTotal.ChartType = SeriesChartType.SplineArea;
            seriesTotal.ToolTip = "Total #VALY kb/s";

            seriesSent.ChartType = SeriesChartType.SplineArea;
            seriesSent.ToolTip = "Sent #VALY kb/s";

            seriesReceived.ChartType = SeriesChartType.SplineArea;
            seriesReceived.ToolTip = "Received #VALY kb/s";

            bandwChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            bandwChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            bandwChart.Series.Add(seriesTotal);
            bandwChart.Series.Add(seriesReceived);
            bandwChart.Series.Add(seriesSent);

            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface nic in nics)
            {
                IPInterfaceProperties properties = nic.GetIPProperties();
                if (nic.Description == adapterName)
                {
                    adapter = nic;
                }

            }

            try
            {
                // dirty way to ensure we have the right adapter and perf counter name
                adapter.ToString();
                bandwidthCounterSent.NextValue();
            }
            catch
            {
                ShowConfigInfoAndExit();
                return;
            }

            timerUpdate.Enabled = true;

            Thread thread = new Thread(new ParameterizedThreadStart(ReadPerformanceCounter));
            thread.IsBackground = true;
            thread.Start(new Object());

            UpdateTitleAndLabels();
        }

        void ShowConfigInfoAndExit()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Network Interfaces, set to 'adapterName'");
            sb.AppendLine();

            foreach (NetworkInterface nic in nics)
            {
                IPInterfaceProperties properties = nic.GetIPProperties();
                sb.AppendLine(nic.Description);
            }

            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("Performance Counters, set to 'performanceCounterName'");

            PerformanceCounterCategory category = new PerformanceCounterCategory("Network Interface");
            String[] instancename = category.GetInstanceNames();

            foreach (string name in instancename)
            {
                sb.AppendLine(name);
            }

            MessageBox.Show(sb.ToString(), "Adapter List - Press CTRL-C to copy");
            Application.Exit();
        }

        void ReadPerformanceCounter(Object lio)
        {
            while (true)
            {
                lastBndSent = (int)Math.Round(bandwidthCounterSent.NextValue() / 1024);
                lastBndReceived = (int)Math.Round(bandwidthCounterReceived.NextValue() / 1024);

                lastBndTotal = lastBndSent + lastBndReceived;

                if (lastBndSent > maxBndSent) maxBndSent = lastBndSent;
                if (lastBndReceived > maxBndReceived) maxBndReceived = lastBndReceived;
                if (lastBndTotal > maxBndTotal) maxBndTotal = lastBndTotal;

                Thread.Sleep(timerUpdate.Interval / 3);
            }
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            if (resetStats || bandwidthCounterX.Count > 50)
            {
                resetStats = false;

                bandwidthCounterRecordsTotal.Clear();
                bandwidthCounterRecordsSent.Clear();
                bandwidthCounterRecordsReceived.Clear();
                bandwidthCounterX.Clear();
            }

            bandwidthCounterRecordsTotal.Add(lastBndTotal);
            bandwidthCounterRecordsSent.Add(lastBndSent);
            bandwidthCounterRecordsReceived.Add(lastBndReceived);

            bandwidthCounterX.Add(DateTime.Now.ToString("HH:mm:ss"));

            seriesTotal.Points.DataBindXY(
                bandwidthCounterX,
                bandwidthCounterRecordsTotal);

            seriesSent.Points.DataBindXY(
                bandwidthCounterX,
                bandwidthCounterRecordsSent);

            seriesReceived.Points.DataBindXY(
                bandwidthCounterX,
                bandwidthCounterRecordsReceived);

            UpdateTitleAndLabels();
        }

        private void UpdateTitleAndLabels()
        {
            this.Text = String.Format("{0} kb/s {1}Mb @ {2}",
                lastBndTotal,
                adapter.GetIPv4Statistics().BytesReceived / 1024 / 1024,
                adapterName);

            lblMaxReceived.Text = String.Format("Max Received {0,8} kb/s", maxBndReceived);
            lblMaxSent.Text = String.Format("Max Sent {0,12} kb/s", maxBndSent);
            lblMaxTotal.Text = String.Format("Max Total {0,11} kb/s", maxBndTotal);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.R:
                    resetStats = true;
                    break;

                case Keys.Q:
                case Keys.X:
                    Application.Exit();
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
