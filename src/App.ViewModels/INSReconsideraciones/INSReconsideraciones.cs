using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace App.ViewModels.INSReconsideraciones
{
    public class INSReconsideraciones
    {
    }
    public class getInsertarAtencionMedicamentoRec
    {
        public decimal N_AMED_NUMREGATE { get; set; }
        public string? V_AMED_CODMED { get; set; }
        public decimal N_AMED_INRODIA { get; set; }
        public decimal N_AMED_ICANTPRESCRITA { get; set; }
        public decimal N_AMED_ICANTENTREGADA { get; set; }
        public decimal N_AMED_NPO { get; set; }
        public string? V_AMED_IDUSUARIOCREA { get; set; }
        public decimal? N_ROBS_IDNUMREGOBS { get; set; }


    }

    public class getInsertarAtencionTotal
    {
        public string COD { get; set; }
        public string MSJ { get; set; }
        public int OK { get; set; }
    }
    public class Mensaje_Ins
    {
        public int CODIGO { get; set; }
        public string MENSAJE { get; set; }
    }

    public class getInsertarAtencionDIA
    {
        public decimal N_ADIA_NUMREGATE { get; set; }
        public string? V_ADIA_CDX { get; set; }
        public string? V_ADIA_CODDIA { get; set; }
        public string? V_ADIA_TIPODIA { get; set; }
        public string? V_ADIA_IDUSUARIOCREA { get; set; }

    }
    public class getInsertarAtencionAPO
    {
        public decimal N_AAPO_NUMREGATE { get; set; }
        public decimal N_AAPO_CODAPO { get; set; }
        public string? V_AAPO_INRODIA { get; set; }
        public decimal N_AAPO_ICANTPROCED { get; set; }
        public decimal N_AAPO_ICANTEJECUTADA { get; set; }
        public decimal N_AAPO_ITICKET { get; set; }
        public decimal N_AAPO_NPO { get; set; }
        public decimal N_AAPO_NCOSTOAPLICADO { get; set; }
        public string V_AAPO_IDUSUARIOCREA { get; set; }
        public decimal N_AAPO_APO_ID { get; set; }
        public decimal? N_ROBS_IDNUMREGOBS { get; set; }

    }
    public class getInsertarAtencionINS
    {
        public decimal N_AINS_NUMREGATE { get; set; }
        public decimal N_AINS_INRODIA { get; set; }
        public string V_AINS_CODINS { get; set; }
        public string V_AINS_CCARACT { get; set; }
        public decimal N_AINS_ICANTPRESCRITA { get; set; }
        public decimal N_AINS_ICANTENTREGADA { get; set; }
        public decimal N_AINS_ITICKET { get; set; }
        public decimal N_AINS_NPO { get; set; }
        public decimal N_AINS_NCOSTOAPLICADO { get; set; }
        public string V_AINS_IDUSUARIOCREA { get; set; }
        public decimal? N_ROBS_IDNUMREGOBS { get; set; }

    }

    public class getValidarReglas
    {
        public int? idate { get; set; }
        public string ORC_OBSERVACION { get; set; }
        public int CODIGO { get; set; }
        public string MENSAJE { get; set; }
        
    }
    public class getInsertarAteSustento
    {
        public int? N_ATE_IDNUMREG { get; set; }
        public string? V_ATE_MOTIVOSOLICITUD { get; set; }
        public string? N_ATE_IDTIPOSUSTENTO { get; set; }
        public string? V_ATE_DESCRIPSUSTENTO { get; set; }
    }
    public class setInsertarAteArchSuste
    {
        public int? N_asus_numregate { get; set; }
        public IFormFile file { get; set; }
    }
    public class setInsertarAteArchSuste2
    {
        public int? N_asus_numregate { get; set; }
        public string V_asus_v_rutaarch { get; set; }
        public string V_asus_v_nombarch { get; set; }
        public string V_asus_v_usuariocrea { get; set; }
        public string V_ASUS_V_ARCHIVODESCR { get; set; }
    }
}
