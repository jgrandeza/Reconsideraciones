using App.Services.IServices;
using App.ViewModels.INSReconsideraciones;
using App.ViewModels.SELReconsideraciones;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using App.Tools;
using App.ViewModels;

namespace App.Web.Controllers
{

    public class PeriodoController : Controller
    {
        private readonly ISELReconsideraciones _SELReconsideraciones; 
        public PeriodoController(ISELReconsideraciones sELReconsideraciones) {
            _SELReconsideraciones = sELReconsideraciones; 
        }

        public async Task<IActionResult> Index() 
        {
             
            ViewBag.Titulo = "Administración de Periodos de Reconsideraciones";
            //ViewBag.Model = Periodo;
            return PartialView();

             

        }

        public async Task<IActionResult> ListPeriodo() {
           var result = await _SELReconsideraciones.ListPeriodo();

            return PartialView(result);

        }
        public async Task<IActionResult> AccionPeriodo(string tipo, int id)
        {
            if (Convert.ToInt32(tipo) == 1)
            {
                ViewBag.Tipo = tipo;
                ViewBag.Titulo_Modal = "REGISTRO DEL PERIODO";
            }
            else if (Convert.ToInt32(tipo) == 2)
            {
                ViewBag.Tipo = tipo;
                ViewBag.Titulo_Modal = "ACTUALIZACIÓN DEL PERIODO";
            }
                        
            ViewBag.vbId = id; 
            //ViewBag.ObjPeriodo = result;
            return PartialView();
        }

        public async Task<IActionResult> ConsultarPeriodoPorId(int id)
        {
            try
            {
                var result = await _SELReconsideraciones.ConsultarPeriodoxID(id);

                if (result != null)
                {
                    return new JsonResult(new { IsSuccess = true, Result = result });
                }
                else
                {
                    return new JsonResult(new { IsSuccess = false });
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { IsSuccess = false });
            }

        }

        public async Task<IActionResult> InsertarPeriodo(GetPeriodo datos)
        {
            try
            {
                
                var usuario = await App.Tools.AutenticacionHelper.GetUsuario(HttpContext);
                
                var result = await _SELReconsideraciones.InsertarPeriodo(datos, usuario.Name);

                if (result.CODIGO == 0)
                {
                    return new JsonResult(new { IsSuccess = true, Message = result.MENSAJE });
                }
                else
                {
                    return new JsonResult(new { IsSuccess = false, Message = result.MENSAJE });
                }
            }
            catch (Exception)
            {
                return new JsonResult(new { IsSuccess = false });
            }
        }

    }
}
