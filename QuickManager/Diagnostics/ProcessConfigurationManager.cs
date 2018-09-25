using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Itlezy.App.QuickManager.Config;
using Itlezy.Common.Config;
using Itlezy.Common.Diagnostics;

namespace Itlezy.App.QuickManager.Diagnostics
{
    public class ProcessConfigurationManager
    {
        private readonly XmlConfigHelper xmlConfigHelper = new XmlConfigHelper();
        private EnvironmentConfig environmentConfig;

        public ProcessConfigurationManager(EnvironmentConfig environmentConfig)
        {
            this.environmentConfig = environmentConfig;
        }

        public ProcessStopInfo ProcessStopInfoFromId(XmlDocument xConfig, LaunchInfo launchInfo)
        {
            if (xConfig != null && !String.IsNullOrWhiteSpace(launchInfo.Id))
            {
                XmlNode n = xConfig.SelectSingleNode(String.Format("//action[@id='{0}']/stop", launchInfo.XmlId));
                if (n != null)
                {
                    return ProcessStopInfoFromXmlNode(n, launchInfo);
                }
            }

            return null;
        }

        public ProcessStartInfo ProcessStartInfoFromId(XmlDocument xConfig, LaunchInfo launchInfo)
        {
            if (xConfig != null && !String.IsNullOrWhiteSpace(launchInfo.Id))
            {
                XmlNode n = xConfig.SelectSingleNode(String.Format("//action[@id='{0}']/launch", launchInfo.XmlId));
                if (n != null)
                {
                    return ProcessStartInfoFromXmlNode(n, launchInfo);
                }
            }

            return null;
        }

        private ProcessStopInfo ProcessStopInfoFromXmlNode(XmlNode x, LaunchInfo launchInfo)
        {
            ProcessStopInfo processStopInfo = new ProcessStopInfo();

            if (x.SelectSingleNode("tcp") != null)
            {
                processStopInfo.ProcessStopKind = ProcessStopKind.TCP;
                processStopInfo.ProcessStopTcpInfo = new ProcessStopTcpInfo()
                {
                    IpAddress = x.SelectSingleNode("tcp/ipAddress").InnerText,
                    Port = int.Parse(x.SelectSingleNode("tcp/port").InnerText),
                    StopKey = x.SelectSingleNode("tcp/stopKey").InnerText
                };

            }
            else if (x.SelectSingleNode("launch") != null)
            {
                processStopInfo.ProcessStopKind = ProcessStopKind.PROCESS;
                processStopInfo.ProcessStartInfo = ProcessStartInfoFromXmlNode(
                    x.SelectSingleNode("launch"), launchInfo);
            }

            processStopInfo.CanStop = xmlConfigHelper.ReadBool(x, "@canStop", true);

            return processStopInfo;
        }

        /// <summary>
        /// Returns a ProcessStartInfo object populated from the XML Configuration
        /// The variables expansion follows the logic:
        /// 1. expand ${variables} under the global section
        /// 2. expand 'env' specific variables
        /// 3. expand current env variables
        /// </summary>
        private ProcessStartInfo ProcessStartInfoFromXmlNode(XmlNode x, LaunchInfo launchInfo)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo();

            if (x.SelectSingleNode("exe") != null)
            {
                processStartInfo.FileName = x.SelectSingleNode("exe").InnerText;
            }

            if (launchInfo.Type == LaunchInfo.LaunchType.ANT)
            {
                processStartInfo.Arguments = "-f \"" + xmlConfigHelper.ReadString(x, "buildFile") + "\" \"" + launchInfo.AntTarget + "\"";

                if (x.SelectSingleNode("parms") != null)
                {
                    processStartInfo.Arguments += " " + x.SelectSingleNode("parms").InnerText;
                }

                // default to ant.bat
                if (String.IsNullOrWhiteSpace(processStartInfo.FileName))
                {
                    processStartInfo.FileName = @"%ANT_HOME%\bin\ant.bat";
                }
            }
            else if (x.SelectSingleNode("parms") != null)
            {
                processStartInfo.Arguments = x.SelectSingleNode("parms").InnerText;
            }

