using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using log4net;

namespace Itlezy.App.Network
{
    public class ScanPort
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(ScanPort));

        public void Scan(PortScannerTarget portScannerTarget)
        {
            using (TcpClient tc = new TcpClient())
            {
                try
                {
                    logger.DebugFormat("Scanning [{0}]", portScannerTarget);

                    portScannerTarget.Probed = true;

                    tc.NoDelay = true;
                    tc.BeginConnect(
                        portScannerTarget.Host, portScannerTarget.Port, null, null).AsyncWaitHandle.WaitOne(
                        TimeSpan.FromSeconds(1));

                    portScannerTarget.Open = tc.Connected;

                    logger.InfoFormat("Scanned [{0}]", portScannerTarget);
                }
                catch (Exception ex)
                {
                    logger.Error("", ex);
                }
            }
        }
    }
}
