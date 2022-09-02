using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using App.Services.IServices;
using App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Web.Controllers
{
    public class FUAController : Controller
    {
        // GET: /<controller>/

        private readonly DataContextApp _dbContext;
        private readonly IAuxiliares _Auxiliares;
        private readonly IMaestros _Maestros;
        private readonly ISELReconsideraciones _SELReconsideraciones;
        public FUAController(DataContextApp dbContext, IAuxiliares auxiliares, IMaestros maestros, ISELReconsideraciones sELReconsideraciones)
        {
            _dbContext = dbContext;
            _Auxiliares = auxiliares;
            _Maestros = maestros;
            _SELReconsideraciones = sELReconsideraciones;
        }
        public IActionResult Index(int id)
        {
            ViewBag.DescDisa = "LIMA NORTE";
            ViewBag.DescUE = "HOSPITAL CARLOS LAFRNACO LA HOZ";
            ViewBag.DesEESS = "222222222-HOSPITALLANFRANCO";

            ViewBag.PeriodoRec = "2019-1 del 01/07/2022 al 26/08/2022";

            ViewBag.Titulo = "REGISTRO DE FUA DE RECONSIDERACIÓN DE PRESTACIONES RM-240 Y RM-226";

            ViewBag.ATE_IDNUMREG = id;
            
            return PartialView();
        }



        public async Task<IActionResult> InfGeneralFUAV(int id)
        {
            try
            {
                var Componente = await _Auxiliares.ListarComponentes();
                ViewBag.LisComponente = Componente;

                var TipoDocIdent = await _Auxiliares.ListarTipoDocIdentidad();
                ViewBag.ListTipoDocIdent= TipoDocIdent;

                var genero = await _Auxiliares.ListarSexo();
                ViewBag.ListGenero = genero;

                var TipoAtenc = await _Auxiliares.ListarTipoAtencion();
                ViewBag.ListTipoAtenc = TipoAtenc;

                var Servicios = await _Maestros.ListarServicios();
                ViewBag.ListServicios = Servicios;

                var LugarAte = await _Auxiliares.ListarLugarAtencion();
                ViewBag.ListLugarAte = LugarAte;

                var CondMaterna = await _Auxiliares.ListarCondicionMaterna();
                ViewBag.ListCondiMaterna = CondMaterna;


            }
            catch (Exception aa)
            {
                
                throw;
            }


            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AtencionxID(int id)
        {
            try
            {
                var result = await _SELReconsideraciones.ListarIAtencionRecxID(id);


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

        public async Task<IActionResult> DiagnosticosFUAV(int id)
        {
            var result = await _SELReconsideraciones.ListarIAtencionDIAxID(id);

            return PartialView(result);
        }

        public async Task<IActionResult> AccionDiagnosticoFUAV(string tipo, int id)
        {
            if (Convert.ToInt32(tipo) == 1)
            {
                ViewBag.Tipo = tipo;
                ViewBag.Titulo_Modal = "REGISTRO DEL DIAGNOSTICO";
            }
            else if (Convert.ToInt32(tipo) == 2)
            {
                ViewBag.Tipo = tipo;
                ViewBag.Titulo_Modal = "ACTUALIZACIÓN DEL DIAGNOSTICO";
            }
            var result = await _Auxiliares.ListarTipoDiagnostico();
            ViewBag.ListTipoDX = result;

            return PartialView();
        }

        public async Task<IActionResult> MedicamentosFUAV(int id)
        {
            var result = await _SELReconsideraciones.ListarIAtencionMEDxID(id);

            return PartialView(result);
        }

        public IActionResult AccionMedicamentosFUAV(string tipo, int id)
        {
            if (Convert.ToInt32(tipo) == 1)
            {
                ViewBag.Tipo = tipo;
                ViewBag.Titulo_Modal = "REGISTRO DE MEDICAMENTO";
            }
            else if (Convert.ToInt32(tipo) == 2)
            {
                ViewBag.Tipo = tipo;
                ViewBag.Titulo_Modal = "ACTUALIZACIÓN DEL MEDICAMENTO";
            }


            return PartialView();
        }

        public async Task<IActionResult> ProcedimientosFUAV(int id)
        {

            var result = await _SELReconsideraciones.ListarIAtencionAPOxID(id);

            return PartialView(result);
        }

        public IActionResult AccionProcedimientosFUAV(string tipo, int id)
        {
            if (Convert.ToInt32(tipo) == 1)
            {
                ViewBag.Tipo = tipo;
                ViewBag.Titulo_Modal = "REGISTRO DE PROCEDIMIENTOS";
            }
            else if (Convert.ToInt32(tipo) == 2)
            {
                ViewBag.Tipo = tipo;
                ViewBag.Titulo_Modal = "ACTUALIZACIÓN DEL PROCEDIMIENTO";
            }


            return PartialView();
        }

        
        public async Task<IActionResult> InsumosFUAV(int id)
        {
            var result = await _SELReconsideraciones.ListarIAtencionINSxID(id);

            return PartialView(result);
        }
        public IActionResult AccionInsumosFUAV(string tipo, int id)
        {
            if (Convert.ToInt32(tipo) == 1)
            {
                ViewBag.Tipo = tipo;
                ViewBag.Titulo_Modal = "REGISTRO DE INSUMO";
            }
            else if (Convert.ToInt32(tipo) == 2)
            {
                ViewBag.Tipo = tipo;
                ViewBag.Titulo_Modal = "ACTUALIZACIÓN DEL INSUMO";
            }


            return PartialView();
        }


        
        public IActionResult MaternoInfantilFUAV(int id)
        {

            return PartialView();
        }
    }
}

