using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolrTool
{
    public class SolrGlobalConfigs
    {
        public static readonly string COLLECTIONS = "/solr/admin/collections?action=LIST&wt=xml";
        public static readonly string CORES = "/solr/admin/cores?wt=xml";
        public static readonly string FILES = "/solr/{0}/admin/file?wt=xml";
        public static readonly string FILEINFO = "/solr/{0}/admin/file?contentType=text/xml;charset=utf-8&file={1}&wt=xml";
        public static readonly string UPLOAD_FILE = "/solr/admin/configs?action=UPLOAD&name={0}";
    }
}
