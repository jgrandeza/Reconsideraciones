using System;

namespace App.Tools
{
    public class Generics
    {
        public static string NameFile()
        {
            return "FileUpload_" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;
        }
        public static string CodigoForm(int id_solicitud)
        {
            return string.Concat(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond, id_solicitud);
        }
    }
}
