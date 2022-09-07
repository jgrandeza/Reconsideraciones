using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public decimal V_AMED_IDUSUARIOCREA { get; set; }


    }
    public class getInsertarAtencionTotal
    {
        public string COD { get; set; }
        public string MSJ { get; set; }
        public int OK { get; set; }
    }
}
