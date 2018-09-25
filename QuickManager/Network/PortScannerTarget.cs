using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Itlezy.App.Network
{
    public class PortScannerTarget
    {
        public String Host { get; set; }
        public int Port { get; set; }
        public bool Open { get; set; }
        public bool Probed { get; set; }

        public override String ToString()
        {
            return String.Format("Host {0}, Port {1}, Open {2}", Host, Port, Open);
        }
    }
}
