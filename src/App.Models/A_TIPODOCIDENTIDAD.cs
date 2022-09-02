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
    [Table("A_TIPODOCIDENTIDAD"), Schema("SIASIS")]
    public class A_TIPODOCIDENTIDAD
    {
        [Key]
		public string IDE_CODDOCIDENTIDAD { get; set; }
		public string? IDE_CDESCRIPCION { get; set; }
		public string? IDE_ESTADO { get; set; }
		public string? IDE_IDSUNASA { get; set; }
		public string? IDE_V_ABREVIATURA { get; set; }
		public decimal? IDE_B_ESTADONRUS { get; set; }
		public string? IDE_C_EQUIVALENTESUNAT { get; set; }
		public decimal? IDEN_N_CANTIDADIGITOSMAX { get; set; }
		public string? IDEN_B_FLAGALFANUMERICO { get; set; }
		public decimal? IDEN_B_FLAGUSOSEPELIO { get; set; }
		public decimal? IDEN_N_FLAGCANTIDADIGITOSFIJO { get; set; }
		public decimal? IDEN_B_FLAGUSOLIBRORECLAMACION { get; set; }
		public string? IDE_V_USUCREA { get; set; }
		public DateTime? IDE_D_FECCREA { get; set; }
		public string? IDE_V_USUACT { get; set; }
		public DateTime? IDE_D_FECACT { get; set; }
		public string? IDE_V_OBSERVACION { get; set; }
	}
}
