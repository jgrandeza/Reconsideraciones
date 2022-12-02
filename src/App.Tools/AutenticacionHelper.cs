using App.Models;
using App.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App.Tools
{
    public class AutenticacionHelper
    {
        public static async Task<UsuarioClaimsDto> GetUsuario(HttpContext currentUser)
        {
            UsuarioClaimsDto usuario = new UsuarioClaimsDto();
            int UsuarioId = 0;
            try
            {
                int.TryParse(currentUser.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value, out UsuarioId);
                usuario.Id = UsuarioId;
                usuario.Name = currentUser.User.FindFirst(ClaimTypes.Name)?.Value;
                usuario.USU_NOMBREUSUARIO = currentUser.User.Claims.FirstOrDefault(c => c.Type == "USU_NOMBREUSUARIO").Value;
                usuario.IDROL = currentUser.User.Claims.FirstOrDefault(c => c.Type == "IDROL").Value;
                usuario.ROL_DESCRIPCION = currentUser.User.Claims.FirstOrDefault(c => c.Type == "ROL_DESCRIPCION").Value;
                usuario.USU_PPDD = currentUser.User.Claims.FirstOrDefault(c => c.Type == "USU_PPDD").Value;
                usuario.Foto = currentUser.User.Claims.FirstOrDefault(c => c.Type == "Foto").Value;
                usuario.ID_SUBMODULO = currentUser.User.Claims.FirstOrDefault(c => c.Type == "ID_SUBMODULO").Value;
                usuario.USU_DISA = currentUser.User.Claims.FirstOrDefault(c => c.Type == "USU_DISA").Value;
                usuario.USU_UE = currentUser.User.Claims.FirstOrDefault(c => c.Type == "USU_UE").Value;
                usuario.EESS_CODIGOSIS = currentUser.User.Claims.FirstOrDefault(c => c.Type == "EESS_CODIGOSIS").Value;
                usuario.USU_ODSIS = currentUser.User.Claims.FirstOrDefault(c => c.Type == "USU_ODSIS").Value;
                usuario.ID_MACROREGION = currentUser.User.Claims.FirstOrDefault(c => c.Type == "ID_MACROREGION").Value;
                usuario.USU_DNI = currentUser.User.Claims.FirstOrDefault(c => c.Type == "USU_DNI").Value;
                usuario.USU_EMAILINSTITUCIONAL = currentUser.User.Claims.FirstOrDefault(c => c.Type == "USU_EMAILINSTITUCIONAL").Value; 
                //usuario.V_V_USU_EMAIL = currentUser.User.Claims.FirstOrDefault(c => c.Type == "V_V_USU_EMAIL").Value;
                usuario.LUGARTRAB_DESC = currentUser.User.Claims.FirstOrDefault(c => c.Type == "LUGARTRAB_DESC").Value;
                usuario.TOKENSESION = currentUser.User.Claims.FirstOrDefault(c => c.Type == "TOKENSESION").Value;
                usuario.TOKENSALIDA = currentUser.User.Claims.FirstOrDefault(c => c.Type == "TOKENSALIDA").Value;
                usuario.EESS_IDESTABLECIMIENTO = currentUser.User.Claims.FirstOrDefault(c => c.Type == "EESS_IDESTABLECIMIENTO").Value;
                usuario.DISA_DESCRIPCION = currentUser.User.Claims.FirstOrDefault(c => c.Type == "DISA_DESCRIPCION").Value;
                usuario.UE_DESCRIPCION = currentUser.User.Claims.FirstOrDefault(c => c.Type == "UE_DESCRIPCION").Value;
                usuario.ESTABLECIMIENTO_DESC = currentUser.User.Claims.FirstOrDefault(c => c.Type == "ESTABLECIMIENTO_DESC").Value;
                usuario.PROGRAMADOR = currentUser.User.Claims.FirstOrDefault(c => c.Type == "PROGRAMADOR").Value;

            }
            catch (Exception ex)
            {
                var err = ex.Message.ToString();
            }
            return usuario;
        }
    }
}
