using SolrTool.Models.SolrModels;
using SolrTool.Models.SolrModels.SolrCollection;
using SolrTool.Models.SolrModels.SolrCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SolrTool
{
    public class SolrHttpOperation
    {
        private static Lazy<HttpClient> _client;
        private static Logger logger = Logger.Create(LogType.INFO);

        static SolrHttpOperation()
        {
            Action<object, SolrHttpClientEventArgs> beforeRequest = (s, e) =>
            {
                //add a parameter to avoid cache
                e.RequestMessage.RequestUri = new Uri(e.RequestMessage.RequestUri.ToString() + $"&_={DateTime.Now.ToString("mmssffffff")}");
                var url = e.RequestMessage.RequestUri.ToString();
                logger.Log($"request url:[{url}]");
            };

            Action<object, SolrHttpClientEventArgs> requestComplete = (s, e) =>
            {
                var url = e.RequestMessage.RequestUri.ToString();
                logger.Log($"finished request url:[{url}], response content length: [{e.ResponseMsg.Content.ReadAsStringAsync().Result.Length}]");
            };

            _client = new Lazy<HttpClient>(() => {
                return SolrHttpClient.Create(
                    AppGlobalConfigs.AppConfig.Solr.BaseUrl,
                    AppGlobalConfigs.AppConfig.Solr.Auth.Username,
                    AppGlobalConfigs.AppConfig.Solr.Auth.Password,
                    beforeRequest,
                    requestComplete);
            });
        }

        public static async Task<SolrCore> GetCores()
        {
            var client = _client.Value;
            var cores = await client.GetStringAsync(SolrGlobalConfigs.CORES);
            return Deserialize<SolrCore>(cores);
        }

        public static async Task<SolrCollection> GetCollection()
        {
            var client = _client.Value;
            var collections = await client.GetStringAsync(SolrGlobalConfigs.COLLECTIONS);
            return Deserialize<SolrCollection>(collections);
        }

        public static async Task<SolrFile> GetFiles(string name)
        {
            var client = _client.Value;
            var files = await client.GetStringAsync(string.Format(SolrGlobalConfigs.FILES, name));
            return Deserialize<SolrFile>(files);
        }

        public static async Task<string> GetFileContent(string indexName,string fileName)
        {
            var client = _client.Value;
            var content = await client.GetStringAsync(string.Format(SolrGlobalConfigs.FILEINFO, indexName, fileName));
            return content;
        }

        public static async Task<SolrFile> GetDirFiles(string name, string dir)
        {
            var client = _client.Value;
            var files = await client.GetStringAsync(string.Format(SolrGlobalConfigs.FILES + "&file={1}", name, dir));
            return Deserialize<SolrFile>(files);
        }

        public static async Task<string> CreateConfig(string name, string fileName)
        {
            var client = _client.Value;
            if (!File.Exists(fileName))
            {
                throw new IOException($"file:[{fileName}] not found");
            }

            var sc = new ByteArrayContent(File.ReadAllBytes(fileName));
            var resp = await client.PostAsync(string.Format(SolrGlobalConfigs.UPLOAD_FILE, name), sc);
            return resp.Content.ReadAsStringAsync().Result;
        }

        private static T Deserialize<T>(string xml) where T : class
        {
            var xmlSer = new XmlSerializer(typeof(T));
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            using (var xmlReader = XmlReader.Create(ms))
            {
                var result = xmlSer.Deserialize(xmlReader) as T;

                return result;
            }
        }
    }
}
