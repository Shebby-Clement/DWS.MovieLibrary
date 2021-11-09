using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DWS.MovieLibrary.Web.Controllers.HttpClient
{
    public class ApiError
    {
        public ApiError(int statusCode, string reasonPhrase)
        {
            StatusCode = statusCode;
            ReasonPhrase = reasonPhrase;
        }

        public int StatusCode { get; }
        public string ReasonPhrase { get; }
    }
}
