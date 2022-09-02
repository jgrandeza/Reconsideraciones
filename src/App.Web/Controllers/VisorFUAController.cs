using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    public class VisorFUAController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Tipo = 1;
            return View();
        }
        public IActionResult ObserTotalFUAV(int id)
        {

            return PartialView();
        }
        public IActionResult ObserParcialFUAV(int id)
        {

            return PartialView();
        }
        public IActionResult DiagnosticosFUAV(int id)
        {

            return PartialView();
        }
        public IActionResult MedicamentosFUAV(int id)
        {

            return PartialView();
        }
        public IActionResult ProcedimientosFUAV(int id)
        {

            return PartialView();
        }
        public IActionResult InsumosFUAV(int id)
        {

            return PartialView();
        }
        public IActionResult MaternoInfantilFUAV(int id)
        {

            return PartialView();
        }
    }
}
