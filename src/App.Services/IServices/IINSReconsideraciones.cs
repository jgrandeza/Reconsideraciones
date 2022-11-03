using App.Services.Services;
using App.ViewModels.INSReconsideraciones;
using App.ViewModels.SELReconsideraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.IServices
{
    public interface IINSReconsideraciones
    {
        Task<Mensaje_Ins> InsertarAtenMedicamentoRec(getInsertarAtencionMedicamentoRec model);
        Task<getInsertarAtencionTotal> InsertarAtencionTotal(int Id, string user);
        Task<Mensaje_Ins> InsertarAtenDiagnostico(getInsertarAtencionDIA model);

        Task<Mensaje_Ins> InsertarAtenProcedimiento(getInsertarAtencionAPO model);
        Task<Mensaje_Ins> InsertarAtenInsumos(getInsertarAtencionINS model);
        Task<Mensaje_Ins> InsertarAtenSustentos(setInsertarAteArchSuste2 model);
        Task<Mensaje_Ins> InsertarEnviarSolicitud(int N_ATE_IDNUMREG);
    }
}
