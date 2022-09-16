using System;
namespace App.ViewModels.SELSiasis
{
    public class SELSiasis
    {

        public class getAtencionObs
        {
            public decimal? ate_idnumreg { get; set; }
            public decimal? ate_disa { get; set; }
            public decimal? ate_lote { get; set; }
            public string? ate_numregate { get; set; }
            public string? ate_historiaclinica { get; set; }
            public string? ate_observaciones { get; set; }
            public string? ate_idservicioAnt { get; set; }
            public string? ate_esgestante { get; set; }
            public string? ate_usuario_revisado { get; set; }
            public string? ate_fecha_revision { get; set; }
            public string? ate_fecCrea { get; set; }
            public string? ate_fecinghosp { get; set; }
            public string? ate_fecaltahosp { get; set; }
            public string? ate_numautorizacion { get; set; }
            public string? ate_monto { get; set; }
            public string? ate_periodo { get; set; }
            public string? ate_mes { get; set; }
            public string? ate_observacion { get; set; }
            public string? ate_dnipersonalsalud { get; set; }
            public string? ate_ideess { get; set; }
            public string? ate_articulo { get; set; }
            public string? ate_fecparto { get; set; }
            public string? tipo_ingreso { get; set; }
            public string? ser_nombre { get; set; }
            public string? fecha_parto { get; set; }
            public string? ate_nroatencion { get; set; }
            public string? pre_nombre { get; set; }
            public string? pre_idEESS { get; set; }
            public string? ate_odsis { get; set; }
            public string? ate_tipo_pago { get; set; }
            public string? eessReferido { get; set; }
            public string? eessNomReferido { get; set; }
            public string? eessContraRef { get; set; }
            public string? eessNomContraRef { get; set; }
            public string? pes_nombrecompleto { get; set; }
            public string? pes_idDNI { get; set; }
            public string? ate_Edad_AMD { get; set; }
            public string? ate_componente { get; set; }
            public string? ate_sexo { get; set; }
            public string? ate_edad { get; set; }
            public string? fecha_nac { get; set; }
            public string? fecha_aten { get; set; }
            public string? ate_nrobenef { get; set; }
            public string? ate_beneficiario { get; set; }
            public string? ate_idservicio { get; set; }
            public string? ate_capita { get; set; }
            public string? ate_fecact { get; set; }
            public string? ate_muestrapcpp { get; set; }
            public string? ate_coddestino { get; set; }
            public string? ate_fecfallecimiento { get; set; }
            public string? ate_disafuavinculado { get; set; }
            public string? ate_lotefuavinculado { get; set; }
            public string? ate_numfuavinculado { get; set; }
            public string? ate_udrautorizafuavinculado { get; set; }
            public string? ate_loteautorizafuavinculado { get; set; }
            public string? ate_secautorizafuavinculado { get; set; }
            public string? NumAutorizaCartaGarantia { get; set; }
            public string? ate_idlugar { get; set; }
            public string? ate_idOrigenPersonal { get; set; }
            public string? ATE_IDIAFAS { get; set; }
            public string? ser_idtiposervicio { get; set; }
            public string? ATE_FECCORTEADM { get; set; }
            public string? ate_TipoPago { get; set; }
            public string? ate_muestrapcpp_obs { get; set; }
        }
        public class getAtencionDIAObs
        {
            public string? adia_coddia { get; set; }
            public string? c10_nombre { get; set; }
            public decimal? adia_iNroDia { get; set; }
            public decimal? adia_tipodia { get; set; }
            public string? tda_cdescripcion { get; set; }

        }
        public class getAtencionMEDObs
        {
            public string? AMED_NUMREGATE { get; set; }
            public string? AMED_IDNUMREG { get; set; }
            public string? AMED_CODMED { get; set; }
            public string? AMED_INRODIA { get; set; }
            public string? AMED_ICANTPRESCRITA { get; set; }
            public string? AMED_ICANTENTREGADA { get; set; }
            public string? AMED_ITICKET { get; set; }
            public string? AMED_NPO { get; set; }
            public string? AMED_NCOSTOAPLICADO { get; set; }
            public string? AMED_IDUSUARIOCREA { get; set; }
            public string? AMED_FECCREA { get; set; }
            public string? AMED_IDUSUARIOACT { get; set; }
            public string? AMED_FECACT { get; set; }
            public string? AMED_ESTADO { get; set; }
            public string? AMED_FECBAJA { get; set; }
            public string? AMED_PETFEC { get; set; }
            public string? AMED_PETNRODOC { get; set; }
            public string? AMED_FLAG { get; set; }
            public string? AMED_ODSISRECEP { get; set; }
            public string? AMED_PDIGRECEP { get; set; }
            public string? AMED_FECRECEP { get; set; }
            public string? AMED_IDUSURECEP { get; set; }
            public string? AMED_NUMREGESC { get; set; }
            public string? AMED_NUMREGDIA { get; set; }
            public string? AMED_NPRECIODIGEMID { get; set; }
            public string? AMED_ICANTOBS { get; set; }
            public string? AMED_MODPAGO { get; set; }
            public string? AMED_IDPRECIO { get; set; }
            public string? AMED_CANTOBS { get; set; }
            public string? AMED_ICANTAPROBADAODSIS { get; set; }
            public string? AMED_IPRECIOCALCULADOSIS { get; set; }
            public string? AMED_PERIODO_ACEPTADO { get; set; }
            public string? AMED_MES_ACEPTADO { get; set; }
            public string? AMED_ESTADO_OBSERVACION { get; set; }
            public string? AMED_TIPOPRECIO { get; set; }
            public string? AMED_NUMREGPRA { get; set; }
            public string? AMED_IDVERSION { get; set; }
            public string? AMED_VERREG { get; set; }
            public string? AMED_VERENV { get; set; }
            public string? MED_CODMED { get; set; }
            public string? MED_NOMBRE { get; set; }
            public string? MED_PRESEN { get; set; }
            public string? MED_CONCEN { get; set; }
            public string? MED_COSTO { get; set; }
            public string? MED_ESTADO { get; set; }
            public string? MED_PETIT { get; set; }
            public string? MED_PETIT2005 { get; set; }
            public string? MED_PETIT2010 { get; set; }
            public string? MED_MESALTA { get; set; }
            public string? MED_MESBAJA { get; set; }
            public string? MED_DOCCREA { get; set; }
            public string? MED_DOCACTU { get; set; }
            public string? MED_OBSERVACION { get; set; }
            public string? MED_HIERRO { get; set; }
            public string? MED_PETIT2012 { get; set; }
            public string? MED_FFDIGEMID { get; set; }
            public string? MED_V_NOMBRE_SIS { get; set; }
            public string? MED_V_PRESENT_SIS { get; set; }
            public string? MED_V_FORMAFARM_SIS { get; set; }
            public string? MED_V_UNIDAD_CONSUMO { get; set; }
            public string? MED_N_FACTOR_CONSUMO { get; set; }
            public string? MED_PREST { get; set; }
            public string? AMED_OBSERVACIONES { get; set; }
            public string? PRA_TIPO_PRECIO_DES { get; set; }
            public string? AMED_ACEPTADO_EN { get; set; }
            public string? AMED_IPRECIOTOTAL { get; set; }
            public string? NROAVISOS { get; set; }
            public string? AMED_PETITORIO { get; set; }
            public string? CODAVISO { get; set; }
        }

