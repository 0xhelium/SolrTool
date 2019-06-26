using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SolrTool.Models.SolrModels
{
    
    [XmlRoot(ElementName = "int")]
    public class Int
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "lst")]
    public class Lst
    {
        [XmlElement(ElementName = "int")]
        public List<Int> Int { get; set; }
        [XmlElement(ElementName = "bool")]
        public List<Bool> Bool { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "lst")]
        public List<Lst> Lsts { get; set; }
    }

    [XmlRoot(ElementName = "bool")]
    public class Bool
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "response")]
    public class SolrFile
    {
        [XmlElement(ElementName = "lst")]
        public List<Lst> Lst { get; set; }
    }
}
