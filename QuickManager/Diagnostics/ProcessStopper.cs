using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using log4net;
using System.Diagnostics;
using System.Management;
using Itlezy.App.OutputViewer.UI;
using Itlezy.Common.Platform;
using Itlezy.App.QuickManager.Config;

namespace Itlezy.App.QuickManager.Diagnostics
{
    public class ProcessStopper : Itlezy.Common.Diagnostics.ProcessStopper
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(ProcessStopper));

        public bool StopProcessWithProcess(ItemConfig itemConfig, OutputViewerMainForm outputViewer, int maxWait)
        {
            try
            {
                using (Process stopProcess = new Process())
                {
                    stopProcess.StartInfo = itemConfig.ProcessStopInfo.ProcessStartInfo;
                    stopProcess.EnableRaisingEvents = true;

                    // throws exception if using WaitForExit
                    //stopProcess.Exited += delegate(object sender_ex, EventArgs e_ex)

                    if (stopProcess.StartInfo.CreateNoWindow)
                    {
                        stopProcess.StartInfo.RedirectStandardError = true;
                        stopProcess.StartInfo.RedirectStandardOutput = true;

                        stopProcess.ErrorDataReceived += delegate(object sender_ed, DataReceivedEventArgs e_ed)
                        {
                            if (!AppContext.ContainerExiting(outputViewer))
                            {
                                outputViewer.AppendMsg(itemConfig.LogName, e_ed.Data, OutputKind.STDERR);
                            }
                        };

                        stopProcess.OutputDataReceived += delegate(object sender_od, DataReceivedEventArgs e_od)
                        {
                            if (!AppContext.ContainerExiting(outputViewer))
                            {
                                outputViewer.AppendMsg(itemConfig.LogName, e_od.Data, OutputKind.STDOUT);
                            }
                        };
                    }

                    stopProcess.Start();

                    if (stopProcess.StartInfo.CreateNoWindow)
                    {
                        stopProcess.BeginErrorReadLine();
                        stopProcess.BeginOutputReadLine();
                    }

                    stopProcess.WaitForExit(maxWait);

                    if (!stopProcess.HasExited)
                    {
                        KillProcessTree(stopProcess);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                logger.Error("", ex);
                return false;
            }
        }

        public bool StopProcessWithTCP(ItemConfig itemConfig)
        {
            try
            {
                using (TcpClient tc = new TcpClient()
                {
                    NoDelay = true,
                    ReceiveTimeout = 500,
                    SendTimeout = 500
                })
                {
                    tc.Connect(
                        itemConfig.ProcessStopInfo.ProcessStopTcpInfo.IpAddress,
                        itemConfig.ProcessStopInfo.ProcessStopTcpInfo.Port);

                    return
                        tc.Client.Send(Encoding.Default.GetBytes(
                            itemConfig.ProcessStopInfo.ProcessStopTcpInfo.StopKey
                            +
                            "\r\nstop\r\n"))
                        > 0;
                }
            }
            catch (Exception ex)
            {
                logger.Error("", ex);
                return false;
            }
        }

    }
}
