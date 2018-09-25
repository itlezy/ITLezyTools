using System;
using System.Diagnostics;
using System.Windows.Forms;
using Itlezy.App.QuickManager.Config;
using Itlezy.Common.Platform;

namespace Itlezy.App.QuickManager.Diagnostics
{
    public class ExternalLauncher
    {
        public void LaunchCommandPrompt(ItemConfig itemConfig, bool copyCommand)
        {
            if (itemConfig != null && itemConfig.ProcessStartInfo != null &&
                !String.IsNullOrWhiteSpace(itemConfig.ProcessStartInfo.WorkingDirectory))
            {
                ProcessStartInfo piCmd = new ProcessStartInfo()
                {
                    FileName = Environment.GetEnvironmentVariable("ComSpec"),
                    WorkingDirectory = itemConfig.ProcessStartInfo.WorkingDirectory,
                    UseShellExecute = false
                };

                if (itemConfig.ProcessStartInfo.EnvironmentVariables != null && itemConfig.ProcessStartInfo.EnvironmentVariables.Count > 0)
                {
                    foreach (String envVarName in itemConfig.ProcessStartInfo.EnvironmentVariables.Keys)
                    {
                        piCmd.EnvironmentVariables[envVarName] = itemConfig.ProcessStartInfo.EnvironmentVariables[envVarName];
                    }
                }

                if (copyCommand)
                {
                    String command = itemConfig.ProcessStartInfo.FileName + " " +
                        itemConfig.ProcessStartInfo.Arguments;

                    if (!String.IsNullOrWhiteSpace(command))
                    {
                        ClipboardHelper.SetText(command);
                    }
                }

                Process.Start(piCmd);
            }
        }

        public void LaunchExplorer(ItemConfig itemConfig)
        {
            if (itemConfig != null && itemConfig.ProcessStartInfo != null &&
                !String.IsNullOrWhiteSpace(itemConfig.ProcessStartInfo.WorkingDirectory))
            {
                ProcessStartInfo piExplorer = new ProcessStartInfo()
                {
                    FileName = "explorer.exe",
                    Arguments = "\"" + itemConfig.ProcessStartInfo.WorkingDirectory + "\"",
                    UseShellExecute = false
                };

                Process.Start(piExplorer);
            }
        }
    }
}
