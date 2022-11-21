using App.Models;
using App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace App.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly Auth _auth;
        private readonly UsuarioClaimsDto usuario2;
        
        public AccountController(IOptions<Auth> auth)
        {
            _auth = auth.Value;
            
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public  async Task<IActionResult> SalirMenu()
        {
            var usuario = await App.Tools.AutenticacionHelper.GetUsuario(HttpContext);
            //return Redirect(_auth.entorno);
            return Redirect(_auth.entorno + "/sisAcceso/Retorno?sts=" + usuario.TOKENSALIDA);
           // return View();
        }
    }
}
