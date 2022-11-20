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

        Task<GetInsumosxId> ListarInsumosId(string V_INS_CODINS);

        Task<IEnumerable<GetMatriz>> ListarMatriz(int Id);

        Task<GetResumenxID> ResumenRecxID(int N_ATE_IDNUMREG);

        Task<IEnumerable<GetObservacionesRcRv>> ListarIAtencionOBSxID(int N_ATE_IDNUMREG, string V_CODTABLA);

        Task<IEnumerable<GetObservRcRv>> ListarObservacionesRcRv(int N_ATE_IDNUMREG);

        Task<IEnumerable<GetListObservaAte>> ListarObservacionesSust(int N_ATE_IDNUMREG);

        Task<GetAteSustento> ListarAteSustxID(int N_ATE_IDNUMREG);

        Task<IEnumerable<getAteSustentoArch>> ListarAteSusArch(int N_ATE_IDNUMREG);

        Task<IEnumerable<getAteSustentoArch>> ListarAteSusArchxID(int N_ASUS_IDNUMREG);

        Task<getCostosXEVAL> ListarCostosxEVAL(int P_I_IDATENCION);

        Task<GetEvaluacionID> ListarEvaluacionxID(int P_I_IDATENCION);

    }
}