        public class getAtencionAPOObs
        {
            public string? AAPO_NUMREGATE { get; set; }
            public string? AAPO_IDNUMREG { get; set; }
            public string? AAPO_CODAPO { get; set; }
            public string? AAPO_INRODIA { get; set; }
            public string? AAPO_ICANTPROCED { get; set; }
            public string? AAPO_ICANTEJECUTADA { get; set; }
            public string? AAPO_ITICKET { get; set; }
            public string? AAPO_NPO { get; set; }
            public string? AAPO_NCOSTOAPLICADO { get; set; }
            public string? AAPO_IDUSUARIOCREA { get; set; }
            public string? AAPO_FECCREA { get; set; }
            public string? AAPO_IDUSUARIOACT { get; set; }
            public string? AAPO_FECACT { get; set; }
            public string? AAPO_ESTADO { get; set; }
            public string? AAPO_FECBAJA { get; set; }
            public string? AAPO_RESULTADO { get; set; }
            public string? AAPO_ODSISRECEP { get; set; }
            public string? AAPO_PDIGRECEP { get; set; }
            public string? AAPO_FECRECEP { get; set; }
            public string? AAPO_IDUSURECEP { get; set; }
            public string? AAPO_NUMREGESC { get; set; }
            public string? AAPO_NUMREGDIA { get; set; }
            public string? AAPO_ICANTOBS { get; set; }
            public string? AAPO_MODPAGO { get; set; }
            public string? AAPO_NCOSTOODSIS { get; set; }
            public string? AAPO_IPRECIOCALCULADOSIS { get; set; }
            public string? AAPO_ICANTIDADAPROBADAODSIS { get; set; }
            public string? AAPO_ESTADO_OBSERVACION { get; set; }
            public string? AAPO_PERIODO_ACEPTADO { get; set; }
            public string? AAPO_MES_ACEPTADO { get; set; }
            public string? AAPO_NUMREGPRA { get; set; }
            public string? AAPO_IDVERSION { get; set; }
            public string? AAPO_VERREG { get; set; }
            public string? AAPO_VERENV { get; set; }
            public string? AAPO_APO_ID { get; set; }
            public string? AAPO_RESULTADO_VAR { get; set; }
            public string? AAPO_ID_TIPOTARIFAADENDA { get; set; }
            public string? AAPO_ID_CONVEADENDAPROCED { get; set; }
            public string? AAPO_FECHACARGA { get; set; }
            public string? AAPO_TIPOCARGA { get; set; }
            public string? AAPO_OBSERVACIONESCARGA { get; set; }
            public string? AAPO_TIPDOCPROFESIONAL { get; set; }
            public string? AAPO_NUMDOCPROFESIONAL { get; set; }
            public string? AAPO_N_IDCPMS { get; set; }
            public string? APO_NOMBRE { get; set; }
            public string? PRCD_V_DESPROCEDIMIENTO { get; set; }
            public string? prcd_v_codprocedimiento { get; set; }
            public string? AAPO_OBSERVACIONES { get; set; }
            public string? pra_tipo_precio_des { get; set; }
            public string? aapo_aceptado_en { get; set; }
            public string? aapo_ipreciototal { get; set; }
            public string? NroAvisos { get; set; }
            public string? CodAviso { get; set; }
        }

