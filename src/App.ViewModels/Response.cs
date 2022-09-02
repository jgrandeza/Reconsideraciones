using System;
using System.Collections.Generic;
using System.Text;

namespace App.ViewModels
{
    public class Response
    {

        public bool IsSuccess { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
        public object Result2 { get; set; }
        public string Url { get; set; }
        public string Funcion { get; set; }
        public int Id { get; set; }
        public string CodigoStr { get; set; }
        public string UrlTabla { get; set; }
        public int AccionInt { get; set; }

        public string DivTabla { get; set; }
        public string Html { get; set; }
        public int CodigoReq { get; set; }

    }
    public class MenuDinamico
    {
        public ICollection<SubMenu> MenuNav { get; set; }
    }
    public class SubMenu
    {
        public string MenuNId { get; set; }
        public string Descripcion { get; set; }
        public string TipoId { get; set; }
        public string Icono { get; set; }
        public string Orden { get; set; }
        public string Funcion { get; set; }
        public string nivel { get; set; }
        public string tableMenuNId { get; set; }
    }
}
