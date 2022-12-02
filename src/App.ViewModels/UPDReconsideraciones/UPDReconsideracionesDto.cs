using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModels.UPDReconsideraciones
{
    public class UPDReconsideracionesDto
    {
    }

    public class setActualizarMedEval
    {
        public decimal N_AMED_ICANTAPROBADAODSIS { get; set; }
        public string V_AMED_V_MOTIVO_CAMBIO { get; set; }
        public string V_AMED_IDUSUARIOACT { get; set; }
        public decimal N_AMED_IDNUMREG { get; set; }
    }
    public class setActualizarApoEval
    {
        public decimal N_AAPO_ICANTAPROBADAODSIS { get; set; }
        public string V_AAPO_V_MOTIVO_CAMBIO { get; set; }
        public string V_AAPO_IDUSUARIOACT { get; set; }
        public decimal N_AAPO_IDNUMREG { get; set; }
    }
    public class setActualizarInsEval
    {
        public decimal N_AINS_ICANTIDADAPROBADAODSIS { get; set; }
        public string V_AINS_V_MOTIVO_CAMBIO { get; set; }
        public string V_AINS_IDUSUARIOACT { get; set; }
        public decimal N_AINS_IDNUMREG { get; set; }
    }
    public class setPeriodoUpd
    {
        public int? idperiodo { get; set; }
        public string? periodo { get; set; }
        public string? mes { get; set; }
        public string? fecini { get; set; }
        public string? fecfin { get; set; }
        public string? escierre { get; set; }
        public string? motivo { get; set; }
    }
}
