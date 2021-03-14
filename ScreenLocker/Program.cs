using System;
using System.Windows.Forms;

namespace ScreenLocker
{
    internal sealed class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            LockManager lockManager = new LockManager();

            if (lockManager.AcquireLock())
            {
                try
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    foreach (Screen screen in Screen.AllScreens)
                    {
                        Form lockScreenForm = new LockScreenForm(screen);
                        lockScreenForm.Show();
                    }

                    Application.Run();
                }
                finally
                {
                    lockManager.ReleaseLock();
                }
            }
            else
            {
                MessageBox.Show("Instance already running, lock file exists " + lockManager.LockFile);
            }
        }

    }
}
