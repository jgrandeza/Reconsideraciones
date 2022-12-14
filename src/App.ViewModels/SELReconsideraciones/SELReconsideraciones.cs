using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModels.SELReconsideraciones
{
    public class SELReconsideraciones
    {
    }
    public class UPDAtencionesDiaDto
    {
        public string V_ADIA_CDX { get; set; }
        public string V_ADIA_CODDIA { get; set; }
        public string V_ADIA_TIPODIA { get; set; }
        public string V_ADIA_IDUSUARIOACT { get; set; }
        public string N_ADIA_IDNUMREG { get; set; }
    }
    public class getAtencionRecxID
    {
        public decimal ATE_IDNUMREG { get; set; }
        public string ATE_DISA { get; set; }
        public string ATE_LOTE { get; set; }
        public string ATE_NUMREGATE { get; set; }
        public string ATE_IDEESS { get; set; }
        public string ATE_ESREC { get; set; }
        public string ATE_DISAREC { get; set; }
        public string ATE_LOTEREC { get; set; }
        public string ATE_NUMREGATEREC { get; set; }
        public string ATE_IDCOMPONENTE { get; set; }
        public string ATE_CODSITUACIONAFIINS { get; set; }
        public string ATE_DISAAFIINS { get; set; }
        public string ATE_TIPOFORMATOAFIINS { get; set; }
        public string ATE_NUMREGAFIINS { get; set; }
        public string ATE_LOTEAFIINS { get; set; }
        public string ATE_CODINSTITUCION { get; set; }
        public string ATE_AUTOGENINSTITUCION { get; set; }
        public decimal ATE_IDPER { get; set; }
        public decimal ATE_EDAD { get; set; }
        public string ATE_IDGRUPOETAREO { get; set; }
        public string ATE_IDSEXO { get; set; }
        public decimal ATE_CODATE { get; set; }
        public string ATE_ESGESTANTE { get; set; }
        public string ATE_HISTORIACLINICA { get; set; }
        public decimal ATE_IDMODALIDAD { get; set; }
        public string ATE_NUMAUTORIZACION { get; set; }
        public decimal ATE_MONTO { get; set; }
        public DateTime ATE_FECATENCION { get; set; }
        public string ATE_HORATENCION { get; set; }
        public string ATE_IDEESSREFIRIO { get; set; }
        public string ATE_NROHOJAREFERENCIA { get; set; }
        public string ATE_IDSERVICIO { get; set; }
        public decimal ATE_IDORIGENPERSONAL { get; set; }
        public string ATE_IDLUGAR { get; set; }
        public string ATE_CODDESTINO { get; set; }
        public DateTime ATE_FECINGHOSP { get; set; }
        public DateTime ATE_FECALTAHOSP { get; set; }
        public string ATE_IDEESSCONTRAREFIERE { get; set; }
        public string ATE_NUMHOJACONTRAREFIERE { get; set; }
        public string ATE_DNIPERSONALSALUD { get; set; }
        public decimal ATE_IDTIPOPERSONALSALUD { get; set; }
        public string ATE_OBSERVACION { get; set; }
        public string ATE_IDUSUARIOCREA { get; set; }
        public DateTime ATE_FECBAJA { get; set; }
        public DateTime ATE_FECCREA { get; set; }
        public string ATE_IDUSUARIOACT { get; set; }
        public DateTime ATE_FECACT { get; set; }
        public string ATE_ESTADO { get; set; }
        public string ATE_ESTADOVALIDA { get; set; }
        public decimal ATE_NUMREGAFI { get; set; }
        public DateTime ATE_FECPARTO { get; set; }
        public string ATE_IDUBIGEO { get; set; }
        public string ATE_PERIODO { get; set; }
        public string ATE_MES { get; set; }
        public string ATE_TIPOTRASLADO { get; set; }
        public string ATE_TIPOTRASNPORTE { get; set; }
        public decimal ATE_COSTOTOTAL { get; set; }
        public string ATE_DISACOM { get; set; }
        public string ATE_LOTECOM { get; set; }
        public string ATE_NUMREGATECOM { get; set; }
        public decimal ATE_IDNUMREGCOM { get; set; }
        public decimal ATE_IDPPDD { get; set; }
        public string ATE_ESALTOCOSTO { get; set; }
        public string ATE_ESCIERRE { get; set; }
        public string ATE_UE { get; set; }
        public string ATE_MODPAGO { get; set; }
        public string ATE_TIPDIG { get; set; }
        public string ATE_APPAT { get; set; }
        public string ATE_APMAT { get; set; }
        public string ATE_PNOM { get; set; }
        public string ATE_SNOM { get; set; }
        public DateTime ATE_FECNAC { get; set; }
        public string ATE_AUTOGENERADO { get; set; }
        public string ATE_TIPODOCUMENTO { get; set; }
        public string ATE_DNI { get; set; }
        public string ATE_IDCATEGORIAEESS { get; set; }
        public decimal ATE_COSTOSERV { get; set; }
        public decimal ATE_COSTOMEDI { get; set; }
        public decimal ATE_COSTOPROC { get; set; }
        public decimal ATE_COSTOINSU { get; set; }
        public string ATE_OBS { get; set; }
        public string ATE_FLAG { get; set; }
        public string ATE_FORMATO { get; set; }
        public string ATE_CATEGOPAGO { get; set; }
        public string ATE_TIPOPERSALUD { get; set; }
        public string ATE_UBIGEOAFI { get; set; }
        public string ATE_TABLAAFI { get; set; }
        public string ATE_ESTPROG { get; set; }
        public string ATE_PAGO { get; set; }
        public decimal ATE_NUMREGESC { get; set; }
        public string ATE_ODSISRECEP { get; set; }
        public string ATE_PDIGRECEP { get; set; }
        public DateTime ATE_FECRECEP { get; set; }
        public string ATE_IDUSURECEP { get; set; }
        public decimal ATE_ENVIO { get; set; }
        public string ATE_AUTOGENERADO17 { get; set; }
        public string ATE_SEPAGO { get; set; }
        public string ATE_GRUPORIESGO { get; set; }
        public string ATE_MESPROD { get; set; }
        public string ATE_DOCUMENTO { get; set; }
        public DateTime ATE_FECACTDATOS { get; set; }
        public string ATE_USUARIO { get; set; }
        public string ATE_NTENVIOFINANCIAMIENTO { get; set; }
        public string ATE_MOTRECHAZONT { get; set; }
        public string ATE_USUARIORECHAZONT { get; set; }
        public string ATE_ESNATIMUERTO { get; set; }
        public decimal ATE_IDTARIFA { get; set; }
        public decimal ATE_FLAGTARIFA { get; set; }
        public decimal ATE_DESCMEDI { get; set; }
        public decimal ATE_DESCPROC { get; set; }
        public decimal ATE_DESCINSU { get; set; }
        public string ATE_CAPITA { get; set; }
        public string ATE_ENVIOAFINANCIAMIENTO { get; set; }
        public string ATE_MESREGISTRO { get; set; }
        public decimal ATE_COSTOCAPITA { get; set; }
        public string ATE_NT { get; set; }
        public string ATE_ESTADO_OBSERVACION { get; set; }
        public string ATE_PERIODO_ACEPTADO { get; set; }
        public string ATE_MES_ACEPTADO { get; set; }
        public DateTime ATE_FECHACIERRE { get; set; }
        public string ATE_PLAN { get; set; }
        public string ATE_DISAFESE { get; set; }
        public string ATE_LOTEFESE { get; set; }
        public string ATE_NROFESE { get; set; }
        public string ATE_RM { get; set; }
        public string ATE_MODALIDADVALOR { get; set; }
        public string ATE_IDSERVICIOANT { get; set; }
        public string ATE_CONFIRMA_PRESTACION { get; set; }
        public decimal ATE_VERSION { get; set; }
        public string ATE_VERREG { get; set; }
        public string ATE_VERENV { get; set; }
        public decimal ATE_DUPLICADO { get; set; }
        public decimal ATE_SECINSCRIPAUS { get; set; }
        public decimal ATE_IDNUMREGAFIESC { get; set; }
        public string ATE_TIPODOCPERSONALSALUD { get; set; }
        public string ATE_ESPECIALIDAD { get; set; }
        public decimal ATE_IDPER_ANT { get; set; }
        public string ATE_TIPDIGANT { get; set; }
        public string ATE_FICHAFILCORRECTMODIFMANUAL { get; set; }
        public decimal ATE_FINALIDAD2012 { get; set; }
        public decimal ATE_VALORNETO { get; set; }
        public string ATE_ODSIS { get; set; }
        public decimal ATE_IDGRUPO { get; set; }
        public DateTime ATE_FECFALLECIMIENTO { get; set; }
        public string ATE_BAJAAFILIACION { get; set; }
        public string ATE_IIEECODIGOMODULAR { get; set; }
        public string ATE_IIEENIVEL { get; set; }
        public string ATE_IIEETURNO { get; set; }
        public string ATE_IIEEGRADO { get; set; }
        public string ATE_IIEESECCION { get; set; }
        public string ATE_IIEEANEXO { get; set; }
        public string ATE_IIEEEDUESPECIAL { get; set; }
        public string ATE_IDEESSFLEXIBLE { get; set; }
        public string ATE_IDIAFAS { get; set; }
        public string ATE_CODSEGIAFAS { get; set; }
        public DateTime ATE_FECCORTEADM { get; set; }
        public string ATE_UDRAUTORIZAFUAVINCULADO { get; set; }
        public string ATE_LOTEAUTORIZAFUAVINCULADO { get; set; }
        public string ATE_SECAUTORIZAFUAVINCULADO { get; set; }
        public string ATE_DISAFUAVINCULADO { get; set; }
        public string ATE_LOTEFUAVINCULADO { get; set; }
        public string ATE_NUMFUAVINCULADO { get; set; }
        public string ATE_IDETNIA { get; set; }
        public string ATE_IDUPS { get; set; }
        public string ATE_ESESGRESADOPERSONALSALUD { get; set; }
        public string ATE_COLEGIATURAPERSONALSALUD { get; set; }
        public string ATE_RNEPERSONALSALUD { get; set; }
        public string ATE_GRUPOPOBLACIONAL { get; set; }
        public string ATE_VALIDADOASEGURADO { get; set; }
        public decimal ATE_IDORIGENACTADEFUNCION { get; set; }
        public string ATE_ACTADEFUNCION { get; set; }
        public string ATE_CORTE { get; set; }
        public decimal ATE_CORRAFI { get; set; }
        public decimal ATE_IDPAQUETE { get; set; }
        public decimal ID_PERSONA { get; set; }
        public decimal ATE_IDPAQUETE_INICIAL { get; set; }
        public DateTime ATE_FECRETRO { get; set; }
        public string ATE_NROACREDITACION { get; set; }
        public string ATE_RENIPRESS { get; set; }
        public string ATE_ESNUEVOFORMATO { get; set; }
        public string ATE_V_TIPOSEGURO { get; set; }
        public string ATE_ESEXCLUIDOCAPITA { get; set; }
        public string ATE_FISSAL { get; set; }
        public string ATE_MUESTRA_PRIORIZADA { get; set; }
        public string ATE_TIPOFINANCIAMIENTO { get; set; }
        public decimal ATE_VALOR_BRUTO { get; set; }
        public decimal ATE_VALOR_NETO { get; set; }
        public decimal ATE_OBSPSA { get; set; }
        public decimal ATE_OBSSME { get; set; }
        public decimal ATE_ESPCPP { get; set; }
        public decimal ATE_VALOR_NETO_SME { get; set; }
        public string ATE_IDFTEFTO { get; set; }
        public decimal ATE_IDMECANISMOPAGO { get; set; }

        public decimal RREC_N_COSTO_SOL { get; set; }
    }

    public class getAtencionesDIAxID{
        public decimal? ADIA_NUMREGATE { get; set; }
        public decimal? ADIA_IDNUMREG { get; set; }
        public decimal? ADIA_INRODIA { get; set; }
        public string? ADIA_CDX { get; set; }
        public string? ADIA_CODDIA { get; set; }
        public string? ADIA_TIPODIA { get; set; }
        public string? ADIA_IDUSUARIOCREA { get; set; }
        public DateTime? ADIA_FECHACREA { get; set; }
        public string? ADIA_IDUSUARIOACT { get; set; }
        public DateTime? ADIA_FECHAACT { get; set; }
        public string? ADIA_ESTADO { get; set; }
        public DateTime? ADIA_FECBAJA { get; set; }
        public string? ADIA_ODSISRECEP { get; set; }
        public string? ADIA_PDIGRECEP { get; set; }
        public DateTime? ADIA_FECRECEP { get; set; }
        public string? ADIA_IDUSURECEP { get; set; }
        public decimal? ADIA_NUMREGESC { get; set; }
        public decimal? ADIA_NUMREGDIA { get; set; }
        public decimal? ADIA_VERSION { get; set; }
        public string? ADIA_VERREG { get; set; }
        public string? ADIA_VERENV { get; set; }
        public string? DESC_CDX { get; set; }
        public string? C10_NOMBRE { get; set; }
        public string? DESC_TIPODIA { get; set; }

    }
    public class getAtencionesMEDxID
    {
        public decimal? AMED_NUMREGATE { get; set; }
        public decimal? AMED_IDNUMREG { get; set; }
        public string? AMED_CODMED { get; set; }
        public decimal? AMED_INRODIA { get; set; }
        public int? AMED_ICANTPRESCRITA { get; set; }
        public int? AMED_ICANTENTREGADA { get; set; }
        public decimal? AMED_ITICKET { get; set; }
        public decimal? AMED_NPO { get; set; }
        public decimal? AMED_NCOSTOAPLICADO { get; set; }
        public string? AMED_IDUSUARIOCREA { get; set; }
        public DateTime? AMED_FECCREA { get; set; }
        public string? AMED_IDUSUARIOACT { get; set; }
        public DateTime? AMED_FECACT { get; set; }
        public string? AMED_ESTADO { get; set; }
        public DateTime? AMED_FECBAJA { get; set; }
        public DateTime? AMED_PETFEC { get; set; }
        public string? AMED_PETNRODOC { get; set; }
        public string? AMED_FLAG { get; set; }
        public string? AMED_ODSISRECEP { get; set; }
        public string? AMED_PDIGRECEP { get; set; }
        public DateTime? AMED_FECRECEP { get; set; }
        public string? AMED_IDUSURECEP { get; set; }
        public decimal? AMED_NUMREGESC { get; set; }
        public decimal? AMED_NUMREGDIA { get; set; }
        public decimal? AMED_NPRECIODIGEMID { get; set; }
        public decimal? AMED_ICANTOBS { get; set; }
        public decimal? AMED_MODPAGO { get; set; }
        public decimal? AMED_IDPRECIO { get; set; }
        public decimal? AMED_CANTOBS { get; set; }
        public int? AMED_ICANTAPROBADAODSIS { get; set; }
        public decimal? AMED_IPRECIOCALCULADOSIS { get; set; }
        public string? AMED_PERIODO_ACEPTADO { get; set; }
        public string? AMED_MES_ACEPTADO { get; set; }
        public string? AMED_ESTADO_OBSERVACION { get; set; }
        public string? AMED_TIPOPRECIO { get; set; }
        public decimal? AMED_NUMREGPRA { get; set; }
        public decimal? AMED_IDVERSION { get; set; }
        public string? AMED_VERREG { get; set; }
        public string? AMED_VERENV { get; set; }
        public decimal? AMED_N_ESVALORIZADO { get; set; }

        public decimal? AMED_IDNUMREG_ORIGEN { get; set; }
        public string? AMED_V_MOTIVO_CAMBIO { get; set; }
        public string? AMED_IDUSUARIOEVAL { get; set; }
        public DateTime? AMED_FECEVAL { get; set; }

        public string? C10_NOMBRE { get; set; }

        public string? MED_NOMBRE { get; set; }
        public decimal? MED_COSTO { get; set; }
        public string? MED_PRESEN { get; set; }
        public string? MED_CONCEN { get; set; }
        public string? ROBS_IDNUMREGOBS { get; set; }
        public string? ROBS_DETALLE { get; set; }

        public string? C10_CODDIA { get; set; }

    }

    public class getAtencionesAPOxID
    {
        public decimal? AAPO_NUMREGATE { get; set; }
        public decimal? AAPO_IDNUMREG { get; set; }
        public string? AAPO_CODAPO { get; set; }
        public decimal? AAPO_INRODIA { get; set; }
        public int? AAPO_ICANTPROCED { get; set; }
        public int? AAPO_ICANTEJECUTADA { get; set; }
        public decimal? AAPO_ITICKET { get; set; }
        public decimal? AAPO_NPO { get; set; }
        public decimal? AAPO_NCOSTOAPLICADO { get; set; }
        public string? AAPO_IDUSUARIOCREA { get; set; }
        public DateTime? AAPO_FECCREA { get; set; }
        public string? AAPO_IDUSUARIOACT { get; set; }
        public DateTime? AAPO_FECACT { get; set; }
        public string? AAPO_ESTADO { get; set; }
        public DateTime? AAPO_FECBAJA { get; set; }
        public decimal? AAPO_RESULTADO { get; set; }
        public string? AAPO_ODSISRECEP { get; set; }
        public string? AAPO_PDIGRECEP { get; set; }
        public DateTime? AAPO_FECRECEP { get; set; }
        public string? AAPO_IDUSURECEP { get; set; }
        public decimal? AAPO_NUMREGESC { get; set; }
        public decimal? AAPO_NUMREGDIA { get; set; }
        public decimal? AAPO_ICANTOBS { get; set; }
        public decimal? AAPO_MODPAGO { get; set; }
        public decimal? AAPO_NCOSTOODSIS { get; set; }
        public decimal? AAPO_IPRECIOCALCULADOSIS { get; set; }
        public int? AAPO_ICANTIDADAPROBADAODSIS { get; set; }
        public string? AAPO_ESTADO_OBSERVACION { get; set; }
        public string? AAPO_PERIODO_ACEPTADO { get; set; }
        public string? AAPO_MES_ACEPTADO { get; set; }
        public decimal? AAPO_NUMREGPRA { get; set; }
        public decimal? AAPO_IDVERSION { get; set; }
        public string? AAPO_VERREG { get; set; }
        public string? AAPO_VERENV { get; set; }
        public decimal? AAPO_APO_ID { get; set; }
        public string? AAPO_RESULTADO_VAR { get; set; }
        public decimal? AAPO_ID_TIPOTARIFAADENDA { get; set; }
        public decimal? AAPO_ID_CONVEADENDAPROCED { get; set; }
        public DateTime? AAPO_FECHACARGA { get; set; }
        public string? AAPO_TIPOCARGA { get; set; }
        public string? AAPO_OBSERVACIONESCARGA { get; set; }
        public string? AAPO_TIPDOCPROFESIONAL { get; set; }
        public string? AAPO_NUMDOCPROFESIONAL { get; set; }
        public decimal? AAPO_N_IDCPMS { get; set; }

        public string? AAPO_V_MOTIVO_CAMBIO { get; set; }
        public string? AAPO_IDUSUARIOEVAL { get; set; }
        public DateTime? AAPO_FECEVAL { get; set; }



        public string? C10_NOMBRE { get; set; }
        public string? APO_NOMBRE { get; set; }
        public decimal? APO_COSTO { get; set; }
        public string? ROBS_IDNUMREGOBS { get; set; }
        public string? ROBS_DETALLE { get; set; }
        public string? C10_CODDIA { get; set; }

    }
    public class getAtencionesINSxID
    {
        public decimal? AINS_NUMREGATE { get; set; }
        public decimal? AINS_IDNUMREG { get; set; }
        public decimal? AINS_INRODIA { get; set; }
        public string? AINS_CODINS { get; set; }
        public string? AINS_CCARACT { get; set; }
        public int? AINS_ICANTPRESCRITA { get; set; }
        public int? AINS_ICANTENTREGADA { get; set; }
        public decimal? AINS_ITICKET { get; set; }
        public decimal? AINS_NPO { get; set; }
        public decimal? AINS_NCOSTOAPLICADO { get; set; }
        public string? AINS_IDUSUARIOCREA { get; set; }
        public DateTime? AINS_FECCREA { get; set; }
        public string? AINS_IDUSUARIOACT { get; set; }
        public DateTime? AINS_FECACT { get; set; }
        public string? AINS_ESTADO { get; set; }
        public DateTime? AINS_FECBAJA { get; set; }
        public DateTime? AINS_PETFEC { get; set; }
        public string? AINS_PETNRODOC { get; set; }
        public string? AINS_FLAG { get; set; }
        public string? AINS_ODSISRECEP { get; set; }
        public string? AINS_PDIGRECEP { get; set; }
        public DateTime? AINS_FECRECEP { get; set; }
        public string? AINS_IDUSURECEP { get; set; }
        public decimal? AINS_NUMREGESC { get; set; }
        public decimal? AINS_NUMREGDIA { get; set; }
        public decimal? AINS_NPRECIODIGEMID { get; set; }
        public decimal? AINS_ICANTOBS { get; set; }
        public decimal? AINS_MODPAGO { get; set; }
        public decimal? AINS_IDPRECIO { get; set; }
        public decimal? AINS_NCOSTOODSIS { get; set; }
        public int? AINS_ICANTIDADAPROBADAODSIS { get; set; }
        public decimal? AINS_IPRECIOCALCULADOSIS { get; set; }
        public string? AINS_ESTADO_OBSERVACION { get; set; }
        public string? AINS_PERIODO_ACEPTADO { get; set; }
        public string? AINS_MES_ACEPTADO { get; set; }
        public string? AINS_TIPOPRECIO { get; set; }
        public decimal? AINS_NUMREGPRA { get; set; }
        public decimal? AINS_IDVERSION { get; set; }
        public string? AINS_VERREG { get; set; }
        public string? AINS_VERENV { get; set; }
        public decimal? AINS_N_ESVALORIZADO { get; set; }

        public string? C10_NOMBRE { get; set; }
        public string? INS_NOMBRE { get; set; }
        public decimal? INS_COSTO { get; set; }
        public string? INS_UNIDAD { get; set; }
        public string? INS_PRESEN { get; set; }
        public string? INS_CONCEN { get; set; }
        public string? ROBS_IDNUMREGOBS { get; set; }
        public string? ROBS_DETALLE { get; set; }
        public string? C10_CODDIA { get; set; }

    }

    public class getAtencionesDIA_Edit
    {

        public decimal? ADIA_NUMREGATE { get; set; }
        public decimal? ADIA_IDNUMREG { get; set; }
        public decimal? ADIA_INRODIA { get; set; }
        public string? ADIA_CDX { get; set; }
        public string? ADIA_CODDIA { get; set; }
        public string? ADIA_TIPODIA { get; set; }

    }

    public class GetAtencionMedicaRecon
    {

        public decimal? AMED_NUMREGATE { get; set; }
        public decimal? AMED_IDNUMREG { get; set; }
        public string? AMED_CODMED { get; set; }
        public decimal? AMED_INRODIA { get; set; }
        public decimal? AMED_ICANTPRESCRITA { get; set; }
        public decimal? AMED_ICANTENTREGADA { get; set; }

        public decimal? AMED_ITICKET { get; set; }
        public decimal? AMED_NPO { get; set; }
        public decimal? AMED_NCOSTOAPLICADO { get; set; }

        public int? AMED_ICANTAPROBADAODSIS { get; set; }
        public decimal? AMED_IPRECIOCALCULADOSIS { get; set; }
        public string? AMED_V_MOTIVO_CAMBIO { get; set; }


    }
    public class GetMedicamentosxMED_CODMED
    {

        public string? MED_CODMED { get; set; }
        public string? MED_NOMBRE { get; set; }
        public string? MED_PRESEN { get; set; }
        public string? MED_CONCEN { get; set; }
        public int? MED_COSTO { get; set; }
        public string? MED_PETIT { get; set; }
        public DateTime? MED_MESALTA { get; set; }
        public string? MED_DOC { get; set; }


    }

    public class getAtencionesAPO_Edit
    {
        public decimal? AAPO_NUMREGATE { get; set; }
        public decimal? AAPO_IDNUMREG { get; set; }
        public string? AAPO_CODAPO { get; set; }
        public decimal? AAPO_INRODIA { get; set; }
        public decimal? AAPO_ICANTPROCED { get; set; }
        public decimal? AAPO_ICANTEJECUTADA { get; set; }
        public decimal? AAPO_ITICKET { get; set; }
        public decimal? AAPO_NPO { get; set; }
        public decimal? AAPO_NCOSTOAPLICADO { get; set; }


        public int? AAPO_ICANTIDADAPROBADAODSIS { get; set; }
        public decimal? AAPO_IPRECIOCALCULADOSIS { get; set; }
        public string? AAPO_V_MOTIVO_CAMBIO { get; set; }

    }
    public class getAtencionesINS_Edit
    {
        public decimal? AINS_NUMREGATE { get; set; }
        public decimal? AINS_IDNUMREG { get; set; }
        public decimal? AINS_INRODIA { get; set; }
        public string? AINS_CODINS { get; set; }
        public string? AINS_CCARACT { get; set; }
        public decimal? AINS_ICANTPRESCRITA { get; set; }
        public decimal? AINS_ICANTENTREGADA { get; set; }
        public decimal? AINS_ITICKET { get; set; }
        public decimal? AINS_NPO { get; set; }
        public decimal? AINS_NCOSTOAPLICADO { get; set; }


        public int? AINS_ICANTIDADAPROBADAODSIS { get; set; }
        public decimal? AINS_IPRECIOCALCULADOSIS { get; set; }
        public string? AINS_V_MOTIVO_CAMBIO { get; set; }


        
            
            

    }

    public class GetInsumosxId
    {
        public string? INS_CODINS { get; set; }
        public string? INS_NOMBRE { get; set; }
        public string? INS_UNIDAD { get; set; }
        public string? INS_CONCEN { get; set; }
        public decimal? INS_COSTO { get; set; }
    }
    public class GetMatriz
    {
        public int? Val { get; set; }
        public int? ID { get; set; }
        public int? CANT { get; set; }
        public string? REGLA { get; set; }
        public string? IVAL_V_DESCRIPCION { get; set; }
        public string? IVAL_V_REFCOLUMNA { get; set; }
        public string? IVAL_V_REFDEVELOPER { get; set; }
        public string? ROBS_DETALLE { get; set; }
        public string? ROBS_CODIGO_OBSERVACION { get; set; }

        public string? TAB_CODTABLA { get; set; }
        public string? OBS_ATEIDNUMREG { get; set; }
        public string? ROBS_IDNUMREGOBS { get; set; }

    }
    public class GetResumenxID
    {
        public int? RREC_IDNUMREG { get; set; }
        public string? RREC_PERIODO { get; set; }
        public string? RREC_MES { get; set; }
        public int? RREC_MODPAGO { get; set; }
        public int? RREC_RM { get; set; }
        public int? RREC_OBSPSA { get; set; }
        public int? RREC_OBSSME { get; set; }
        public int? RREC_N_ESOBSTOTAL { get; set; }
        public int? RREC_ID_ESTADOREC { get; set; }
        public int? RREC_C_ESTARV { get; set; }
        public string? RREC_IDEESS { get; set; }
        
    }

    public class GetObservacionesRcRv
    {
        public int? ROBS_NUMREGATE { get; set; }
        public int? Id { get; set; }
        public string? ROBS_CODIGO_OBSERVACION { get; set; }
        public string? ROBS_DETALLE { get; set; }
        public string? TAB_CODTABLA { get; set; }
        public string? TABLA { get; set; }
        public string? OBS_ATEIDNUMREG { get; set; }
        public string? ROBS_DESCRIPCION { get; set; }
        public string? OBS_CODREG { get; set; }
                
    }
    public class GetObservRcRv
    {
        public int? ORC_IDNUMREG { get; set; }
        public string? ORC_IDRC { get; set; }
        public string? ORC_OBSERVACION { get; set; }
        public int? ORC_IDPAQUETE { get; set; }

    }

    public class GetListObservaAte
    {
        public int? ROBS_NUMREGATE { get; set; }
        public int? Id { get; set; }
        public string? ROBS_CODIGO_OBSERVACION { get; set; }
        public string? ROBS_DETALLE { get; set; }
        public string? TAB_CODTABLA { get; set; }
        public string? TABLA { get; set; }
        public int? OBS_ATEIDNUMREG { get; set; }
        public string? ROBS_DESCRIPCION { get; set; }
        public string? OBS_CODREG { get; set; }
    }

    public class GetAteSustento
    {
        public int? ATE_SUSTENTO { get; set; }
        public string? ATE_MOTIVOSOLICITUD { get; set; }
        public string? ATE_IDTIPOSUSTENTO { get; set; }
        public string? ATE_DESCRIPSUSTENTO { get; set; }
        public string? USUARIOCREA { get; set; }
        


    }

    public class getAteSustentoArch
    {
        public int? asus_numregate { get; set; }
        public int? asus_idnumreg { get; set; }
        public string? asus_v_rutaarch { get; set; }
        public string? asus_v_nombarch { get; set; }
        public string? asus_v_usuariocrea { get; set; }
        public DateTime asus_v_feccrea { get; set; }
        public string? asus_v_usuarioedita { get; set; }
        public DateTime asus_v_fecedita { get; set; }
        public string? asus_b_estado { get; set; }
        public string? asus_v_archivodescr { get; set; }
    }

    public class GetPeriodo
    {
        public int? idperiodo { get; set; }
        public string? periodo { get; set; }
        public string? mes { get; set; }
        public string? fecini { get; set; }
        public string? fecfin { get; set; }
        public string? escierre { get; set; }
        public string? motivo { get; set; }
        public string? usuario { get; set; }

    }
    public class getCostosXEVAL
    {

        public decimal? TCOSTO_OBS { get; set; }
        public decimal? PROCEDIMIENTO_COSTO_OBS { get; set; }
        public decimal? INSUMO_COSTO_OBS { get; set; }
        public decimal? MEDICAMENTO_COSTO_OBS { get; set; }
        public decimal? SERVICIO_COSTO_OBS { get; set; }
        public decimal? TCOSTO_SOL { get; set; }
        public decimal? PROCEDIMIENTO_COSTO_SOL { get; set; }
        public decimal? INSUMO_COSTO_SOL { get; set; }
        public decimal? MEDICAMENTO_COSTO_SOL { get; set; }
        public decimal? SERVICIO_COSTO_SOL { get; set; }
        public decimal? TCOSTO_EVAL { get; set; }
        public decimal? PROCEDIMIENTO_COSTO_EVAL { get; set; }
        public decimal? INSUMO_COSTO_EVAL { get; set; }
        public decimal? MEDICAMENTO_COSTO_EVAL { get; set; }
        public decimal? SERVICIO_COSTO_EVAL { get; set; }

    }
    public class GetEvaluacionID
    {

        public int ID_ESTADOREC { get; set; }
        public string V_USUEVALUA { get; set; }
        public string V_OBSGENERAL { get; set; }

        public string V_OBSDETALLE { get; set; }

        public int A1 { get; set; }
        public int A2 { get; set; }
        public int A3 { get; set; }
        public int A4 { get; set; }
        public int B1 { get; set; }
        public int B2 { get; set; }
        public int B3 { get; set; }
        public int B4 { get; set; } 
    }

    public class GetSolicitudAmpliacion
    {
        public int? IDNUMREG { get; set; }
        public string? PERIODO { get; set; }
        public string? MES { get; set; }
        public string? DISA { get; set; }
        public string? DESCODSIS { get; set; }
        public string? ODSIS { get; set; }
        public string? UEJECUTORA { get; set; }
        public string? DESCEJECUTORA { get; set; }
        public string? IDEESS { get; set; }
        public string? EESS { get; set; }
        public int? DIASPLAZO { get; set; }
        public string? MOTIVO { get; set; }
        public string? ESTADO { get; set; }
        public string? USUCREA { get; set; }
        public string? FECCREA { get; set; }
        public string? FECFINPLAZO { get; set; }
        public string? USUEVALUA { get; set; }
        public string? FECEVALUA { get; set; }
        public string? TIPO { get; set; }

    }
}

