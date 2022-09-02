using App.Models;
using App.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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
                usuario.NombreUsuario = currentUser.User.Claims.FirstOrDefault(c => c.Type == "NombreUsuario").Value;
                usuario.Nombres = currentUser.User.Claims.FirstOrDefault(c => c.Type == "Nombres").Value;
                usuario.Email = currentUser.User.Claims.FirstOrDefault(c => c.Type == "Email").Value;
                usuario.Foto = currentUser.User.Claims.FirstOrDefault(c => c.Type == "Foto").Value;
                usuario.PerfilId= currentUser.User.Claims.FirstOrDefault(c => c.Type == "PerfilId").Value;
                usuario.UnidadEjecutoraId = Convert.ToInt32(currentUser.User.Claims.FirstOrDefault(c => c.Type == "UnidadEjecutoraId").Value);
            }
            catch (Exception ex)
            {
                var err = ex.Message.ToString();
            }
            return usuario;
        }
    }
}
