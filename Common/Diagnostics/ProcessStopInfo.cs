using System;
using System.Diagnostics;

namespace Itlezy.Common.Diagnostics
{
    public enum ProcessStopKind
    {
        TCP, PROCESS
    }

    public class ProcessStopTcpInfo
    {
        public String IpAddress { get; set; }
        public int Port { get; set; }
        public String StopKey { get; set; }
    }

    public class ProcessStopInfo
    {
        public ProcessStopKind ProcessStopKind { get; set; }
        public bool CanStop { get; set; }
        public ProcessStopTcpInfo ProcessStopTcpInfo { get; set; }
        public ProcessStartInfo ProcessStartInfo { get; set; }
    }
}
