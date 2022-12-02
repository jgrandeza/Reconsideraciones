using App.Services.IServices;
using App.Tools;
using App.ViewModels;
using App.ViewModels.Maestros;
using App.ViewModels.SolicitudRecon;
using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly IReadSolicitudRecon _IReadSolicitudRecon;
        private readonly IResumenRec _ResumenRec;
 
        private readonly IMaestros _Maestros;
        private readonly IRptReconsideraciones _rptReconsideraciones;
        public ConsultaController(IReadSolicitudRecon ReadSolicitudRecon, IResumenRec resumenRec,
            IINSReconsideraciones reconsideraciones, IMaestros maestros, IRptReconsideraciones rptReconsideraciones)
        {
            _IReadSolicitudRecon = ReadSolicitudRecon;
            _ResumenRec = resumenRec;
            _Maestros = maestros;
            _rptReconsideraciones = rptReconsideraciones;
        }

        public async Task<IActionResult> Index(string periodo, string establecimiento)
        {
            var usuario = await AutenticacionHelper.GetUsuario(HttpContext);
            ViewBag.usu = usuario.Name;
            ViewBag.usuee = usuario.EESS_CODIGOSIS;
            ViewBag.usuue = usuario.USU_UE;
            ViewBag.usudisa = usuario.USU_DISA;
            ViewBag.usuodsis = usuario.USU_ODSIS;
            ViewBag.usurol = usuario.IDROL;
            ViewBag.ususubm = usuario.ID_SUBMODULO;

            ViewBag.DescDisa = usuario.DISA_DESCRIPCION;
            ViewBag.DescUE = usuario.UE_DESCRIPCION;
            ViewBag.DesEESS = usuario.ESTABLECIMIENTO_DESC;
            ViewBag.Titulo = "CONSULTA DE RECONSIDERACIONES";

            var Periodos = new SetPeriodosDISAEESS()
            {
                V_TIPO_CONSULTA = "1",
                V_DISA = "SOL",//usuario.USU_DISA,
                V_EESS = usuario.EESS_CODIGOSIS
            };

            var Filtro_EESS = new setEESSXUE()
            {
                P_V_DISA = usuario.USU_DISA,
                P_V_UE = usuario.USU_UE,
                P_V_IDEESS = usuario.EESS_CODIGOSIS,
                P_V_TIPO = "SOL"
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

            ViewBag.Periodo = periodo;
            if (periodo != null) {
              await  GetReconsideracionesEESSV(periodo, 1, "", establecimiento);
            }
            

            return PartialView();
        }

        public async Task<IActionResult> GetReconsideracionesEESSV(string periodo, int filtro, string fua, string eess)
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

            ViewBag.exportar = dato;

            return PartialView(resumen);
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

    }
}
