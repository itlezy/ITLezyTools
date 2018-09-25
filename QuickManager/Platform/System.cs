using System;
using System.Management;
using log4net;

namespace Itlezy.App.QuickManager.Platform
{
	public class System
	{
		private static readonly ILog logger = LogManager.GetLogger(typeof(System));
		
		public System()
		{
		}
		
		public void Logoff()
		{
			DoShutdown(0x4);
		}
		
		public void Reboot()
		{
			DoShutdown(0x6);
		}
		
		public void Poweroff()
		{
			DoShutdown(0xC);
		}
		
		private void DoShutdown(int flag)
		{
			// http://msdn.microsoft.com/en-us/library/aa394058%28v=vs.85%29.aspx
			
			try
			{
				ManagementClass W32_OS = new ManagementClass("Win32_OperatingSystem");
				W32_OS.Scope.Options.EnablePrivileges = true;

				foreach(ManagementObject obj in W32_OS.GetInstances())
				{
					ManagementBaseObject inParams = obj.GetMethodParameters("Win32Shutdown");
					inParams["Flags"] = flag;
					inParams["Reserved"] = 0;

					obj.InvokeMethod("Win32Shutdown", inParams, null);
				}
			}
			catch (Exception ex)
			{
				logger.Error("Shutdown command failed", ex);
			}
		}
	}
}
