using App.ViewModels.SolicitudRecon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.IServices
{
    public interface IReadSolicitudRecon
    {
        Task<IEnumerable<GetPeriodosDISAEESS>> GetPeriodosDISAEESS(SetPeriodosDISAEESS model);
        Task<GetRangoPeriodoRec> GetRangoPeriodoRec(SetRangoPeriodoRec model);
        Task<IEnumerable<GetPeriodoProdAtc>> GetPeriodoProcAtc(SetRangoPeriodoRec model);
        Task<IEnumerable<GetFiltros>> GetTipoTarifario();
        Task<IEnumerable<GetFiltros>> GetTipoObservacion();
        Task<IEnumerable<GetFiltros>> GetEstadoReconsideracion();
    }
}