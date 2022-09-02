using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModels
{
    public class MenuDto
    {
    }
    public class MenuN1Dto
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int TipoMenuId { get; set; }
        public string? Icono { get; set; }
        public int Nivel { get; set; }
        public int Orden { get; set; }
        public string? Funcion { get; set; }
        public bool Estado { get; set; }

        public int? MenuNId { get; set; }
        public int? Indicador { get; set; }

        public ICollection<MenuN2Dto> N2 { get; set; }
    }
    public class MenuN2Dto
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int TipoMenuId { get; set; }
        public string? Icono { get; set; }
        public int Nivel { get; set; }
        public int Orden { get; set; }
        public string? Funcion { get; set; }
        public bool Estado { get; set; }

        public int? MenuNId { get; set; }
        public int? Indicador { get; set; }

        public ICollection<MenuN3Dto> N3 { get; set; }
    }
    public class MenuN3Dto
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int TipoMenuId { get; set; }
        public string? Icono { get; set; }
        public int Nivel { get; set; }
        public int Orden { get; set; }
        public string? Funcion { get; set; }
        public bool Estado { get; set; }

        public int? MenuNId { get; set; }
        public int? Indicador { get; set; }
    }
}
