using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DWS.MovieLibrary.Web.Controllers.HttpClient
{
    public class ApiParameters : IApiRequest
    {
        public ApiParameters(string backendUrl, string methodName)
        {
            BackendUrl = backendUrl;
            MethodName = methodName;
            Parameters = new Dictionary<string, string>();
            Headers = new Dictionary<string, string>();
        }

        public Dictionary<string, string> Parameters { get; }

        public Dictionary<string, string> Headers { get; }

        public string MethodName { get; }

        public string BackendUrl { get; }

        public HttpRequestMessage GetHttpRequestMessage()
        {
            var requestUri = new Uri(string.Concat(BackendUrl, "/", MethodName, "?", GetEncodedUrlParametrs())
                .TrimEnd('?'));

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);

            foreach (var header in Headers)
            {
                requestMessage.Headers.Add(header.Key, header.Value);
            }

            return requestMessage;
        }

        public void AddParameter(string name, object value)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Name parameter can not be null.");
            }

            if (value == null)
            {
                throw new ArgumentNullException("Value parameter can not be null.");
            }

            Parameters.Add(name, value.ToString());
        }

        public void AddHeader(string name, object value)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Name parameter can not be null.");
            }

            if (value == null)
            {
                throw new ArgumentNullException("Value parameter can not be null.");
            }

            Headers.Add(name, value.ToString());
        }

        public string GetEncodedUrlParametrs()
        {
            var couples = new List<string>();

            foreach (var item in Parameters)
            {
                couples.Add(string.Concat(item.Key, "=", Uri.EscapeDataString(item.Value)));
            }

            return string.Join("&", couples);
        }
    }
}
