using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModels.SolicitudRecon
{
    public class ResumenReconsDto
    {
    }
	public class setResumenReconsDto
    {
        public string V_IDEESS { get; set; }
        public string V_PERIODO { get; set; }
		public decimal V_FILTROFUA { get; set; }
        public string V_FUA { get; set; }

    }
    public class getResumenReconsDto
	{
		public int? RREC_IDNUMREG { get; set; }
		public string? FUA { get; set; }

		public string? RREC_ESNUEVOFORMATO { get; set; }
		public string? RREC_IDEESS { get; set; }

		public string? DESC_EESS { get; set; }
		public string? RREC_IDCOMPONENTE { get; set; }
		public string? DESC_COMPO { get; set; }
		
		public DateTime? RREC_FECATENCION { get; set; }
		public string? RREC_IDSERVICIO { get; set; }
        public string? DESC_SERVICIO { get; set; }
        public string? RREC_OBSERVACION { get; set; }
		public string? RREC_ESTADO { get; set; }
		public string? RREC_PERIODO { get; set; }
		public string? RREC_MES { get; set; }
		public string? RREC_UE { get; set; }
		public string? RREC_MODPAGO { get; set; }
		public string? RREC_RM { get; set; }
		public string? RREC_ODSIS { get; set; }
		public decimal? RREC_VALOR_BRUTO { get; set; }
		public decimal? RREC_VALOR_NETO { get; set; }
		public decimal? RREC_IDMECANISMOPAGO { get; set; }
		public decimal? RREC_OBSPSA { get; set; }
		public decimal? RREC_OBSSME { get; set; }
		public decimal? RREC_N_ESOBSTOTAL { get; set; }
		public decimal? RREC_TIPO_PAGO_PCPP { get; set; }
		public decimal? RREC_N_IDPERIODOVAL { get; set; }
		public decimal? RREC_N_VBTOTAL { get; set; }
		public decimal? RREC_N_VBCPMS { get; set; }
		public decimal? RREC_N_VBSER { get; set; }
		public decimal? RREC_N_VBINS { get; set; }
		public decimal? RREC_N_VBMED { get; set; }
		public decimal? RREC_N_ESTADO { get; set; }
		public decimal? RREC_N_IDTIPOFINANCIAMIENTO { get; set; }
		public decimal? RREC_N_IDTIPCONVENIO { get; set; }
		public decimal? RREC_N_VNTOTAL { get; set; }
		public decimal? RREC_N_VNCPMS { get; set; }
		public decimal? RREC_N_VNSER { get; set; }
		public decimal? RREC_N_VNINS { get; set; }
		public decimal? RREC_N_VNMED { get; set; }
		public string? RREC_N_PERIODOPROD { get; set; }
		public decimal? RREC_N_IDTIPOPAGO { get; set; }
		public decimal? RREC_N_IDUEJECUTORA { get; set; }
		public decimal? RREC_V_IDODSIS { get; set; }
		public decimal? RREC_N_IDMACROREGION { get; set; }
		public string? RREC_C_CERRADO { get; set; }
		public string? RREC_V_FISSAL { get; set; }
		public string? RREC_V_CAPITA { get; set; }
		public string? RREC_V_TIPO_PAGO { get; set; }
		public decimal? RREC_ID_ESTADOREC { get; set; }
        public string? DESC_ESTOBSE { get; set; }
		public string? RREC_C_ESTADEVAL { get; set; }

	}
}
