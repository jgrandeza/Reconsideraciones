using System;
using App.ViewModels.SELReconsideraciones;
using static App.ViewModels.SELSiasis.SELSiasis;

namespace App.Services.IServices
{
    public interface ISELSiasis
    {
        Task<getAtencionObs> ListarIAtencionRecxID(int v_idnumreg);
        Task<IEnumerable<getAtencionObsTot>> ListarIAtencionObsTotxID(int v_idnumreg, string v_periodo, string v_mes);
        Task<IEnumerable<getAtencionObsPar>> ListarIAtencionObsParxID(int v_idnumreg, string v_periodo, string v_mes);
        Task<IEnumerable<getAtencionDIAObs>> ListarIAtencionDIARecxID(int v_idnumreg);
        Task<IEnumerable<getAtencionMEDObs>> ListarIAtencionMEDRecxID(int v_idnumreg);
        Task<IEnumerable<getAtencionAPOObs>> ListarIAtencionAPORecxID(int v_idnumreg);
        Task<IEnumerable<getAtencionINSObs>> ListarIAtencionINSRecxID(int v_idnumreg);

        Task<IEnumerable<getMasterBruto>> ListarMasterBrutoxID(int v_idnumreg);
        Task<IEnumerable<getMasterNeto>> ListarMasterNetoxID(int v_idnumreg);

    }
}

