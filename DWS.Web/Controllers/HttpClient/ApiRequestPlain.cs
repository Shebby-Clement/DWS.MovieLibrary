using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DWS.MovieLibrary.Web.Controllers.HttpClient
{
    public class ApiRequestPlain : IApiRequest
    {
        public ApiRequestPlain(string backendUrl, string methodName)
        {
            BackendUrl = backendUrl;
            MethodName = methodName;
            Plains = new Dictionary<string, string>();
            Headers = new Dictionary<string, string>();
        }

        public Dictionary<string, string> Plains { get; }

        public Dictionary<string, string> Headers { get; }

        public string MethodName { get; }
        public string BackendUrl { get; }

        public HttpRequestMessage GetHttpRequestMessage()
        {
            var requestUri = new Uri(string.Concat(BackendUrl, "/", MethodName));

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);

            ByteArrayContent streamContent;

            var query = new StringContent(GetEncodedUrlPlains(), Encoding.UTF8);

            using (var stream = new MemoryStream())
            {
                streamContent = query;
                streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            }

            requestMessage.Content = streamContent;

            foreach (var header in Headers)
            {
                requestMessage.Headers.Add(header.Key, header.Value);
            }

            return requestMessage;
        }

        public void AddPlain(string name, object value)
        {
            Plains.Add(name, value.ToString());
        }

        public string GetEncodedUrlPlains()
        {
            return string.Join("&", Plains.Select(x => string.Concat(x.Key, "=", Uri.EscapeDataString(x.Value))));
        }
    }
}
