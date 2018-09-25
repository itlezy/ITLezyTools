using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Itlezy.Common.Platform
{
    public static class AppContext
    {
        public static bool IsContainerExiting { get; set; }

        private static bool ControlExiting(ContainerControl control)
        {
            return control == null || control.Disposing || control.IsDisposed;
        }

        public static bool ContainerExiting(ContainerControl control)
        {
            return IsContainerExiting || control == null || control.Disposing || control.IsDisposed;
        }

        public static bool ContainerExiting(ContainerControl[] controls)
        {
            if (IsContainerExiting) { return true; }

            foreach (ContainerControl control in controls)
            {
                if (control == null || control.Disposing || control.IsDisposed)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
