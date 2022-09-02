using App.ViewModels.SolicitudRecon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.IServices
{
    public interface IResumenRec
    {
        Task<IEnumerable<getResumenReconsDto>> ListarResumenReconsideracion(setResumenReconsDto model);
    }
}
