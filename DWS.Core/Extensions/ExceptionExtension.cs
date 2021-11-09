using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DWS.MovieLibrary.Core.Extensions
{
    public static class ExceptionExtension
    {
        public static void LogError(this Exception e)
        {
            /// Send error via email. only in production
            /// logs to a file
            /// print to output window in debug mode
            /// log to external services like elmah

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
