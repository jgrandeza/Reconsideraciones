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
                case "391":
                    submodulo = "/SolicitudReconsideracion/Index";
                    break;
                case "394":
                    submodulo = "/BusqReconsideracionEval/Index";
                    break;
                case "395":
                    submodulo = "/Reportes/Index";
                    break;
                case "396"://solicitud
                    submodulo = "/SolicitudAmpliacion/Index";
                    break;
                case "397"://evaluación
                    submodulo = "/SolicitudAmpliacion/Index";
                    break;
                case "398":
                    submodulo = "/Periodo/Index";
                    break;
                case "399":
                    submodulo = "/Consulta/Index";
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


            return PartialView();
        }
		public async Task<IActionResult> AccionesModulos()
		{
			
			return PartialView();
		}
	}
}
