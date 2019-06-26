using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace SolrTool.Models
{

    [XmlRoot(ElementName = "addr")]
    public class _Addr
    {
        [XmlElement(ElementName = "ip")]
        public string Ip { get; set; }
        [XmlElement(ElementName = "port")]
        public string Port { get; set; }
    }
    

    [XmlRoot(ElementName = "server")]
    public class _Server
    {
        [XmlElement(ElementName = "addr")]
        public _Addr Addr { get; set; }
        [XmlElement(ElementName = "auth")]
        public _Auth Auth { get; set; }
    }



    [XmlRoot(ElementName = "auth")]
    public class _Auth
    {
        [XmlElement(ElementName = "username")]
        public string Username { get; set; }
        [XmlElement(ElementName = "password")]
        public string Password { get; set; }
    }

    [XmlRoot(ElementName = "solr")]
    public class _Solr
    {
        [XmlElement(ElementName = "baseUrl")]
        public string BaseUrl { get; set; }
        [XmlElement(ElementName = "singleNode")]
        public string SingleNode { get; set; }
        [XmlElement(ElementName = "auth")]
        public _Auth Auth { get; set; }
    }

    [XmlRoot(ElementName = "zookeeper")]
    public class _Zookeeper
    {
        [XmlElement(ElementName = "binPath")]
        public string BinPath { get; set; }
        [XmlElement(ElementName = "cliPort")]
        public string CliPort { get; set; }
        [XmlElement(ElementName = "configPath")]
        public string ConfigPath { get; set; }
    }

    [XmlRoot(ElementName = "doc")]
    public class ConfigRoot
    {
        [XmlElement(ElementName = "server")]
        public _Server Server { get; set; }
        [XmlElement(ElementName = "solr")]
        public _Solr Solr { get; set; }
        [XmlElement(ElementName = "zookeeper")]
        public _Zookeeper Zookeeper { get; set; }
    }

}
