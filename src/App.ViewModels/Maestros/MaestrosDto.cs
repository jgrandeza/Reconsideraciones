using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModels.Maestros
{
    public class MaestrosDto
    {
    }
    public class getServicios
    {
		public int SER_IDSERVICIO { get; set; }
		public string? SER_NOMBRE { get; set; }
		public string? SER_NOMBREANTERIOR { get; set; }
		public string? SER_UCI { get; set; }
		public string? SER_HOSP { get; set; }
		public string? SER_MED { get; set; }
		public string? SER_APO { get; set; }
		public string? SER_SEXO { get; set; }
		public decimal? SER_EDADMIN { get; set; }
		public decimal? SER_EDADMAX { get; set; }
		public string? SER_SUBGRUPO { get; set; }
		public string? SER_GRUPO { get; set; }
		public string? SER_IDTIPOSERVICIO { get; set; }
		public string? SER_ESCRECER { get; set; }
		public string? SER_TIPOSERVICIO { get; set; }
		public string? SER_BYPASS { get; set; }
		public string? SER_SITUACION { get; set; }
		public string? SER_ESTADO { get; set; }
		public string? SER_UMBRAL { get; set; }
		public string? SER_EQUIVALENTE { get; set; }
		public decimal? SER_IDSERVICIOS { get; set; }
	}
}
