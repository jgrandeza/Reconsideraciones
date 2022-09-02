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
    [Table("A_CONDICIONMATERNA"), Schema("SIASIS")]
    public class A_CONDICIONMATERNA
    {
        [Key]
        public string CDM_IDCONDICION { get; set; }
        public string? CDM_NOMBRE { get; set; }
        public string? CDM_ESTADO { get; set; }
    }
}
