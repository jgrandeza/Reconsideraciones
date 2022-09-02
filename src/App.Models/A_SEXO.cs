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
    [Table("A_SEXO"), Schema("SIASIS")]
    public class A_SEXO
    {
        [Key]
		public string SEX_IDSEXO { get; set; }
		public string? SEX_DESCRIPCION { get; set; }
		public DateTime? SEX_FECCREA { get; set; }
		public DateTime? SEX_FECACT { get; set; }
		public string? SEX_IDUSUARIOCREA { get; set; }
		public string? SEX_IDUSUARIOACT { get; set; }
		public decimal? SEX_N_IDSEXO { get; set; }
	}
}
