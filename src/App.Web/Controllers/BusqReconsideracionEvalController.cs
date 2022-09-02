using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Web.Controllers
{
    public class BusqReconsideracionEvalController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Titulo = "BUSQUEDA DE SOLICITUD DE RECONSIDERACIONES";
            return PartialView();
        }
        public IActionResult GetReconsideracionesEvalV()
        {

            return PartialView();
        }
        public IActionResult FiltroFuaReconsEvalV()
        {
            ViewBag.Titulo_Modal = "BUSQUEDA POR NUMERO DE FUA";
            return PartialView();
        }
    }
}

