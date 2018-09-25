using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Itlezy.App.OutputViewer.UI;
using Itlezy.Common.Diagnostics;
using Itlezy.Common.Platform;

namespace Itlezy.App.Console.UI
{
    public partial class ConsoleUserControl : UserControl
    {
        private readonly ProcessStopper processStopper = new ProcessStopper();

        private Process process;
        private bool isProcessRunning;

        public ConsoleUserControl()
        {
            InitializeComponent();
        }

        private void sciCommand_MarginClick(object sender, ScintillaNET.MarginClickEventArgs e)
        {
            RunCommand(e.Line.Text);
        }

        private void RunCommand(String command)
        {
            if (IsProcessActive || String.IsNullOrWhiteSpace(command))
            {
                return;
            }

            String tempCommand = Path.GetTempFileName() + ".QuickManager.cmd";
            File.WriteAllText(tempCommand, command);

            ProcessStartInfo pi = new ProcessStartInfo();
            pi.FileName = tempCommand;
            pi.CreateNoWindow = true;
            pi.RedirectStandardOutput = true;
            pi.RedirectStandardError = true;
            pi.RedirectStandardInput = true;
            pi.UseShellExecute = false;
            pi.StandardOutputEncoding = Encoding.Default;
            pi.StandardErrorEncoding = Encoding.Default;

            if (cmbWorkingDirectory.SelectedItem != null &&
                IsValidDirectory(cmbWorkingDirectory.SelectedItem.ToString()))
            {
                pi.WorkingDirectory = cmbWorkingDirectory.SelectedItem.ToString();
            }
            else
            {
                pi.WorkingDirectory = Environment.GetEnvironmentVariable("USERPROFILE");
            }

            process = new Process();
            process.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            process.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);
            process.Exited += new EventHandler(p_Exited);
            process.EnableRaisingEvents = true;

            process.StartInfo = pi;

            process.Start();

            // >> running
            isProcessRunning = true;
            btnKill.Enabled = true;
            sciCommand.BackColor = Color.LightGreen;
            // << running

            outputViewer.AppendMsg(
                ">>>> Started  PID " + process.Id +
                " - Working Directory [" + pi.WorkingDirectory + "] >>>>" + Environment.NewLine,
                OutputKind.STDOUT);

            process.BeginErrorReadLine();
            process.BeginOutputReadLine();

            outputViewer.Resume();
        }

        void p_Exited(object sender, EventArgs e)
        {
            if (!AppContext.ContainerExiting(new ContainerControl[] {this, outputViewer }))
            {
                isProcessRunning = false;
                btnKill.Enabled = false;
                sciCommand.BackColor = SystemColors.Window;

                outputViewer.AppendMsg("<<<< Exited PID " + process.Id + " - Exit Code " + process.ExitCode + " <<<<", OutputKind.STDOUT);
            }
        }

        void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!AppContext.ContainerExiting(new ContainerControl[] { this, outputViewer }))
            {
                outputViewer.AppendMsg(e.Data, OutputKind.STDERR);
            }
        }

        void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!AppContext.ContainerExiting(new ContainerControl[] { this, outputViewer }))
            {
                outputViewer.AppendMsg(e.Data, OutputKind.STDOUT);
            }
        }

        private void sciCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                if (e.Shift)
                {
                    RunCommand(sciCommand.Text);
                }
                else
                {
                    if (sciCommand.Selection.Length > 0)
                    {
                        RunCommand(sciCommand.Selection.Text);
                    }
                    else
                    {
                        RunCommand(sciCommand.Lines[sciCommand.Caret.LineNumber].Text);
                    }
                }
            }
        }

        private void ConsoleUserControl_Load(object sender, EventArgs e)
        {
            sciCommand.Font = new Font(sciCommand.Font.Name, 12);
            sciCommand.Styles.LineNumber.Font = new Font(sciCommand.Font.Name, 12);

            //sciCommand.ConfigurationManager.Language = "batch";
            //sciCommand.ConfigurationManager.Configure();

            sciCommand.Select();
        }

        public ScintillaNET.Scintilla CommandEditor
        {
            get { return this.sciCommand; }
        }

        public OutputViewerUserControl OutputViewer
        {
            get
            {
                return this.outputViewer;
            }
        }

        private bool IsProcessActive
        {
            get
            {
                return process != null && isProcessRunning && !process.HasExited;
            }
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            if (IsProcessActive)
            {
                processStopper.KillProcessTree(process);
                // should be handled by the exit event anyway
                isProcessRunning = false;
                sciCommand.BackColor = SystemColors.Window;
            }

            btnKill.Enabled = false;
        }

        private void ckVerticalSplit_CheckedChanged(object sender, EventArgs e)
        {
            splitContainer1.Orientation = ckVerticalSplit.Checked ? Orientation.Vertical : Orientation.Horizontal;

            if (ckVerticalSplit.Checked &&
                splitContainer1.SplitterDistance < 300)
            {
                splitContainer1.SplitterDistance = 300;
            }
        }

        private bool IsValidDirectory(String dir)
        {
            return (!String.IsNullOrWhiteSpace(dir) && Directory.Exists(dir));
        }

        private void txtWorkingDirectory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (IsValidDirectory(txtWorkingDirectory.Text))
                {
                    cmbWorkingDirectory.Items.Insert(0, txtWorkingDirectory.Text);
                    cmbWorkingDirectory.SelectedIndex = 0;
                    sciCommand.Focus();
                }
            }
        }

        private void cmbWorkingDirectory_Resize(object sender, EventArgs e)
        {
            cmbWorkingDirectory.DropDownWidth = cmbWorkingDirectory.Width + 10;
        }

        private void cmbWorkingDirectory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbWorkingDirectory.SelectedItem != null)
            {
                txtWorkingDirectory.Text = cmbWorkingDirectory.SelectedItem.ToString();
                txtWorkingDirectory.Focus();
                txtWorkingDirectory.Select(txtWorkingDirectory.TextLength, 0);
            }
        }

    }
}
