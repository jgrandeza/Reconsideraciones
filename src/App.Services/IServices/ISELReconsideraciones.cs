using App.ViewModels.Auxiliares;
using App.ViewModels.SELReconsideraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.IServices
{
    public interface ISELReconsideraciones
    {
        Task<getAtencionRecxID> ListarIAtencionRecxID(int Id);
        Task<IEnumerable<getAtencionesDIAxID>> ListarIAtencionDIAxID(int Id);
        Task<IEnumerable<getAtencionesMEDxID>> ListarIAtencionMEDxID(int Id);
        Task<IEnumerable<getAtencionesAPOxID>> ListarIAtencionAPOxID(int Id);
        Task<IEnumerable<getAtencionesINSxID>> ListarIAtencionINSxID(int Id);

        Task<getAtencionesDIA_Edit> ListarAtencionDIA_Edit(int Id);

        //PR_REC_SEL_IATENCIONMED_REC_ID GetAtencionMedicaRecon
        Task<GetAtencionMedicaRecon> ListarAtencionMedEditxID(int Id);

        //PR_REC_SEL_MEDICAMENTOS GetMedicamentosxMED_CODMED
        Task<GetMedicamentosxMED_CODMED> ListarMedicamentoxMED_CODMED(string MED_CODMED);

        Task<getAtencionesAPO_Edit> ListarAtencionAPO_Edit(int Id);
        Task<getAtencionesINS_Edit> ListarAtencionINS_Edit(int Id);
    }
}
