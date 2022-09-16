using App.Data;
using App.Services.IServices;
using App.ViewModels.INSReconsideraciones;
using Microsoft.AspNetCore.Mvc;
using static App.ViewModels.SELSiasis.SELSiasis;

namespace App.Web.Controllers
{
    public class VisorFUAController : Controller
    {
        private readonly ISELSiasis _sELSiasis;
        public VisorFUAController(ISELSiasis sELSiasis)

        {
            _sELSiasis = sELSiasis;
        }

        public async Task<IActionResult> Index(int dt)
        {
            var FUA = await _sELSiasis.ListarIAtencionRecxID(dt);

            ViewBag.Tipo = 1;
            ViewBag.Numregate = dt;
            return View(FUA);
        }

        
        public async Task<IActionResult> ValorizacionFUAV(int id) 
        {



            var dt1 = await _sELSiasis.ListarMasterBrutoxID(id);
            var dt2 = await _sELSiasis.ListarMasterNetoxID(id);
            ViewBag.Neto = dt2.First();
           
           
            return PartialView(dt1.First());
        }

        public async Task<IActionResult> ObserTotalFUAV(int id, string v_periodo, string v_mes)
        {
            var TOTAL = await _sELSiasis.ListarIAtencionObsTotxID(id,v_periodo,v_mes);

            return PartialView(TOTAL);
        }
        public async Task<IActionResult> ObserParcialFUAV(int id, string v_periodo, string v_mes)
        {
            var PART = await _sELSiasis.ListarIAtencionObsParxID(id,v_periodo,v_mes);

            return PartialView(PART);
        }
        public async Task<IActionResult> DiagnosticosFUAV(int id)
        {
            var DIA = await _sELSiasis.ListarIAtencionDIARecxID(id);

            return PartialView(DIA);
        }
        public async Task<IActionResult> MedicamentosFUAV(int id)
        {
            var MED = await _sELSiasis.ListarIAtencionMEDRecxID(id);
            return PartialView(MED);
        }
        public async Task<IActionResult> ProcedimientosFUAV(int id)
        {
            var APO = await _sELSiasis.ListarIAtencionAPORecxID(id);

            return PartialView(APO);
        }
        public async Task<IActionResult> InsumosFUAV(int id)
        {
            var INS = await _sELSiasis.ListarIAtencionINSRecxID(id);

            return PartialView(INS);
        }
        public IActionResult MaternoInfantilFUAV(int id)
        {

            return PartialView();
        }
    }
}
