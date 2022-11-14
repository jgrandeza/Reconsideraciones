using App.Tools;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    public class ModulosController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var oResultado = await AutenticacionHelper.GetUsuario(HttpContext);

            ViewBag.USU_USUARIO = oResultado.Name;
            ViewBag.USU_DNI = oResultado.USU_DNI;
            ViewBag.LUGARTRAB_DESC = oResultado.LUGARTRAB_DESC;
            ViewBag.USU_NOMBREUSUARIO = oResultado.USU_NOMBREUSUARIO;

            return View();
        }
		public async Task<IActionResult> AccionesModulos()
		{
			
			return PartialView();
		}
	}
}
