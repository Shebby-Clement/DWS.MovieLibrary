using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DWS.MovieLibrary.Web.Controllers.HttpClient
{
    public interface IApiResponse
    {
        ApiError Error { get; }
    }
}
