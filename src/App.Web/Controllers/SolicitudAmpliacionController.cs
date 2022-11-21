using Microsoft.AspNetCore.Mvc;
using App.Services.IServices;
using App.ViewModels.INSReconsideraciones;
using App.ViewModels.SELReconsideraciones; 
using System.Security.Claims;
using App.Tools;
using App.ViewModels;
using App.ViewModels.DELReconsideraciones;
using static App.ViewModels.DELReconsideraciones.DELReconsideraciones;

namespace App.Web.Controllers
{
    public class SolicitudAmpliacionController : Controller
    {
        private readonly ISELReconsideraciones _SELReconsideraciones;
        private readonly IDELReconsideraciones _DELReconsideraciones;
        public IActionResult Index()
        {
            ViewBag.Titulo = "Solicitud de ampliación de plazo para el registro de  Reconsideraciones";

            return View();
        }

        public async Task<IActionResult> ListSolicitud()
        {
            var result = await _SELReconsideraciones.ListSolicitud();

            return PartialView(result);

        }

        public async Task<IActionResult> AccionSolicitud(string tipo, int id)
        {
            if (Convert.ToInt32(tipo) == 1)
            {
                ViewBag.Tipo = tipo;
                ViewBag.Titulo_Modal = "REGISTRO DE SOLICITUD";
            }
            else if (Convert.ToInt32(tipo) == 2)
            {
                ViewBag.Tipo = tipo;
                ViewBag.Titulo_Modal = "EVALUACIÓN DE SOLICITUD";
            }

            ViewBag.vbId = id;
            //ViewBag.ObjPeriodo = result;
            return PartialView();
        }

        public async Task<IActionResult> ConsultarSolicitudPorId(int id)
        {
            try
            {
                var result = await _SELReconsideraciones.ConsultarSolicitudxID(id);

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

        public async Task<IActionResult> InsertarSolicitud(GetSolicitudAmpliacion datos)
        {
            try
            {

                var usuario = await App.Tools.AutenticacionHelper.GetUsuario(HttpContext);

                var result = await _SELReconsideraciones.InsertarSolicitud(datos, usuario.Name);

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

        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                var result = new Mensaje_Del();

                result = await _DELReconsideraciones.EliminarSolicitud(id);


                if (result.CODIGO == 0)
                {
                    return new JsonResult(new { IsSuccess = true, Message = result.MENSAJE });
                }
                else
                {
                    return new JsonResult(new { IsSuccess = false, Message = result.MENSAJE });
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { IsSuccess = false, Message = "Algo salio mal intente mas tarde." });

            }

        }
    }
}
