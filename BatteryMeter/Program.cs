using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BatteryMeter
{
    static class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FreeConsole();

        [STAThread]
        static void Main(string[] args)
        {
            String op = "";

            if (args != null && args.Length > 0)
            {
                op = args[0];
            }


            if (!String.IsNullOrWhiteSpace(op) && AllocConsole())
            {
                if ("li" == op)
                {
                    PerformanceCounterCategory category = new PerformanceCounterCategory("Network Interface");
                    String[] instancename = category.GetInstanceNames();

                    foreach (string name in instancename)
                    {
                        Console.WriteLine("Interface Name : {0}", name);
                    }
                }

                Console.Read();

                FreeConsole();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new BatteryMeterMainForm());
            }
        }
    }
}
