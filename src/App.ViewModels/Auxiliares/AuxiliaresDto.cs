using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModels.Auxiliares
{
    public class AuxiliaresDto
    {
    }
    public class getComponentes
    {
        public int COM_IDCOMPONENTE { get; set; }
        public string? COM_DESCRIPCION { get; set; }
        public int? COM_ESTADO { get; set; }
        public string? COM_ESATE { get; set; }
        public string? COM_ESPSE { get; set; }
        public string? COMP_V_USOSEPELIO { get; set; }
        public string? COMP_V_DESCRIPCIONCORTA { get; set; }

	
    }
    public class getTipoDocIdentidad
    {
        public int? IDE_CODDOCIDENTIDAD { get; set; }
        public string? IDE_CDESCRIPCION { get; set; }
        public int? IDE_ESTADO { get; set; }
        public int? IDE_IDSUNASA { get; set; }
        public string? IDE_V_ABREVIATURA { get; set; }
        public int? IDE_B_ESTADONRUS { get; set; }
        public string? IDE_C_EQUIVALENTESUNAT { get; set; }
        public int? IDEN_N_CANTIDADIGITOSMAX { get; set; }
        public int? IDEN_B_FLAGALFANUMERICO { get; set; }
        public int? IDEN_B_FLAGUSOSEPELIO { get; set; }
        public int? IDEN_N_FLAGCANTIDADIGITOSFIJO { get; set; }
        public int? IDEN_B_FLAGUSOLIBRORECLAMACION { get; set; }	
    }

    public class getSexo
    {
        public int SEX_IDSEXO { get; set; }
        public string? SEX_DESCRIPCION { get; set; }       
	
    }
    public class getTipoAtencion
    {
        public int? TAT_CODATE { get; set; }
        public string? TAT_NOMBRE { get; set; }
        public string? TAT_ESTAAFILIACION { get; set; }
        public int? TAT_ESTADO { get; set; }
    }

    public class getLugarAtencion
    {
        public int LUG_IDLUGAR { get; set; }
        public string LUG_DESCRIPCION { get; set; }
        public int LUG_ESTADO { get; set; }
 
    }

    public class getCondicionMaterna
    {
        public int CDM_IDCONDICION { get; set; }
        public string? CDM_NOMBRE { get; set; }
        public int? CDM_ESTADO { get; set; }
	
    }
    public class getTipoDiagnostico
    {
        public int TDA_TIPODIA { get; set; }
        public string? TDA_CDESCRIPCION { get; set; }
        public string? TDA_CNOMCORTO   { get; set; }
        public int? TDA_ESTADO { get; set; }

    }
    public class getTipoModalidadAte
    {
        public int MOD_IDMODALIDAD { get; set; }
        public string? MOD_DESCRIPCION { get; set; }
    }
    public class getOrigenPersonal
    {
        public int OPE_IDORIGENPERSONAL { get; set; }
        public string? OPE_DESCRIPCION { get; set; }
    }

}
