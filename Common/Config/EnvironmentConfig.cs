using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace Itlezy.Common.Config
{
    /// <summary>
    /// Takes care of handling environments, variables and place-holders expansion
    /// </summary>
    public class EnvironmentConfig
    {
        private readonly XmlConfigHelper xmlConfigHelper = new XmlConfigHelper();
        private readonly IDictionary<String, IDictionary<String, String>> envs = new Dictionary<String, IDictionary<String, String>>();

        public IDictionary<String, IDictionary<String, String>> Environments
        {
            get
            {
                return envs;
            }
        }

        /// <summary>
        /// ${} variables
        /// </summary>
        private const String GLOBAL_ENV = "global";
        /// <summary>
        /// Current process env
        /// </summary>
        private const String PROCESS_ENV = "env";
        /// <summary>
        /// Custom env prefix
        /// </summary>
        private const String CUSTOM_ENV_PREFIX = "env::custom::";

        public EnvironmentConfig(XmlDocument xd)
        {
            String includeFile = xmlConfigHelper.ReadString(xd, "//envs/@include");

            if (!String.IsNullOrWhiteSpace(includeFile))
            {
                String configurationFile = new Uri(xd.BaseURI).LocalPath;

                if (!Path.IsPathRooted(includeFile) && Path.IsPathRooted(configurationFile))
                {
                    includeFile = Path.GetDirectoryName(configurationFile) + @"\" + includeFile;
                }

                if (File.Exists(includeFile))
                {
                    XmlDocument xd1 = new XmlDocument();
                    xd1.Load(includeFile);

                    xd.SelectSingleNode("//envs").InnerXml += xd1.DocumentElement.InnerXml;
                }
                else
                {
                    throw new ApplicationException(String.Format("Invalid Include File '{0}'", includeFile));
                }
            }

            this.Init(xd);
        }

        private void Init(XmlDocument xd)
        {
            // global (temporary Dictionary)
            var globalEnv = new Dictionary<String, String>(StringComparer.OrdinalIgnoreCase);

            foreach (XmlNode xVar in xd.SelectNodes("//envs/global/vars/var"))
            {
                String varName = "${" + xmlConfigHelper.ReadString(xVar, "name") + "}";
                String varValue = xmlConfigHelper.ReadString(xVar, "value");

                globalEnv.Add(varName, varValue);
            }

            envs.Add(GLOBAL_ENV, new Dictionary<String, String>(StringComparer.OrdinalIgnoreCase));

            // expand nested ${}
            foreach (var varEntry in globalEnv)
            {
                String expand = varEntry.Value;

                if (expand.Contains("${"))
                {
                    foreach (var varEntryInner in globalEnv)
                    {
                        expand = expand.Replace(varEntryInner.Key, varEntryInner.Value);
                    }
                }

                envs[GLOBAL_ENV].Add(varEntry.Key, expand);
            }

            // env
            envs.Add(PROCESS_ENV, new Dictionary<String, String>(StringComparer.OrdinalIgnoreCase));

            // default env and overrides
            foreach (XmlNode xVar in xd.SelectNodes("//envs/default/vars/var"))
            {
                String varName = xmlConfigHelper.ReadString(xVar, "name");
                String varValue = Environment.ExpandEnvironmentVariables(xmlConfigHelper.ReadString(xVar, "value"));

                Environment.SetEnvironmentVariable(varName, varValue);
                envs[PROCESS_ENV]["%" + varName + "%"] = varValue;
            }

            foreach (String varName in Environment.GetEnvironmentVariables().Keys)
            {
                String varValue = Environment.GetEnvironmentVariable(varName);
                envs[PROCESS_ENV]["%" + varName + "%"] = varValue;
            }

            // specific envs
            foreach (XmlNode xEnv in xd.SelectNodes("//envs/env"))
            {
                String envId = xmlConfigHelper.ReadString(xEnv, "@id");

                if (!String.IsNullOrWhiteSpace(envId))
                {
                    envs.Add(CUSTOM_ENV_PREFIX + envId, new Dictionary<String, String>(StringComparer.OrdinalIgnoreCase));
                    Dictionary<String, String> currentEnv = new Dictionary<String, String>(StringComparer.OrdinalIgnoreCase);

                    // populate the temporary dictionary to perform expansion
                    foreach (XmlNode xVar in xEnv.SelectNodes("vars/var"))
                    {
                        String varName = "%" + xmlConfigHelper.ReadString(xVar, "name").Replace("%", "") + "%";
                        String varValue = xmlConfigHelper.ReadString(xVar, "value");

                        envs[CUSTOM_ENV_PREFIX + envId].Add(varName, varValue);
                    }
                }
            }
        }

        public String Expand(String original, String customEnvId)
        {
            String expand = original;

            if (!String.IsNullOrWhiteSpace(customEnvId) && envs.Keys.Contains(CUSTOM_ENV_PREFIX + customEnvId))
            {
                // expand custom env variables first
                foreach (var kvVarInEnv in envs[CUSTOM_ENV_PREFIX + customEnvId])
                {
                    expand = expand.Replace(kvVarInEnv.Key, kvVarInEnv.Value);
                }
            }

            // expand process env and ${} variables
            foreach (var kvEnvInEnv in envs.Where(k => k.Key == PROCESS_ENV || k.Key == GLOBAL_ENV))
            {
                foreach (var kvVarInEnv in kvEnvInEnv.Value)
                {
                    expand = expand.Replace(kvVarInEnv.Key, kvVarInEnv.Value);
                }
            }

            return expand;
        }

        public IDictionary<String, String> FindCustomEnv(String envId)
        {
            if (!String.IsNullOrWhiteSpace(envId) && envs.Keys.Contains(CUSTOM_ENV_PREFIX + envId))
            {
                return envs[CUSTOM_ENV_PREFIX + envId];
            }
            else
            {
                return null;
            }
        }
    }
}
