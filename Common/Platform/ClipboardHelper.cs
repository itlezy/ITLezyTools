using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Itlezy.Common.Platform
{
    public class ClipboardHelper
    {
        public static void SetText(String text)
        {
            try
            {
                Clipboard.SetText(text);
            }
            catch
            {
            }
        }

        public static String GetText()
        {
            try
            {
                return Clipboard.GetText();
            }
            catch
            {
                return String.Empty;
            }
        }

        public static void Clear()
        {
            try
            {
                Clipboard.Clear();
            }
            catch
            {
            }
        }
    }
}
