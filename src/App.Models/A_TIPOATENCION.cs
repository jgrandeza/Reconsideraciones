using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
	[Table("A_TIPOATENCION"), Schema("SIASIS")]
	public class A_TIPOATENCION
    {
        [Key]
		public string TAT_CODATE { get; set; }
		public string? TAT_NOMBRE { get; set; }
		public string? TAT_ESTAAFILIACION { get; set; }
		public DateTime? TAT_FECCREA { get; set; }
		public string? TAT_IDUSUARIOCREA { get; set; }
		public DateTime? TAT_FECACT { get; set; }
		public string? TAT_IDUSUARIOACT { get; set; }
		public string? TAT_ESTADO { get; set; }
		public decimal? TAT_N_TIPOATENCION_X { get; set; }
	}
}
