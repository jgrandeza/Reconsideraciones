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

	[Table("A_LUGARATENCION"), Schema("SIASIS")]
	public class A_LUGARATENCION
    {
        [Key]
		public string LUG_IDLUGAR { get; set; }
		public string? LUG_DESCRIPCION { get; set; }
		public string? LUG_IDUSUARIOCREA { get; set; }
		public DateTime? LUG_FECCREA { get; set; }
		public string? LUG_IDUSUARIOACT { get; set; }
		public DateTime? LUG_FECACT { get; set; }
		public string? LUG_ESTADO { get; set; }
		public decimal? LUG_N_IDLUGAR { get; set; }
	}
}
