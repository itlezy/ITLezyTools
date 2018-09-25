using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Itlezy.App.QuickManager.Config
{
    class XmlConfigHelper
    {
        public bool ReadBool(XmlNode xn, String selector)
        {
            return ReadBool(xn, selector, false);
        }

        public bool ReadBool(XmlNode xn, String selector, bool defaultValue)
        {
            bool ret;

            if (xn != null &&
                xn.SelectSingleNode(selector) != null &&
                bool.TryParse(xn.SelectSingleNode(selector).InnerText, out ret))
            {
                return ret;
            }
            else
            {
                return defaultValue;
            }
        }

        public String ReadString(XmlNode xn, String selector)
        {
            if (xn != null &&
                xn.SelectSingleNode(selector) != null &&
                !String.IsNullOrWhiteSpace(xn.SelectSingleNode(selector).InnerText))
            {
                return xn.SelectSingleNode(selector).InnerText;
            }
            else
            {
                return String.Empty;
            }
        }

        public IList<String> ReadAntTargets(String filePath)
        {
            IList<String> targets = new List<String>();
            XmlDocument xd = new XmlDocument();
            xd.Load(filePath);

            foreach (XmlNode xn in xd.SelectNodes("//target"))
            {
                String target = ReadString(xn, "@name");

                if (!String.IsNullOrWhiteSpace(target))
                {
                    targets.Add(target);
                }
            }

            return targets;
        }

        public int ReadInt(XmlNode xn, String selector)
        {
            int ret = 0;
            if (xn != null &&
                xn.SelectSingleNode(selector) != null &&
                int.TryParse(xn.SelectSingleNode(selector).InnerText, out ret))
            {
                return ret;
            }
            else
            {
                return 0;
            }
        }
    }
}
