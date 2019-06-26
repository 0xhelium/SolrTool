using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SolrTool
{
    public class SolrHttpClient
    {
        private static object _root = new object();
        private static HttpClient _client;

        public static Action<object, SolrHttpClientEventArgs> OnBeforeRequest = null;
        public static Action<object, SolrHttpClientEventArgs> OnRequestComplete = null;

        public static HttpClient Create(
            string baseUrl, 
            string userName = "", 
            string password = "", 
            Action<object, SolrHttpClientEventArgs> beforeRequest = null,
            Action<object, SolrHttpClientEventArgs> requestComplete = null)
        {
            if (beforeRequest != null)
                OnBeforeRequest = beforeRequest;
            if (requestComplete != null)
                OnRequestComplete = requestComplete;

            if (_client == null)
            {
                lock (_root)
                {
                    if (_client == null)
                    {
                        lock (_root)
                        {
                            var handler = new SolrHttpClientReqRespHandler(new HttpClientHandler());
                            handler.BeforeHttpRequest += (s, e) => OnBeforeRequest?.Invoke(s, e);
                            handler.HttpReceiveData += (s, e) => OnRequestComplete?.Invoke(s, e);
                                                       
                            _client = new HttpClient(handler);
                            if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password))
                            {
                                var basicAuth = Convert.ToBase64String(Encoding.ASCII.GetBytes(userName + ":" + password));
                                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("basic", basicAuth);
                            }
                            
                            _client.Timeout = TimeSpan.FromMinutes(30);
                            _client.BaseAddress = new Uri(baseUrl);
                        }
                    }
                }
            }
            
            return _client;
        }

    }


    public class SolrHttpClientReqRespHandler : DelegatingHandler
    {
        public SolrHttpClientReqRespHandler(HttpClientHandler innerHandler)
        {
            InnerHandler = innerHandler;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            OnBeforeHttpRequest(request, new SolrHttpClientEventArgs { RequestMessage = request });

            var response = await base.SendAsync(request, cancellationToken);

            OnHttpReceiveData(request, new SolrHttpClientEventArgs { RequestMessage = request, ResponseMsg = response });

            return response;
        }

        public event EventHandler<SolrHttpClientEventArgs> HttpReceiveData;

        public event EventHandler<SolrHttpClientEventArgs> BeforeHttpRequest;

        protected internal virtual void OnHttpReceiveData(HttpRequestMessage request, SolrHttpClientEventArgs e)
        {
            HttpReceiveData?.Invoke(request, e);
        }

        protected internal virtual void OnBeforeHttpRequest(HttpRequestMessage request, SolrHttpClientEventArgs e)
        {
            BeforeHttpRequest?.Invoke(request, e);
        }
    }

    public class SolrHttpClientEventArgs : EventArgs
    {
        public HttpRequestMessage RequestMessage { get; set; }

        public HttpResponseMessage ResponseMsg { get; set; }
    }
}
