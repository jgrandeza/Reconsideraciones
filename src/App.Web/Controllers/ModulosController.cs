using App.Tools;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    public class ModulosController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var oResultado = await AutenticacionHelper.GetUsuario(HttpContext);
            var submodulo = "";

            switch (oResultado.ID_SUBMODULO)
            {
                case "393":
                    submodulo = "/SolicitudReconsideracion/Index";
                    break;
                case "395":
                    submodulo = "/BusqReconsideracionEval/Index";
                    break;
                case "1":
                    submodulo = "/Periodo/Index";
                    break;
                case "":
                    break;

            } 

            ViewBag.USU_USUARIO = oResultado.Name;
            ViewBag.USU_DNI = oResultado.USU_DNI;
            ViewBag.LUGARTRAB_DESC = oResultado.LUGARTRAB_DESC;
            ViewBag.USU_NOMBREUSUARIO = oResultado.USU_NOMBREUSUARIO;
            ViewBag.Programador = oResultado.PROGRAMADOR;// "local";
            ViewBag.ruta = submodulo;


            return View();
        }
		public async Task<IActionResult> AccionesModulos()
		{
			
			return PartialView();
		}
	}
}