        public class getAtencionINSObs
        {
            public string? AINS_NUMREGATE { get; set; }
            public string? AINS_IDNUMREG { get; set; }
            public string? AINS_INRODIA { get; set; }
            public string? AINS_CODINS { get; set; }
            public string? AINS_CCARACT { get; set; }
            public string? AINS_ICANTPRESCRITA { get; set; }
            public string? AINS_ICANTENTREGADA { get; set; }
            public string? AINS_ITICKET { get; set; }
            public string? AINS_NPO { get; set; }
            public string? AINS_NCOSTOAPLICADO { get; set; }
            public string? AINS_IDUSUARIOCREA { get; set; }
            public string? AINS_FECCREA { get; set; }
            public string? AINS_IDUSUARIOACT { get; set; }
            public string? AINS_FECACT { get; set; }
            public string? AINS_ESTADO { get; set; }
            public string? AINS_FECBAJA { get; set; }
            public string? AINS_PETFEC { get; set; }
            public string? AINS_PETNRODOC { get; set; }
            public string? AINS_FLAG { get; set; }
            public string? AINS_ODSISRECEP { get; set; }
            public string? AINS_PDIGRECEP { get; set; }
            public string? AINS_FECRECEP { get; set; }
            public string? AINS_IDUSURECEP { get; set; }
            public string? AINS_NUMREGESC { get; set; }
            public string? AINS_NUMREGDIA { get; set; }
            public string? AINS_NPRECIODIGEMID { get; set; }
            public string? AINS_ICANTOBS { get; set; }
            public string? AINS_MODPAGO { get; set; }
            public string? AINS_IDPRECIO { get; set; }
            public string? AINS_NCOSTOODSIS { get; set; }
            public string? AINS_ICANTIDADAPROBADAODSIS { get; set; }
            public string? AINS_IPRECIOCALCULADOSIS { get; set; }
            public string? AINS_ESTADO_OBSERVACION { get; set; }
            public string? AINS_PERIODO_ACEPTADO { get; set; }
            public string? AINS_MES_ACEPTADO { get; set; }
            public string? AINS_TIPOPRECIO { get; set; }
            public string? AINS_NUMREGPRA { get; set; }
            public string? AINS_IDVERSION { get; set; }
            public string? AINS_VERREG { get; set; }
            public string? AINS_VERENV { get; set; }
            public string? INS_CODINS { get; set; }
            public string? INS_NOMBRE { get; set; }
            public string? INS_UNIDAD { get; set; }
            public string? INS_PRESEN { get; set; }
            public string? INS_CONCEN { get; set; }
            public string? INS_COSTO { get; set; }
            public string? INS_ESTADO { get; set; }
            public string? INS_PETIT { get; set; }
            public string? INS_DOCUMENTO { get; set; }
            public string? INS_DOCUMENTOACT { get; set; }
            public string? INS_MESALTA { get; set; }
            public string? INS_MESBAJA { get; set; }
            public string? INS_OBSERVACION { get; set; }
            public string? INSU_V_NOMBRE_SIS { get; set; }
            public string? INSU_V_PRESENT_SIS { get; set; }
            public string? INSU_V_FORMAFARM_SIS { get; set; }
            public string? INSU_V_UNIDAD_CONSUMO { get; set; }
            public string? INSU_N_FACTOR_CONSUMO { get; set; }
            public string? INSU_PREST { get; set; }
            public string? AINS_OBSERVACIONES { get; set; }
            public string? PRA_TIPO_PRECIO_DES { get; set; }
            public string? AINS_ACEPTADO_EN { get; set; }
            public string? AINS_IPRECIOTOTAL { get; set; }
            public string? NROAVISOS { get; set; }
            public string? CodAviso { get; set; }

        }

