using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModels.SolicitudRecon
{
    public class RespModSolicitudRecon
    {
    }
    public class GetPeriodosDISAEESS
    {
        public string? PERIODO { get; set; }
    }
    public class SetPeriodosDISAEESS
    {
        public string V_TIPO_CONSULTA { get; set; }
        public string V_DISA { get; set; }
        public string V_UE { get; set; }
        public string V_EESS { get; set; }
    }

    public class GetRangoPeriodoRec
    {
       public string RCRO_PERIODO { get; set; }
        public string RCRO_MES { get; set; }
        public string RCRO_PERATEINICIO { get; set; }
        public string RCRO_MESATEINICIO { get; set; }
        public string RCRO_PERATEFIN { get; set; }
        public string RCRO_MESATEFIN { get; set; }
        public string RCRO_FECHAINICIO { get; set; }
        public string RCRO_FECHAFIN { get; set; }
        public string RCRO_TEXTO { get; set; }
    }

    public class SetRangoPeriodoRec
    {
        public string? V_PERIODO { get; set; }
    }

    public class GetPeriodoProdAtc
    {
        public string PERIODO { get; set; }
    }

    public class GetFiltros
    {
        public string ID { get; set; }
        public string DESCRIPCION { get; set; }
    }

}
