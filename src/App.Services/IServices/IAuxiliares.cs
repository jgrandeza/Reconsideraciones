using App.ViewModels.Auxiliares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.IServices
{
    public interface IAuxiliares
    {
        Task<IEnumerable<getComponentes>> ListarComponentes();
        Task<IEnumerable<getTipoDocIdentidad>> ListarTipoDocIdentidad();
        Task<IEnumerable<getSexo>> ListarSexo();
        Task<IEnumerable<getTipoAtencion>> ListarTipoAtencion();
        Task<IEnumerable<getLugarAtencion>> ListarLugarAtencion();
        Task<IEnumerable<getCondicionMaterna>> ListarCondicionMaterna();
        Task<IEnumerable<getTipoDiagnostico>> ListarTipoDiagnostico();
        Task<IEnumerable<getTipoModalidadAte>> ListarTipoModalidadAte(string V_TIPOMODALIDAD);
        Task<IEnumerable<getOrigenPersonal>> ListarOrigenPersonal(string V_CODIGO);
    }
}
