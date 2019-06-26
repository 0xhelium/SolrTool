using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SolrTool.Models.SolrModels.SolrCollection
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
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "arr")]
    public class Arr
    {
        [XmlElement(ElementName = "str")]
        public List<string> Str { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "response")]
    public class SolrCollection
    {
        [XmlElement(ElementName = "lst")]
        public Lst Lst { get; set; }
        [XmlElement(ElementName = "arr")]
        public Arr Arr { get; set; }
    }

}
