using Newtonsoft.Json;
using DWS.MovieLibrary.Web.Controllers.HttpClient;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DWS.MovieLibrary.Web.Controllers.HttpClient
{
    public class ApiClient : IApiClient
    {
        private readonly System.Net.Http.HttpClient _client;
        public ApiClient()
        {
            _client = _client ?? new System.Net.Http.HttpClient();
        }

        private Uri GetBaseUrl(string baseUrl)
        {
            return _client.BaseAddress ?? new Uri(baseUrl);
        }

        public async Task<ApiResponse<T>> Create<T>(string baseUrl, string method, T model)
        {
            _client.BaseAddress = GetBaseUrl(baseUrl);

            var postTask = await _client.PostAsJsonAsync(method, model);

            if (!postTask.IsSuccessStatusCode)
            {
                return new ApiResponse<T>(default, new ApiError((int)postTask.StatusCode, postTask.ReasonPhrase));
            }

            return new ApiResponse<T>(model, null);
        }

        public async Task<ApiResponse<T>> Delete<T>(string baseurl, string method, string id)
        {
            _client.BaseAddress = GetBaseUrl(baseurl);

            //HTTP DELETE
            var deleteTask = await _client.DeleteAsync($"{method}/" + id.ToString());

            if (!deleteTask.IsSuccessStatusCode)
            {
                return new ApiResponse<T>(default, new ApiError((int)deleteTask.StatusCode, deleteTask.ReasonPhrase));
            }
            return new ApiResponse<T>(default, null);
        }

        public async Task<ApiResponse<T>> Get<T>(string baseUrl, string method)
        {
            _client.BaseAddress = GetBaseUrl(baseUrl);

            var responseTask = await _client.GetAsync(method);

            var result = responseTask;

            if (!result.IsSuccessStatusCode)
            {
                return new ApiResponse<T>(default, new ApiError((int)result.StatusCode, result.ReasonPhrase));
            }
            var readTask = await result.Content.ReadAsAsync<T>();

            return new ApiResponse<T>(readTask, null);
        }

        public async Task<ApiResponse<T>> Update<T>(string baseUrl, string method, T model)
        {
            _client.BaseAddress = GetBaseUrl(baseUrl);

            var putTask = await _client.PutAsJsonAsync(method, model);

            if (!putTask.IsSuccessStatusCode)
            {
                return new ApiResponse<T>(default, new ApiError((int)putTask.StatusCode, putTask.ReasonPhrase));
            }

            return new ApiResponse<T>(model, null);
        }

    }
}
