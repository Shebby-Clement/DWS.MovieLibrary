using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DWS.MovieLibrary.Web.Controllers.HttpClient
{
    public class ApiResponse<T> : IApiResponse
    {
        public ApiResponse(T result, ApiError error)
        {
            Result = result;
            Error = error;
        }

        public T Result { get; }

        /// <summary>
        ///     Sets HasError property to false if the Error property is not null
        /// </summary>
        public bool HasError => Error != null;

        public ApiError Error { get; }
    }
}
