using SolrTool.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SolrTool
{
    public class AppGlobalConfigs
    {
        public static string BaseDirectory => AppDomain.CurrentDomain.BaseDirectory;

        public static string ConfigFilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.xml");

        public static ConfigRoot AppConfig
        {
            get
            {
                var xmlSer = new XmlSerializer(typeof(ConfigRoot));
                var config = xmlSer.Deserialize(XmlReader.Create(ConfigFilePath)) as ConfigRoot;
                return config;
            }
        }
    }
}
