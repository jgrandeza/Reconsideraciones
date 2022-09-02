using App.Tools.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace App.Tools
{
    public class ImagenesHelper
    {

        public static async Task<string> UploadAsync(string path, IFormFile file, int idUser)
        {
            string strFile = "";
            try
            {
                if (file != null && file.Length > 0)
                {
                    strFile = Generics.NameFile() + "_U_" + idUser.ToString() + System.IO.Path.GetExtension(file.FileName);
                    using (var stream = new FileStream(Path.Combine(path, strFile), FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        
                    }
                }
            }
            catch (Exception ex)
            {
                strFile = "";
            }
            return strFile;
        }

        public static async Task<string> UploadFileAsync(string path, IFormFile file)
        {
            string strFile = "";
            try
            {
                if (file != null && file.Length > 0)
                {
                    strFile = Guid.NewGuid() + System.IO.Path.GetExtension(file.FileName);
                    using (var stream = new FileStream(Path.Combine(path, strFile), FileMode.Create))
                    {
                        await file.CopyToAsync(stream);

                    }
                }
            }
            catch (Exception ex)
            {
                strFile = "";
            }
            return strFile;
        }


        //public static async Task<bool> ResizeSaveImage(string pathSource, string pathDestino, uint width, uint height, IEmailSender _emailSender)
        //{
        //    try
        //    {
        //        byte[] image = System.IO.File.ReadAllBytes(pathSource);
        //        image = await ResizeImageBytes(image, width, height, _emailSender);
        //        System.IO.File.WriteAllBytes(pathDestino, image);
        //    }
        //    catch (Exception ex)
        //    {
        //        await _emailSender.SendEmailAsync("jiestrada@live.com.mx", "Error La Pesca en Línea ", ex.ToString());
        //        return false;
        //    }
        //    return true;
        //}

        //protected static async Task<byte[]> ResizeImageBytes(byte[] imageData, uint? desiredWidth, uint? desiredHeight, IEmailSender _emailSender)
        //{
        //    try
        //    {
        //        using (var job = new ImageJob())
        //        {
        //            var res = await job.Decode(imageData).ConstrainWithin(desiredWidth, desiredHeight)
        //                .EncodeToBytes(new LibJpegTurboEncoder()).Finish().InProcessAsync();
        //            var bytes = res.First.TryGetBytes();
        //            return bytes.HasValue ? bytes.Value.Array : new byte[] { };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        await _emailSender.SendEmailAsync("jiestrada@live.com.mx", "Error La Pesca en Línea ", ex.ToString());
        //        return null;
        //    }
        //}

    }
}
