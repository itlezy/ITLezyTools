using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Itlezy.App.QuickManager.Diagnostics
{
    /// <summary>
    /// Maps the XML configuration 'monitorItem' and 'launch' entries
    /// It's populated based on the XML configuration, it's immutable
    /// </summary>
    public class LaunchInfo
    {
        public enum LaunchType
        {
            NORMAL, ANT
        }

        public String Id
        {
            get
            {
                if (Type == LaunchType.ANT)
                {
                    return XmlId + ":" + AntTarget;
                }
                else
                {
                    return XmlId;
                }
            }
        }
        public String XmlId { get; set; }
        public String Env { get; set; }
        public String AntTarget { get; set; }
        public String Url { get; set; }
        public LaunchType Type { get; set; }
        public int OrderBy { get; set; }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is LaunchInfo)
            {
                return this.Id != null && this.Id.Equals((obj as LaunchInfo).Id);
            }

            return false;
        }

    }
}
