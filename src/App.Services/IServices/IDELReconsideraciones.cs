using System;
using App.ViewModels.SELReconsideraciones;
using static App.ViewModels.DELReconsideraciones.DELReconsideraciones;

namespace App.Services.IServices
{
    public interface IDELReconsideraciones
    {
        Task<Mensaje_Del> EliminarAtencionDia(int N_ADIA_IDNUMREG);
        Task<Mensaje_Del> EliminarAtencionMed(int N_AMED_IDNUMREG);
        Task<Mensaje_Del> EliminarAtencionApo(int N_AAPO_IDNUMREG);
        Task<Mensaje_Del> EliminarAtencionIns(int N_AINS_IDNUMREG);

        Task<Mensaje_Del> EliminarAtencionTotal(int N_ATE_IDNUMREG);

    }
}

