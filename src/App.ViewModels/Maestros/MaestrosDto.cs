using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModels.Maestros
{
    public class MaestrosDto
    {
    }
    public class getServicios
    {
		public int SER_IDSERVICIO { get; set; }
		public string? SER_NOMBRE { get; set; }
		public string? SER_NOMBREANTERIOR { get; set; }
		public string? SER_UCI { get; set; }
		public string? SER_HOSP { get; set; }
		public string? SER_MED { get; set; }
		public string? SER_APO { get; set; }
		public string? SER_SEXO { get; set; }
		public decimal? SER_EDADMIN { get; set; }
		public decimal? SER_EDADMAX { get; set; }
		public string? SER_SUBGRUPO { get; set; }
		public string? SER_GRUPO { get; set; }
		public string? SER_IDTIPOSERVICIO { get; set; }
		public string? SER_ESCRECER { get; set; }
		public string? SER_TIPOSERVICIO { get; set; }
		public string? SER_BYPASS { get; set; }
		public string? SER_SITUACION { get; set; }
		public string? SER_ESTADO { get; set; }
		public string? SER_UMBRAL { get; set; }
		public string? SER_EQUIVALENTE { get; set; }
		public decimal? SER_IDSERVICIOS { get; set; }
	}

	public class getEESSxID
    {

		public int PRE_DISA { get; set; }
		public int UNDEJE { get; set; }
		public string? NOMBRE { get; set; }
        public string? ESAFILIA { get; set; }
        public int IDCAT { get; set; }
        public string? ABRVCAT { get; set; }
        public string? CATDESC { get; set; }
        public string? NIVELEESS { get; set; }
        public string? UNDEJEC { get; set; }
        public string? ODSIS { get; set; }
        public string? AMBITO { get; set; }
        public string? UCI { get; set; }
        public string? DESEJEC { get; set; }

    }
	public class getPersonalSaludxID
    {

        public string? DNI { get; set; }
        public string? NombrePersonal { get; set; }
        public string? Colegiatura { get; set; }
        public string? idTipoPersonal { get; set; }
        public string? TipoPersonalDes { get; set; }
        public string? idEspecialidad { get; set; }
        public string? EspecialidadNombre { get; set; }
        public string? codConsistencia { get; set; }
        public string? tipoDocumento { get; set; }
        public string? ProcesoOk { get; set; }
        public string? cespecialidad { get; set; }
    }
    public class GetDiagnosticoPorID
    {
		public string? C10_CODDIA { get; set; }
		public string? C10_NOMBRE { get; set; }
		public string? C10_EXCLUIDO { get; set; }
		public string C10_ESTADO { get; set; }
		public string C10_PEAS { get; set; }

	}
	public class GetApoDiagPorID
    {
        public int APO_CODAPO { get; set; }
        public string? APO_NOMBRE { get; set; }
        public string? APO_CODGRU { get; set; }
        public string? TAPO_NOMBRE { get; set; }
        public string? APO_CODSUB { get; set; }
        public string? SUB_NOMBRE { get; set; }
        public int? APO_ID { get; set; }
        public decimal? APO_COSTO { get; set; }
        public int? APO_ESTADO { get; set; }

    }

    public class setEESSXUE
    {
        public string P_V_DISA { get; set; }
        public string P_V_UE { get; set; }
        public string P_V_IDEESS { get; set; }
        public string P_V_TIPO { get; set; }

    }
    public class getEESSXUE
    {
        public string IDEESS { get; set; }
        public string ESTABLECIMIENTO { get; set; }

        public string IDDISA { get; set; }
        public string DISA { get; set; }
        public string IDEJECUTORA { get; set; }
        public string EJECUTORA { get; set; }

    }
}
