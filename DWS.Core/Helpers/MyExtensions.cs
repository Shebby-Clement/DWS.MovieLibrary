using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DWS.MovieLibrary.Core.Helpers
{
    public static class MyExtensions
    {
        public static string RandomNumberAppendTimeStamp(string fileName = "")
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        public static void ExceptionHelper(this Exception e)
        {
            /// Send error via email. only in production
            /// logs to a file
            /// print to output window in debug mode
            /// 

            PrintToDebug(e);
        }

        private static void PrintToDebug(Exception ex)
        {
            Debug.WriteLine("Message: " + ex.Message);
            Debug.WriteLine("StackTrace: " + ex.StackTrace);
            Debug.WriteLine("InnerException: " + ex.InnerException?.Message);
        }       
    }
}
