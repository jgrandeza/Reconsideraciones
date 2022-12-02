using Microsoft.AspNetCore.Mvc;
using App.Services.IServices;
using App.ViewModels.INSReconsideraciones;
using App.ViewModels.SELReconsideraciones; 
using System.Security.Claims;
using App.Tools;
using App.ViewModels;
using App.ViewModels.DELReconsideraciones;
using static App.ViewModels.DELReconsideraciones.DELReconsideraciones;
using App.ViewModels.Maestros;
using System.Security.Cryptography;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace App.Web.Controllers
{
    public class SolicitudAmpliacionController : Controller
    {
        private readonly ISELReconsideraciones _SELReconsideraciones;
        private readonly IDELReconsideraciones _DELReconsideraciones;
        private readonly IUPDReconsideraciones _UPDReconsideraciones;
        private readonly IMaestros _Maestros;

        public SolicitudAmpliacionController(ISELReconsideraciones sELReconsideraciones,
           IDELReconsideraciones dELReconsideraciones,
           IUPDReconsideraciones uPDReconsideraciones
           , IMaestros maestros)
        {
            _SELReconsideraciones = sELReconsideraciones;
            _DELReconsideraciones = dELReconsideraciones;
            _UPDReconsideraciones = uPDReconsideraciones;
            _Maestros = maestros;
        }
        public IActionResult Index()
        {
            var usuarioP =  App.Tools.AutenticacionHelper.GetUsuario(HttpContext);
            if (usuarioP.Result.ID_SUBMODULO== "396") {
                ViewBag.submodulo ="2" ;
                ViewBag.Titulo = "Solicitud de ampliación de plazo para el registro de  Reconsideraciones";
            }
            if (usuarioP.Result.ID_SUBMODULO == "397")
            {
                ViewBag.submodulo = "1";
                ViewBag.Titulo = "Evaluación solicitudes de ampliación de plazo para el registro de  Reconsideraciones";
            }
         
            
            //aca pusistes return view();
            return PartialView();
        }

        public async Task<IActionResult> AccionSolicitudAmpliacion(string tipo, int id)
        {
            
            if (Convert.ToInt32(tipo) == 1)
            {
                ViewBag.Tipo = tipo;
                ViewBag.Titulo_Modal = "REGISTRO DE SOLICITUD DE AMPLIACIÓN";
                

            }
            if (Convert.ToInt32(tipo) == 2)
            {
                ViewBag.Tipo = tipo;
                ViewBag.Titulo_Modal = "SOLICITUD DE AMPLIACIÓN GENERADA";
            }

            if (Convert.ToInt32(tipo) == 3)
            {
                ViewBag.Tipo = tipo;
                ViewBag.Titulo_Modal = "EVALUACIÓN DE SOLICITUD DE AMPLIACIÓN";
            }

            ViewBag.vbId = id;
            //ViewBag.ObjPeriodo = result;
            return PartialView();
        }
        public async Task<IActionResult> ListSolicitud(string id)//tipo 2 Solicitante tipo1 Evaluador
        {
            var usuario = await App.Tools.AutenticacionHelper.GetUsuario(HttpContext);

            var result = await _SELReconsideraciones.ListSolicitudAmpliacion(usuario.Name, id);

            return PartialView(result);

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

        public async Task<IActionResult> CargarDISA(string id) {

            try
            {
                if (id == "" || id == "000"|| id ==  null)
                {
                    var usuario = await App.Tools.AutenticacionHelper.GetUsuario(HttpContext);
                    id = usuario.USU_DISA;
                }
                 
                
                var Filtro_DISA = new setEESSXUE()
                {
                    P_V_DISA = id,
                    P_V_UE = "",
                    P_V_IDEESS = "",
                    P_V_TIPO = "COMBOSD"
                };
                var pDISA = await _Maestros.ListarESSXUE(Filtro_DISA);

                ViewBag.pidDISA = Filtro_DISA.P_V_DISA;
                if (pDISA != null)
                {
                    return new JsonResult(new { IsSuccess = true, Result = pDISA });
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
        public async Task<IActionResult> CargarUE(string id, string disa)
        {

            try
            {
                if (id == "" || id == "0000" || id == null)
                {
                    var usuario = await App.Tools.AutenticacionHelper.GetUsuario(HttpContext);
                    id = usuario.USU_UE;
                }
                       

                var Filtro_UE = new setEESSXUE()
                {
                    P_V_DISA = disa,
                    P_V_UE = id,
                    P_V_IDEESS = "",
                    P_V_TIPO = "COMBOSU"
                };

                var pUE = await _Maestros.ListarESSXUE(Filtro_UE);
 

                if (pUE != null)
                {
                    return new JsonResult(new { IsSuccess = true, Result = pUE });
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
        public async Task<IActionResult> CargarEESS(string id)
        {


            try
            {
                if (id == "" || id == "0000")
                {
                    var usuario = await App.Tools.AutenticacionHelper.GetUsuario(HttpContext);
                    id = usuario.EESS_CODIGOSIS;
                }

                

                var Filtro_EESS = new setEESSXUE()
                {
                    P_V_DISA = "",
                    P_V_UE = id,
                    P_V_IDEESS = "",
                    P_V_TIPO = "COMBOSE"
                };
                var pEESS = await _Maestros.ListarESSXUE(Filtro_EESS);


                if (pEESS != null)
                {
                    return new JsonResult(new { IsSuccess = true, Result = pEESS });
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

        public async Task<IActionResult> CargarOtros(string id)
        {

            try
            {
                if (id == "periodo")
                {
                    var result = await _SELReconsideraciones.ListPeriodo("PERIODO");
                    if (result != null)
                    {
                        return new JsonResult(new { IsSuccess = true, Result = result });
                    }
                    else
                    {
                        return new JsonResult(new { IsSuccess = false });
                    }
                }
                else { 
                    var result = await _SELReconsideraciones.ListMesxPeriodo(id);
                    if (result != null)
                    {
                        return new JsonResult(new { IsSuccess = true, Result = result });
                    }
                    else
                    {
                        return new JsonResult(new { IsSuccess = false });
                    }
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

        [HttpPost]
        public async Task<IActionResult> ActualizarSolicitud(setSolicitudAmpliacion model)
        {
            try
            {
                var usuario = await App.Tools.AutenticacionHelper.GetUsuario(HttpContext);


                var solicitud = new setSolicitudAmpliacion()
                {
                    IDNUMREG = model.IDNUMREG,
                    ESTADO = model.ESTADO,
                    USUEVALUA = usuario.Name

                };

                var result = await _UPDReconsideraciones.ActualizarSolicitudAmpliacion(solicitud);

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
