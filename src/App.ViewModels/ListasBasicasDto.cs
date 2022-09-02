using System;
using System.Collections.Generic;
using System.Text;

namespace App.ViewModels
{
    public class ListasBasicasDto
    {
    }

    public class ListUnidad
    {
        public int Id { get; set; }
        public string Placa { get; set; }
    }

    public class ListAreasDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }

    public class ListPerfilDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }

    public class ListConductor
    {
        public int Id { get; set; }
        public string NombreConductor { get; set; }
    }

    public class ListDetalleUnidad
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public string Flota { get; set; }
    }
}
