using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Diagnostics;
using System.Management;

namespace Itlezy.Common.Diagnostics
{
    public class ProcessStopper
    {
        public bool KillProcessTree(Process root)
        {
            if (root != null)
            {
                try
                {
                    var list = new List<Process>();
                    GetProcessAndChildren(Process.GetProcesses(), root, list, 1);

                    foreach (Process p in list)
                    {
                        try
                        {
                            p.Kill();
                        }
                        catch { }
                    }

                    return true;
                }
                catch
                {
                    //Log error?
                }
            }

            return false;
        }

        private int GetParentProcessId(Process p)
        {
            int parentId = 0;
            try
            {
                ManagementObject mo = new ManagementObject("win32_process.handle='" + p.Id + "'");
                mo.Get();
                parentId = Convert.ToInt32(mo["ParentProcessId"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                parentId = 0;
            }
            return parentId;
        }

        private void GetProcessAndChildren(Process[] plist, Process parent, List<Process> output, int indent)
        {
            foreach (Process p in plist)
            {
                if (GetParentProcessId(p) == parent.Id)
                {
                    GetProcessAndChildren(plist, p, output, indent + 1);
                }
            }
            output.Add(parent);
        }

    }
}
