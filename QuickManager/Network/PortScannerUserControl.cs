using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Itlezy.App.Network.UI
{
    public partial class PortScannerUserControl : UserControl
    {
        private PortScannerTarget[] itemsToScan;
        private readonly ParallelOptions parallelOptions = new ParallelOptions();
        private readonly CancellationTokenSource cancellationToken = new CancellationTokenSource();
        private readonly ScanPort scanPort = new ScanPort();

        public PortScannerUserControl()
        {
            InitializeComponent();

            parallelOptions.CancellationToken = cancellationToken.Token;
            parallelOptions.MaxDegreeOfParallelism = System.Environment.ProcessorCount * 8;
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            txtHostStart.BackColor = SystemColors.Window;
            txtPortStart.BackColor = SystemColors.Window;
            txtPortEnd.BackColor = SystemColors.Window;

            if (!Regex.IsMatch(txtPortStart.Text, "^\\d{1,5}$"))
            {
                txtPortStart.BackColor = Color.LightCoral;
                return;
            }

            if (String.IsNullOrWhiteSpace(txtHostStart.Text))
            {
                txtHostStart.BackColor = Color.LightCoral;
                return;
            }

            int startPort = int.Parse(txtPortStart.Text);
            int endPort = startPort;

            if (!String.IsNullOrWhiteSpace(txtPortEnd.Text))
            {
                if (Regex.IsMatch(txtPortEnd.Text, "^\\d{1,5}$"))
                {
                    endPort = int.Parse(txtPortEnd.Text);
                }
                else
                {
                    txtPortEnd.BackColor = Color.LightCoral;
                }

                if (endPort < startPort)
                {
                    endPort = startPort;
                }
            }

            if (startPort <= 0 || startPort >= 65536)
            {
                txtPortStart.BackColor = Color.LightCoral;
                return;
            }

            if (endPort <= 0 || endPort >= 65536)
            {
                txtPortEnd.BackColor = Color.LightCoral;
                return;
            }

            itemsToScan = new PortScannerTarget[endPort - startPort + 1];

            for (int port = startPort, i = 0; port <= endPort; port++, i++)
            {
                itemsToScan[i] = new PortScannerTarget()
                {
                    Host = txtHostStart.Text,
                    Port = port
                };
            }

            timUpdateResults.Start();
            bkgScan.RunWorkerAsync();
        }

        private void timUpdateResults_Tick(object sender, EventArgs e)
        {
            UpdateResults();
        }

        private void UpdateResults()
        {
            lstScanResult.Items.Clear();

            if (itemsToScan != null && itemsToScan.Length > 0)
            {
                var itemsToAdd = ckOpenOnly.Checked ? itemsToScan.Where(p => p.Open).ToArray() : itemsToScan;

                ListViewItem[] listViewItems = new ListViewItem[itemsToAdd.Length];

                for (int i = 0; i < itemsToAdd.Length; i++)
                {
                    var p = itemsToAdd[i];

                    ListViewItem li = new ListViewItem(p.Host);
                    li.SubItems.Add(p.Port.ToString());
                    li.SubItems.Add(p.Open.ToString());
                    li.SubItems.Add(p.Probed.ToString());

                    if (p.Probed)
                    {
                        if (p.Open)
                        {
                            li.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            li.BackColor = Color.LightCoral;
                        }
                    }

                    listViewItems[i] = li;
                }


                lstScanResult.Items.AddRange(listViewItems);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                cancellationToken.Cancel();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void bkgScan_DoWork(object sender, DoWorkEventArgs e)
        {
            UpdateResults();

            grpScan.Enabled = false;            

            try
            {
                Parallel.ForEach(itemsToScan, parallelOptions, o =>
                {
                    scanPort.Scan(o);
                    parallelOptions.CancellationToken.ThrowIfCancellationRequested();
                });
            }
            catch (OperationCanceledException)
            {
                // no action
            }
        }

        private void bkgScan_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            grpScan.Enabled = true;

            timUpdateResults.Stop();

            UpdateResults();
        }

        private void PortScannerUserControl_Load(object sender, EventArgs e)
        {
            txtHostStart.Select();
        }

        private void ckOpenOnly_CheckedChanged(object sender, EventArgs e)
        {
            UpdateResults();
        }
    }
}
