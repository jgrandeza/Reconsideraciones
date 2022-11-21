﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using App.Services.IServices;
using App.Tools;
using App.ViewModels;
using App.ViewModels.Maestros;
using App.ViewModels.SolicitudRecon;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Web.Controllers
{
    public class SolicitudReconsideracionController : Controller
    {
        private readonly IReadSolicitudRecon _IReadSolicitudRecon;
        private readonly IResumenRec _ResumenRec;
        private readonly IINSReconsideraciones _INSReconsideraciones;
        private readonly IMaestros _Maestros;
        public SolicitudReconsideracionController(IReadSolicitudRecon ReadSolicitudRecon, IResumenRec resumenRec, 
            IINSReconsideraciones reconsideraciones, IMaestros maestros)
        {
            _IReadSolicitudRecon = ReadSolicitudRecon;
            _ResumenRec = resumenRec;
            _INSReconsideraciones = reconsideraciones;
            _Maestros = maestros;
        }


        // GET: /<controller>/
        public async Task<IActionResult> Index(string periodo)
        {

            var usuario = await AutenticacionHelper.GetUsuario(HttpContext);

            ViewBag.DescDisa = usuario.DISA_DESCRIPCION;
            ViewBag.DescUE = usuario.UE_DESCRIPCION;
            ViewBag.DesEESS = usuario.ESTABLECIMIENTO_DESC;
            ViewBag.Titulo = "SOLICITUD DE RECONSIDERACIÓN";

            var Periodos = new SetPeriodosDISAEESS()
            {
                V_TIPO_CONSULTA = "1",
                V_DISA = usuario.USU_DISA,
                V_EESS = usuario.EESS_IDESTABLECIMIENTO
            };

            var Filtro_EESS  = new setEESSXUE()
            {
                P_V_DISA= usuario.USU_DISA,
                P_V_UE = usuario.USU_UE,
                P_V_IDEESS = usuario.EESS_IDESTABLECIMIENTO,
                P_V_TIPO="SOL"
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
                    return new JsonResult(new Response { IsSuccess = true, Result = PeriodoRec, Result2 =PeriodoProc });
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

        public async Task<IActionResult> CargarPeriodo(string eess)
        {
            try
            {
                var usuario = await AutenticacionHelper.GetUsuario(HttpContext);
                var Periodos = new SetPeriodosDISAEESS()
                {
                    V_TIPO_CONSULTA = "1",
                    V_DISA = usuario.USU_DISA,
                    V_EESS = eess
                };

                var Periodo =  await _IReadSolicitudRecon.GetPeriodosDISAEESS(Periodos); ;

                if (Periodo != null)
                {
                    return new JsonResult(new Response { IsSuccess = true, Result = Periodo });
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

        

        public async Task<IActionResult> GetReconsideracionesEESSV( string periodo, int filtro, string fua, string eess)
        {
            var V_IDEESS = eess;

            var anio = periodo.Substring(0, 4);
            var mes = "";
            if (periodo.Length == 6)
            {
                mes = "0"+periodo.ToString().Substring(5, 1);
            }
            else
            {
                mes = periodo.ToString().Substring(5, 2);
            }
            
 
            var dato = new setResumenReconsDto()
            {
                V_IDEESS = V_IDEESS,
                V_PERIODO = anio+mes,
                V_FILTROFUA=filtro,
                V_FUA=fua
            };
            var resumen = await _ResumenRec.ListarResumenReconsideracion(dato);

            return PartialView(resumen);
        }
        public IActionResult FiltroFuaReconsEESSV()
        {
            ViewBag.Titulo_Modal = "BUSQUEDA POR NUMERO DE FUA";
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> RegistrarSolicitud(int id)
        {
            try
            {
                var usuario = await AutenticacionHelper.GetUsuario(HttpContext);
                var fecha_reg = DateTime.Now;


                var AteTotal = await _INSReconsideraciones.InsertarAtencionTotal(id, usuario.Name);

                if (AteTotal.OK==1)
                {
                    return new JsonResult(new Response { IsSuccess = true, Message = AteTotal.MSJ });

                }
                else
                {
                    return new JsonResult(new Response { IsSuccess = false, Message = AteTotal.MSJ });

                }

            }
            catch (Exception ex)
            {
                return new JsonResult(new Response { IsSuccess = false, Message = "Algo salio intente mas tarde." });
                throw;
            }
        }
    }
}