            if (x.SelectSingleNode("workingDir") != null)
            {
                processStartInfo.WorkingDirectory = x.SelectSingleNode("workingDir").InnerText;
            }
            else
            {
                processStartInfo.WorkingDirectory = Path.GetDirectoryName(processStartInfo.FileName);
            }

            // defaulting to CreateNoWindow
            processStartInfo.CreateNoWindow = xmlConfigHelper.ReadBool(x, "createNoWindow", true);

            if (processStartInfo.CreateNoWindow)
            {
                processStartInfo.RedirectStandardError = true;
                processStartInfo.RedirectStandardOutput = true;

                // encoding
                {
                    String encoding = xmlConfigHelper.ReadString(x, "encoding");
                    if (!String.IsNullOrWhiteSpace(encoding))
                    {
                        processStartInfo.StandardErrorEncoding = Encoding.GetEncoding(encoding);
                        processStartInfo.StandardOutputEncoding = Encoding.GetEncoding(encoding);
                    }
                    else
                    {
                        processStartInfo.StandardErrorEncoding = Encoding.UTF8;
                        processStartInfo.StandardOutputEncoding = Encoding.UTF8;
                    }
                }
            }

            processStartInfo.UseShellExecute = false;

            // apply the process environment
            ApplyEnvironment(x, processStartInfo);

            return processStartInfo;
        }

        private void ApplyEnvironment(XmlNode x, ProcessStartInfo processStartInfo)
        {
            String customEnvId = xmlConfigHelper.ReadString(x, "@env");
            var customEnv = environmentConfig.FindCustomEnv(customEnvId);

            // apply to the actual env
            if (customEnv != null)
            {
                foreach (var kvVarInEnv in customEnv)
                {
                    processStartInfo.EnvironmentVariables[kvVarInEnv.Key.Replace("%", "")] = kvVarInEnv.Value;
                }
            }

            // replace in strings
            if (processStartInfo.FileName != null)
            {
                processStartInfo.FileName = environmentConfig.Expand(processStartInfo.FileName, customEnvId);
            }

            if (processStartInfo.Arguments != null)
            {
                processStartInfo.Arguments = environmentConfig.Expand(processStartInfo.Arguments, customEnvId);
            }

            if (processStartInfo.WorkingDirectory != null)
            {
                processStartInfo.WorkingDirectory = environmentConfig.Expand(processStartInfo.WorkingDirectory, customEnvId);
            }
        }

