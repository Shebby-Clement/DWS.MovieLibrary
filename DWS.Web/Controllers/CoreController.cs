using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DWS.MovieLibrary.Web.Controllers
{
    public class CoreController : Controller
    {
        public CoreController()
        {

        }
       protected string GetBaseuRL()
        {
            return $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
        }
    }
}
