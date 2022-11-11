using App.ViewModels.INSReconsideraciones;
using App.ViewModels.SELReconsideraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.IServices
{
    public interface IUPDReconsideraciones
    {
        Task<bool> ActualizarAtencionesDia(UPDAtencionesDiaDto model);

        //ACTUALIZAR FUA getAtencionRecxID
        Task<bool> Actualizar_FUA(getAtencionRecxID model);

        Task<Mensaje_Ins> ActualizarAteSustento(getInsertarAteSustento model);
        Task<Mensaje_Ins> ActualizarAteEval(int N_ATE_IDNUMREG);

    }
}
