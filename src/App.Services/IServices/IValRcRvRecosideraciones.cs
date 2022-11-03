using System;
using App.ViewModels.INSReconsideraciones;
using static App.ViewModels.SELSiasis.SELSiasis;

namespace App.Services.IServices
{
    public interface IValRcRvRecosideraciones
    {
        Task<getValidarReglas> ValidarRcRvRec(int N_ATE_IDNUMREG);
    }
}

