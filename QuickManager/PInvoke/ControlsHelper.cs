using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using log4net;

namespace Itlezy.App.QuickManager.PInvoke
{
	public class ControlsHelper
	{
		private static readonly ILog logger = LogManager.GetLogger(typeof(ControlsHelper));
		
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		
		// Constants
		private const int WM_SETREDRAW = 0xB;
		private const int FALSE = 0;
		private const int TRUE = 1;
		
		public void ResumeLayout(Control control)
		{
			if (control != null)
			{
				try
				{
					SendMessage(control.Handle, WM_SETREDRAW, TRUE, 0);
					
					//Thread.Sleep(200);
					
					control.Invalidate();
					//control.Invoke(new Action(() => control.Refresh()));
				}
				catch (Exception ex)
				{
					logger.Error("", ex);
				}
			}
		}
		
		public void SuspendLayout(Control control)
		{
			if (control != null)
			{
				try
				{
					SendMessage(control.Handle, WM_SETREDRAW, FALSE, 0);
				}
				catch (Exception ex)
				{
					logger.Error("", ex);
				}
			}
		}
	}
}
