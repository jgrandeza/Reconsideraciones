using App.ViewModels.Maestros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.IServices
{
    public interface IMaestros
    {
        Task<IEnumerable<getServicios>> ListarServicios();

    }
}
