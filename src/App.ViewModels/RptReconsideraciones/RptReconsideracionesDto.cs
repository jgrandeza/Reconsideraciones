using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModels.RptReconsideraciones
{
    public class RptReconsideracionesDto
    {
    }
    public class SetRptAtenciones
    {
        public string? P_V_PERIODO { get; set; }
        public string? P_V_MES { get; set; }
        public string? P_V_DISA { get; set; }
        public string? P_V_UEJEC { get; set; }
        public string? P_V_ESTABLECIMIENTO { get; set; }
        public string? P_V_ESTADO { get; set; }
        public string? P_V_TIPO { get; set; }

    }
    public class GetRptAtenciones
    {
        public int ATE_IDNUMREG { get; set; }
        public string? EESS { get; set; }
        public string? PER_PROD { get; set;}
        public string? FEC_ATENCION { get; set; }
        public string? FUA_OBSERVADA { get; set; }
        public string? PACIENTE { get; set; }
        public string? HISTORIA { get; set; }
        public string? RM { get; set;}
        public string? COMPONENTE { get; set;}
        public string? SERVICIO { get; set;}
        public string? TIPO_PAGO { get;} 
        public string? DNI_PER_SALUD { get; set;}
        public string? NOMBRE_PER_SALUD { get; set; }
        public string? TIPO_PER_SALUD { get; set; }
        public string? TIPO_OBS { get; set; }
        public string? COSTO_OBS { get; set; }
        public string? USU_SOLICICITA { get; set; }
        public string? FEC_SOLICITUD { get; set; }
        public string? COSTO_SOL { get; set; }
        public string? COD_OBS { get; set; }
        public string? DETA_OBS { get; set; }
        public string? SUSTENTO { get; set; }
        public string? MOTIVO_SOL { get; set; }
        public string? FEC_EVALUA { get; set; }
        public string? USU_EVALUA { get; set; }
        public string? SUSTENTO_VALIDO { get; set; }
        public string? DET_VALIDACION { get; set; }
        public string? COSTO_EVAL { get; set; }
        public string? CRITERIO_RECHAZO { get; set; }
        public string? ESTADO { get; set; }
        public string? RESULTADO_EVAL { get; set; }

    }
}