        public class getAtencionObsPar
        {
            public string? obs_idnumreg { get; set; }
            public string? rver_version { get; set; }
            public string? rval_codigo_observacion { get; set; }
            public string? tab_codtabla { get; set; }
            public string? ORIGEN { get; set; }
            public string? obs_tabla_idnumreg { get; set; }
            public string? obs_codreg { get; set; }
            public string? obs_detalle { get; set; }
            public string? rval_descripcion { get; set; }
            public string? obs_ateidnumreg { get; set; }
            public string? descripcion_util { get; set; }
        }

        public class getAtencionObsTot
        {
            public string? obs_idnumreg { get; set; }
            public string? rver_version { get; set; }
            public string? rval_codigo_observacion { get; set; }
            public string? tab_codtabla { get; set; }
            public string? ORIGEN { get; set; }
            public string? obs_tabla_idnumreg { get; set; }
            public string? obs_codreg { get; set; }
            public string? obs_detalle { get; set; }
            public string? rval_descripcion { get; set; }
            public string? titulo { get; set; }
            public string? obs_periodo { get; set; }
            public string? obs_mes { get; set; }
        }
        public class getMasterBruto
        {
            public decimal ATE_VALORBRUTOMED { get; set; }
            public decimal ATE_VALORBRUTOINS { get; set; }
            public decimal ATE_VALORBRUTOPRO { get; set; }
            public decimal ATE_VALORBRUTO { get; set; }

        }
        public class getMasterNeto
        {
            public decimal ATE_VALORNETOMED { get; set; }
            public decimal ATE_VALORNETOINS { get; set; }
            public decimal ATE_VALORNETOPRO { get; set; }
            public decimal ATE_VALORNETO { get; set; }

        }

        public  class getMaster<T>
        {
            public T Item { get; set; }
        }
    }
}

