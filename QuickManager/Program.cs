using System;
using System.IO;
using System.Windows.Forms;
using Itlezy.App.QuickManager.UI;
using Itlezy.Common;
using log4net;
using log4net.Config;

namespace Itlezy.App.QuickManager
{
    internal sealed class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            System.AppDomain.CurrentDomain.UnhandledException += ExceptionHandler.UnhandledExceptionTrapper;

            String configFile = String.Empty;

            if (args != null && args.Length > 0 && File.Exists(args[0]))
            {
                configFile = args[0];
            }

            try
            {
                if (File.Exists("QuickManagerConfig-log4net.xml"))
                {
                    XmlConfigurator.Configure(new FileInfo("QuickManagerConfig-log4net.xml"));
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(new MainForm(configFile));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ILog logger = LogManager.GetLogger(typeof(MainForm));
                logger.Error("Application Error", ex);
                Application.Exit();
            }
        }

    }
}