        public IList<LaunchInfo> ReadLaunchInfos(XmlDocument xQuickManagerConfig)
        {
            IList<LaunchInfo> launchInfos = new List<LaunchInfo>();

            foreach (XmlNode xn in xQuickManagerConfig.SelectNodes("//monitor/monitorItem"))
            {
                LaunchInfo launchInfo = new LaunchInfo()
                {
                    XmlId = xmlConfigHelper.ReadString(xn, "@id").Trim(),
                    Url = xmlConfigHelper.ReadString(xn, "url"),
                    OrderBy = xmlConfigHelper.ReadInt(xn, "@orderBy")
                };

                if (String.IsNullOrWhiteSpace(launchInfo.XmlId))
                {
                    throw new ArgumentException("MonitorItem Ids can't be blank, node " + xn.OuterXml);
                }

                if (launchInfo.XmlId.Contains(':') ||
                    launchInfo.XmlId.Contains('|'))
                {
                    throw new ArgumentException("Invalid character ( : or | ) found in MonitorItem Id [" + launchInfo.Id + "]");
                }

                if (!launchInfos.Contains(launchInfo))
                {
                    launchInfos.Add(launchInfo);
                }
            }

            foreach (XmlNode xn in xQuickManagerConfig.SelectNodes("//actions/action"))
            {
                LaunchInfo launchInfo = new LaunchInfo()
                {
                    XmlId = xmlConfigHelper.ReadString(xn, "@id").Trim(),
                    Env = xmlConfigHelper.ReadString(xn, "launch/@env").Trim(),
                    OrderBy = xmlConfigHelper.ReadInt(xn, "@orderBy")
                };

                if (String.IsNullOrWhiteSpace(launchInfo.XmlId))
                {
                    throw new ArgumentException("Launch Ids can't be blank, node " + xn.OuterXml);
                }

                if (launchInfo.XmlId.Contains(':') ||
                    launchInfo.XmlId.Contains('|'))
                {
                    throw new ArgumentException("Invalid character ( : or | ) found in Launch Id [" + launchInfo.XmlId + "]");
                }

                if ("ch" == launchInfo.XmlId || "ff" == launchInfo.XmlId || "ie" == launchInfo.XmlId)
                {
                    continue;
                }

                if (!launchInfos.Contains(launchInfo))
                {
                    if ("ant".Equals(xmlConfigHelper.ReadString(xn, "@type")))
                    {
                        // TODO support other variables expansion
                        String buildFile = environmentConfig.Expand(
                            xmlConfigHelper.ReadString(xn, "launch/buildFile"),
                            launchInfo.Env);

                        if (!File.Exists(buildFile))
                        {
                            throw new FileNotFoundException(
                                String.Format(
                                "Invalid ANT file specified " + Environment.NewLine +
                                "{0}" + Environment.NewLine +
                                "for Launch Id {1}", buildFile, launchInfo.XmlId));
                        }

                        // expand ant targets
                        foreach (String targetName in xmlConfigHelper.ReadAntTargets(buildFile))
                        {
                            if (xn.SelectNodes("launch/targets/target").Count == 0 ||
                                xn.SelectSingleNode(String.Format("launch/targets/target[text()='{0}']", targetName)) != null)
                            {
                                launchInfos.Add(new LaunchInfo()
                                {
                                    XmlId = launchInfo.Id,
                                    AntTarget = targetName,
                                    Type = LaunchInfo.LaunchType.ANT,
                                    OrderBy = launchInfo.OrderBy
                                });
                            }
                        }
                    }
                    else
                    {
                        // just add the launch item
                        launchInfos.Add(launchInfo);
                    }
                }
                else
                {
                    // update the orderBy on the existing entry, if the launchInfo was already in the List
                    if (launchInfo.OrderBy != 0)
                    {
                        launchInfos.First(p => (p.XmlId == launchInfo.Id)).OrderBy = launchInfo.OrderBy;
                    }
                }
            }

            return launchInfos;
        }

        public ItemConfig ReadItemConfig(XmlDocument xQuickManagerConfig, LaunchInfo launchInfo)
        {
            ItemConfig itemConfig = new ItemConfig()
            {
                MonitorConfig = new MonitorConfig()
                {
                    Id = launchInfo.Id,
                    Url = launchInfo.Url
                },
                ProcessStartInfo = ProcessStartInfoFromId(xQuickManagerConfig, launchInfo),
                ProcessStopInfo = ProcessStopInfoFromId(xQuickManagerConfig, launchInfo),

                AutoStart = launchInfo.Type != LaunchInfo.LaunchType.ANT &&
                            xmlConfigHelper.ReadBool(xQuickManagerConfig,
                            String.Format("//action[@id='{0}']/@autoStart", launchInfo.XmlId)),

                StartAll = launchInfo.Type != LaunchInfo.LaunchType.ANT &&
                            xmlConfigHelper.ReadBool(xQuickManagerConfig,
                            String.Format("//action[@id='{0}']/@startAll", launchInfo.XmlId)),

                LogName = xmlConfigHelper.ReadString(xQuickManagerConfig,
                          String.Format("//action[@id='{0}']/@logName", launchInfo.XmlId)),
            };

            foreach (XmlNode xConfig in
                xQuickManagerConfig.SelectNodes(String.Format("//action[@id='{0}']/config/configFile", launchInfo.XmlId)))
            {
                var configFile = xmlConfigHelper.ReadString(xConfig, ".");

                if (!String.IsNullOrWhiteSpace(configFile))
                {
                    itemConfig.ConfigurationFiles.Add(
                        environmentConfig.Expand(configFile, launchInfo.Env));
                }
            }

            return itemConfig;
        }
    }
}
