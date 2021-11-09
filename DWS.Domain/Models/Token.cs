using System;
using System.Collections.Generic;
using System.Text;

namespace DWS.MovieLibrary.Domain.Models
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime Expires { get; set; }
    }
}
