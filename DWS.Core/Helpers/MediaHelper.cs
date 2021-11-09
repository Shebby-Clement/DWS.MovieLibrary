using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace DWS.MovieLibrary.Core.Helpers
{
    public class MediaHelper
    {

        #region Image
        public static string ImageToBase64(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                try
                {
                    string base64String;
                    using (Image image = Image.FromFile(path))
                    {
                        using (MemoryStream m = new MemoryStream())
                        {
                            image.Save(m, image.RawFormat);
                            byte[] imageBytes = m.ToArray();
                            base64String = Convert.ToBase64String(imageBytes);
                            return base64String;
                        }
                    }
                }
                catch (Exception error)
                {
                    throw error;
                }
            }
            return "";
        }
        public static string Base64ToImage(string base64String, string folderPath)
        {
            string imagePath = "";
            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64String);
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                ms.Write(imageBytes, 0, imageBytes.Length);
                Image image = Image.FromStream(ms, true);
                imagePath = $"~/{folderPath}/{MyExtensions.RandomNumberAppendTimeStamp()}.jpg";
                // image.Save(HttpContext.Current.Server.MapPath(imagePath));
            }
            catch (Exception error)
            {
                throw error;
            }

            return imagePath;
        }
        #endregion

        #region Video

        #endregion

        #region Audio

        #endregion
    }
}
