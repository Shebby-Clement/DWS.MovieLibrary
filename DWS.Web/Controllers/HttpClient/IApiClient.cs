using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DWS.MovieLibrary.Web.Controllers.HttpClient
{
    public interface IApiClient
    {
        Task<ApiResponse<T>> Get<T>(string baseUrl, string method);
        Task<ApiResponse<T>> Update<T>(string baseUrl, string method, T model);
        Task<ApiResponse<T>> Delete<T>(string baseurl, string method, string id);
        Task<ApiResponse<T>> Create<T>(string baseUrl, string method, T model);
        //Task<ApiResponse<T>> GetResponse<T>(ApiParameters parameters, HttpMethod httpMethod = null);
        //Task<ApiResponse<T>> PostResponse<K, T>(ApiRequestBody<K> parameters, HttpMethod httpMethod = null);
        //Task<ApiResponse<T>> PostPlainResponse<T>(ApiRequestPlain parameters, HttpMethod httpMethod = null);
    }
}
