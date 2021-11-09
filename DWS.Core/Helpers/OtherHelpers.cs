using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DWS.MovieLibrary.Core.Helpers
{
    public static class OtherHelpers
    {
        public static int GetRandomNumbers(int length = 4)
        {
            Random _random = new Random();
            string otp = _random.Next(0, 9999).ToString($"D{length.ToString()}");
            return int.Parse(otp);
        }

        private static Task<bool> UploadBlobToServer()
        {
            return Task.FromResult(false);
        }

        public static  string GetEnumValue<T>( int value) where T : Enum
        {

            try
            {
                var name = Enum.GetName(typeof(T), value);

                if ( string.IsNullOrEmpty(name))
                {
                    throw new InvalidOperationException();
                }

                return name;
            }
            catch (Exception)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
