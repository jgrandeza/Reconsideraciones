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
        Task<getServicios> ListarServicios( string V_IDSERVICIO);

       Task<getEESSxID> ListarEESSxID(string V_EESS);

        Task<getPersonalSaludxID> ListarPersSaluxID(string V_DNI);

        Task<GetDiagnosticoPorID> ListarDiagnosticoPorId(string V_C10_CODDIA);

        Task<GetApoDiagPorID> ListarApoDiagPorId(int IdID_FUA, string V_APO_CODAPO);
        
    }
}
