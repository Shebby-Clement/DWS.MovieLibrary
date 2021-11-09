using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DWS.MovieLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static DWS.MovieLibrary.Domain.Models.ResultModel;

namespace DWS.MovieLibrary.Web.Controllers.Api
{
    public class BaseController : ControllerBase
    {
        
        public BaseController()
        {
           
        }

        

        #region Protected Members
        protected object DetailedException(Exception ex)
        {
            var errormessage = ex.Message;
            if (ex.InnerException != null)
            {
                errormessage = "\n\nException: " + GetInnerException(ex);
            }
            var result = new Result
            {
                status = new Status
                {
                    code = (int)HttpStatusCode.InternalServerError,
                    message = errormessage
                }
            };
            return result;
        }

        private string GetInnerException(Exception ex)
        {
            if (ex.InnerException != null)
            {
                return
                    $"{ex.InnerException.Message + "( \n " + ex.Message + " \n )"} > {GetInnerException(ex.InnerException)} ";
            }
            return string.Empty;
        }

     
        #endregion
    }
}
