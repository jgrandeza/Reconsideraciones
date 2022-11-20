using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services.IServices;
using App.Tools;
using App.ViewModels;
using App.ViewModels.INSReconsideraciones;
using App.ViewModels.Maestros;
using App.ViewModels.SolicitudRecon;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Web.Controllers
{
    public class BusqReconsideracionEvalController : Controller
    {
        // GET: /<controller>/
        private readonly IReadSolicitudRecon _IReadSolicitudRecon;
        private readonly IResumenRec _ResumenRec;
        private readonly IINSReconsideraciones _INSReconsideraciones;
        private readonly IUPDReconsideraciones _uPDReconsideraciones;
        private readonly IMaestros _Maestros;
        public BusqReconsideracionEvalController(IReadSolicitudRecon ReadSolicitudRecon, IResumenRec resumenRec,
            IINSReconsideraciones reconsideraciones, IUPDReconsideraciones uPDReconsideraciones, IMaestros maestros)
        {
            _IReadSolicitudRecon = ReadSolicitudRecon;
            _ResumenRec = resumenRec;
            _INSReconsideraciones = reconsideraciones;
            _uPDReconsideraciones = uPDReconsideraciones;
            _Maestros = maestros;

        }

        public async Task<IActionResult> Index()
        {

            ViewBag.Titulo = "BUSQUEDA DE SOLICITUD DE RECONSIDERACIONES";

            var usuario = await AutenticacionHelper.GetUsuario(HttpContext);

            var Periodos = new SetPeriodosDISAEESS()
            {
                V_TIPO_CONSULTA = "1",
                V_DISA = usuario.USU_DISA,
                V_EESS = usuario.EESS_IDESTABLECIMIENTO
            };

            var Filtro = new setEESSXUE()
            {
                P_V_DISA = usuario.USU_DISA,
                P_V_UE = usuario.USU_UE,
                P_V_IDEESS = usuario.EESS_IDESTABLECIMIENTO,
                P_V_TIPO = "DISA"
            };

            var DISA = await _Maestros.ListarESSXUE(Filtro);
            ViewBag.DISA = DISA;

            var Filtro_DISA = new setEESSXUE()
            {
                P_V_DISA = usuario.USU_DISA,
                P_V_UE = usuario.USU_UE,
                P_V_IDEESS = usuario.EESS_IDESTABLECIMIENTO,
                P_V_TIPO = "UEJE"
            };

            var UE = await _Maestros.ListarESSXUE(Filtro_DISA);
            ViewBag.UE = UE;

            var Filtro_EESS = new setEESSXUE()
            {
                P_V_DISA = usuario.USU_DISA,
                P_V_UE = usuario.USU_UE,
                P_V_IDEESS = usuario.EESS_IDESTABLECIMIENTO,
                P_V_TIPO = "EVAL"
            };

            var EESS = await _Maestros.ListarESSXUE(Filtro_EESS);
            ViewBag.EESS = EESS;

            var result = await _IReadSolicitudRecon.GetPeriodosDISAEESS(Periodos);
            ViewBag.RecPeriodo = result;
            var TipoTarifario = await _IReadSolicitudRecon.GetTipoTarifario();
            ViewBag.TipoTarifario = TipoTarifario;
            var TipoObservacion = await _IReadSolicitudRecon.GetTipoObservacion();
            ViewBag.TipoObservacion = TipoObservacion;
            var EstadosRecon = await _IReadSolicitudRecon.GetEstadoReconsideracion();
            ViewBag.EstadosRecon = EstadosRecon;
            return PartialView();
        }
        public IActionResult FiltroFuaReconsEvalV()
        {
            ViewBag.Titulo_Modal = "BUSQUEDA POR NUMERO DE FUA";
            return PartialView();
        }
        public async Task<IActionResult> CargarRangoPeriodoRec(SetRangoPeriodoRec model)
        {
            try
            {

                var PeriodoRec = await _IReadSolicitudRecon.GetRangoPeriodoRec(model);
                var PeriodoProc = await _IReadSolicitudRecon.GetPeriodoProcAtc(model);

                if (PeriodoRec != null)
                {
                    return new JsonResult(new Response { IsSuccess = true, Result = PeriodoRec, Result2 = PeriodoProc });
                }
                else
                {
                    return new JsonResult(new Response { IsSuccess = false });
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<IActionResult> GetReconsideracionesEvalV(string periodo, int filtro, string fua, string eess)
        {
            var V_IDEESS = eess;

            var anio = periodo.Substring(0, 4);
            var mes = "";
            if (periodo.Length == 6)
            {
                mes = "0" + periodo.ToString().Substring(5, 1);
            }
            else
            {
                mes = periodo.ToString().Substring(5, 2);
            }


            var dato = new setResumenReconsDto()
            {
                V_IDEESS = V_IDEESS,
                V_PERIODO = anio + mes,
                V_FILTROFUA = filtro,
                V_FUA = fua
            };
            var resumen = await _ResumenRec.ListarResumenReconsideracion(dato);

            return PartialView(resumen);
        }
        public IActionResult FiltroFuaReconsEESSV()
        {
            ViewBag.Titulo_Modal = "BUSQUEDA POR NUMERO DE FUA";
            return PartialView();
        }


        public async Task<IActionResult> RegistrarEvaluacion(int id)
        {
            try
            {
                var result = await _uPDReconsideraciones.ActualizarAteEval(id);

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

        public async Task<IActionResult> CargarUE(string DISA)
        {
            try
            {
                var usuario = await AutenticacionHelper.GetUsuario(HttpContext);
                var Filtro_DISA = new setEESSXUE()
                {
                    P_V_DISA = DISA,
                    P_V_UE = usuario.USU_UE,
                    P_V_IDEESS = usuario.EESS_IDESTABLECIMIENTO,
                    P_V_TIPO = "UEJE"
                };

                var result = await _Maestros.ListarESSXUE(Filtro_DISA);

                if (result != null)
                {
                    return new JsonResult(new Response { IsSuccess = true, Result = result });
                }
                else
                {
                    return new JsonResult(new Response { IsSuccess = false });
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IActionResult> CargarEESS(string DISA, string UE)
        {
            try
            {
                var usuario = await AutenticacionHelper.GetUsuario(HttpContext);
                var Filtro_UE = new setEESSXUE()
                {
                    P_V_DISA = DISA,
                    P_V_UE = UE,
                    P_V_IDEESS = usuario.EESS_IDESTABLECIMIENTO,
                    P_V_TIPO = "EVAL"
                };

                var result = await _Maestros.ListarESSXUE(Filtro_UE);

                if (result != null)
                {
                    return new JsonResult(new Response { IsSuccess = true, Result = result });
                }
                else
                {
                    return new JsonResult(new Response { IsSuccess = false });
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}

