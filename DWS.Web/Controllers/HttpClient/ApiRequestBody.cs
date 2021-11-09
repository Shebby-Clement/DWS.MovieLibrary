using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace DWS.MovieLibrary.Web.Controllers.HttpClient
{
    public class ApiRequestBody<T> : IApiRequest
    {
        private readonly T body;

        public ApiRequestBody(string backendUrl, string methodName, T body)
        {
            BackendUrl = backendUrl;
            MethodName = methodName;
            this.body = body;
            Headers = new Dictionary<string, string>();
        }

        public Dictionary<string, string> Headers { get; }

        public string MethodName { get; }

        public string BackendUrl { get; }

        public HttpRequestMessage GetHttpRequestMessage()
        {
            var requestUri = new Uri(string.Concat(BackendUrl, "/", MethodName));

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);

            if (body != null)
            {
                ByteArrayContent streamContent;

                using (var stream = new MemoryStream())
                {
                    var parameterType = body.GetType();
                    var settings = new DataContractJsonSerializerSettings
                    {
                        DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
                    };

                    var seralizer = new DataContractJsonSerializer(parameterType);

                    seralizer.WriteObject(stream, body);
                    streamContent = new ByteArrayContent(stream.ToArray());
                    streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    stream.Position = 0;
                    var reader = new StreamReader(stream);
                    var text = reader.ReadToEnd();
                    reader.Dispose();
                }

                requestMessage.Content = streamContent;
            }

            foreach (var header in Headers)
            {
                requestMessage.Headers.Add(header.Key, header.Value);
            }

            return requestMessage;
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
    }
}
