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
	[Table("A_COMPONENTES"), Schema ("SIASIS")]
	public class A_COMPONENTES
    {
        [Key]
		public string COM_IDCOMPONENTE { get; set; }
		public string? COM_DESCRIPCION { get; set; }
		public string? COM_IDUSUARIOCREA { get; set; }
		public DateTime? COM_FECCREA { get; set; }
		public string? COM_IDUSUARIOACT { get; set; }
		public DateTime? COM_FECACT { get; set; }
		public string? COM_ESTADO { get; set; }
		public string? COM_ESATE { get; set; }
		public string? COM_ESPSE { get; set; }
		public decimal? COMP_V_USOSEPELIO { get; set; }
		public string? COMP_V_DESCRIPCIONCORTA { get; set; }
	}
}
