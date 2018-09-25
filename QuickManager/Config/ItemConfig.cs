using System;
using System.Diagnostics;
using System.Xml;
using System.Text;
using System.Collections.Generic;
using Itlezy.Common.Diagnostics;

namespace Itlezy.App.QuickManager.Config
{
    /// <summary>
    /// The configuration attached to each ListViewItem
    /// It's a live object, which references the active process and other UI dependant flags
    /// The LaunchInfo elements, mapped from the XML configuration, are used to populate upon
    /// configuration reload, the ListViewItems, where each has an ItemConfig object attached
    /// </summary>
    public class ItemConfig
    {
        public ItemConfig()
        {
            this.ConfigurationFiles = new List<String>();
        }

        public MonitorConfig MonitorConfig { get; set; }
        public ProcessStartInfo ProcessStartInfo { get; set; }
        public ProcessStopInfo ProcessStopInfo { get; set; }
        public Process Process { get; set; }
        public bool AutoStart { get; set; }
        public bool Restart { get; set; }
        public bool StartAll { get; set; }
        public System.Windows.Forms.ListViewItem StartNext { get; set; }
        public IList<String> ConfigurationFiles { get; set; }
        public DateTime StartTime { get; set; }

        private String logName;
        public String LogName
        {
            set
            {
                this.logName = value;
            }

            get
            {
                if (!String.IsNullOrWhiteSpace(this.logName))
                {
                    return logName;
                }
                else
                {
                    return this.MonitorConfig.Id;
                }
            }
        }

        /// <summary>
        /// Can the process be Started (state independent)
        /// </summary>
        public bool Startable
        {
            get
            {
                return ProcessStartInfo != null;
            }
        }

        /// <summary>
        /// Is the process currently running
        /// </summary>
        public bool Started
        {
            get
            {
                return Startable && Process != null && !Process.HasExited;
            }
        }

        /// <summary>
        /// Can the process be Stopped (state independent)
        /// </summary>
        public bool Stoppable
        {
            get
            {
                if (ProcessStopInfo != null && !ProcessStopInfo.CanStop)
                {
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// Can the process be Stopped with a Process (state independent)
        /// </summary>
        public bool StoppableWithProcess
        {
            get
            {
                if (ProcessStopInfo != null && ProcessStopInfo.ProcessStartInfo != null) // TODO if null, should be misconfig ?
                {
                    // if start/stop through process, enable stop
                    return true;
                }

                return false;
            }
        }

        public bool Stopped
        {
            get
            {
                return !Started;
            }
        }

        /// <summary>
        /// Can the process be Restarted (state independent)
        /// </summary>
        public bool Restartable
        {
            get
            {
                return Startable && Stoppable;
            }
        }

        /// <summary>
        /// Can the process be Started (state dependent)
        /// </summary>
        public bool CanStart
        {
            get
            {
                return Startable && !Started;
            }
        }

        /// <summary>
        /// Can the process be Stopped (state dependent)
        /// </summary>
        public bool CanStop
        {
            get
            {
                return Stoppable && (Started || StoppableWithProcess);
            }
        }

        /// <summary>
        /// Can the process be Restarted (state dependent)
        /// </summary>
        public bool CanRestart
        {
            get
            {
                return Restartable && Started && CanStop;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (MonitorConfig != null)
            {
                sb.AppendFormat("Id {0}", MonitorConfig.Id);
            }

            if (ProcessStartInfo != null)
            {
                sb.AppendFormat("ProcessStartInfo {0}", ProcessStartInfo.FileName);
            }

            if (StartNext != null && StartNext.Tag as ItemConfig != null)
            {
                sb.AppendFormat("StartNext {0}", StartNext.Tag as ItemConfig);
            }

            return sb.ToString();
        }
    }
}
