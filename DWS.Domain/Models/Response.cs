using System;
using System.Collections.Generic;
using System.Text;

namespace DWS.MovieLibrary.Domain.Models
{
    public class Response<T> where T : class
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; } = default(T);
    }
}
