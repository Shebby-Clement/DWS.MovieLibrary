using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DWS.MovieLibrary.Web.Controllers.HttpClient
{
    public interface IApiRequest
    {
        string MethodName { get; }

        string BackendUrl { get; }

        HttpRequestMessage GetHttpRequestMessage();
    }
}
