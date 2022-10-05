using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using App.Services.IServices;
using App.ViewModels;
using App.ViewModels.INSReconsideraciones;
using App.ViewModels.SELReconsideraciones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static App.ViewModels.DELReconsideraciones.DELReconsideraciones;

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
        private readonly IUPDReconsideraciones _uPDReconsideraciones;
        private readonly IDELReconsideraciones _dELReconsideraciones;
        private readonly IINSReconsideraciones _iNSReconsideraciones;
        public FUAController(DataContextApp dbContext, IAuxiliares auxiliares, IMaestros maestros, ISELReconsideraciones sELReconsideraciones, IUPDReconsideraciones uPDReconsideraciones, IINSReconsideraciones iNSReconsideraciones, IDELReconsideraciones dELReconsideraciones)

        {
            _dbContext = dbContext;
            _Auxiliares = auxiliares;
            _Maestros = maestros;
            _SELReconsideraciones = sELReconsideraciones;
            _uPDReconsideraciones = uPDReconsideraciones;
            _dELReconsideraciones = dELReconsideraciones;
            _iNSReconsideraciones = iNSReconsideraciones;
        }
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.DescDisa = "LIMA NORTE";
            ViewBag.DescUE = "HOSPITAL CARLOS LAFRNACO LA HOZ";
            ViewBag.DesEESS = "222222222-HOSPITALLANFRANCO";

            ViewBag.PeriodoRec = "2019-1 del 01/07/2022 al 26/08/2022";

            ViewBag.Titulo = "REGISTRO DE FUA DE RECONSIDERACIÓN DE PRESTACIONES RM-240 Y RM-226";

            await RecEstado(id);

            ViewBag.ATE_IDNUMREG = id;

            var result = await _SELReconsideraciones.ListarMatriz(id);
            ViewBag.Matriz = result.First().Val;

            return PartialView();
        }

        private async Task RecEstado(int id)
        {
            var Resumen = await _SELReconsideraciones.ResumenRecxID(id);
            ViewBag.RecEstado = Resumen.RREC_ID_ESTADOREC;
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

                var LugarAte = await _Auxiliares.ListarLugarAtencion();
                ViewBag.ListLugarAte = LugarAte;

                var CondMaterna = await _Auxiliares.ListarCondicionMaterna();
                ViewBag.ListCondiMaterna = CondMaterna;

                var ModalidadAte = await _Auxiliares.ListarTipoModalidadAte("1");
                ViewBag.ListModalidadAte = ModalidadAte;

                var OrigenPersona = await _Auxiliares.ListarOrigenPersonal("1");
                ViewBag.ListOrigenPersona = OrigenPersona;

                var TipoPersonal = await _Auxiliares.ListarTipoPersonal();
                ViewBag.ListTipoPersonal = TipoPersonal;

                var Especialidad = await _Auxiliares.ListarEspecialidad();
                ViewBag.ListEspecialidad = Especialidad;

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

        [HttpPost]
        public async Task<IActionResult> EESSxID(string id)
        {
            try
            {
                var result = await _Maestros.ListarEESSxID(id);


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
        [HttpPost]
        public async Task<IActionResult> ServicioxID(string id)
        {
            try
            {
                var result = await _Maestros.ListarServicios(id);


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
        [HttpPost]
        public async Task<IActionResult> PersonalSaludxID(string id)
        {
            try
            {
                var result = await _Maestros.ListarPersSaluxID(id);


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

        public async Task<IActionResult> DiagnosticosFUAV(int id, int est)
        {
            
            var result = await _SELReconsideraciones.ListarIAtencionDIAxID(id);
            await RecEstado(id);
            var permite = 0;
            permite = est;
            ViewBag.Permite = est;

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
            ViewBag.vbId = id;
            return PartialView();
        }

        public async Task<IActionResult> MedicamentosFUAV(int id, int est)
        {
            var result = await _SELReconsideraciones.ListarIAtencionMEDxID(id);
            await RecEstado(id);
            var permite = 0;
            permite = est;
            ViewBag.Permite = est;

            return PartialView(result);
        }

        //MEDICAMENTO AGREGADOS CONTROLADORES
        public async Task<IActionResult> GetMedicamentoxMED_CODMED(string MED_CODMED)
        {
            try
            {
                var medic = await _SELReconsideraciones.ListarMedicamentoxMED_CODMED(MED_CODMED);
                if (medic != null)
                {
                    return new JsonResult(new { IsSuccess = true, Result = medic });
                }
                else
                {
                    return new JsonResult(new { IsSuccess = false });
                }
            }
            catch (Exception)
            {
                return new JsonResult(new { IsSuccess = false });
            }
        }
        public async Task<IActionResult> InsertarAtenMedicamentoREc(getInsertarAtencionMedicamentoRec MED_CODMED)
        {
            try
            {
                var result = await _iNSReconsideraciones.InsertarAtenMedicamentoRec(MED_CODMED);

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
        //FIN 

        public async Task<IActionResult> AccionMedicamentosFUAV(string tipo, int id, int idate)
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
            await ListDiag(idate);

            return PartialView();
        }

        private async Task ListDiag(int idate)
        {
            var dx = await _SELReconsideraciones.ListarIAtencionDIAxID(idate);
            ViewBag.ListDX = dx;
        }

        public async Task<IActionResult> ProcedimientosFUAV(int id, int est)
        {

            var result = await _SELReconsideraciones.ListarIAtencionAPOxID(id);
            await RecEstado(id);
            var permite = 0;
            permite = est;
            ViewBag.Permite = est;

            return PartialView(result);
        }

        public async Task<IActionResult> AccionProcedimientosFUAV(string tipo, int id, int idate)
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
            await ListDiag(idate);
            ViewBag.vbId = id;
            return PartialView();
        }

        
        public async Task<IActionResult> InsumosFUAV(int id, int est)
        {
            var result = await _SELReconsideraciones.ListarIAtencionINSxID(id);
            await RecEstado(id);
            var permite = 0;
            permite = est;
            ViewBag.Permite = est;

            return PartialView(result);
        }
        public async Task<IActionResult> AccionInsumosFUAV(string tipo, int id, int idate)
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

            await ListDiag(idate);
            ViewBag.vbId = id;
            return PartialView();
        }


        
        public async Task<IActionResult> MaternoInfantilFUAV(int id, int est)
        {
            var permite = 0;
            permite = est;
            ViewBag.Permite = est;
            await RecEstado(id);

            return PartialView();
        }

        public async Task<IActionResult> ListarDiagnosticoPorId(string V_C10_CODDIA)
        {
            try
            {
                var result = await _Maestros.ListarDiagnosticoPorId(V_C10_CODDIA);

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

        [HttpPost]
        public async Task<IActionResult> ActualizarAtencionDia(UPDAtencionesDiaDto model)
        {
            try
            {
                var result = await _uPDReconsideraciones.ActualizarAtencionesDia(model);

                if (result == true)
                {
                    return new JsonResult(new { IsSuccess = true, Message = "Datos actualizado." });
                }
                else
                {
                    return new JsonResult(new { IsSuccess = false, Message = "Algo salio mal intente mas tarde." });
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { IsSuccess = false, Message = "Algo salio mal intente mas tarde." });
            }

        }

        public async Task<IActionResult> ListarAtencionDIAPorId(int id)
        {
            try
            {
                var result = await _SELReconsideraciones.ListarAtencionDIA_Edit(id);

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
        public async Task<IActionResult> ListarAtencionAPOPorId(int id)
        {
            try
            {
                var result = await _SELReconsideraciones.ListarAtencionAPO_Edit(id);

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
        public async Task<IActionResult> ListarAtencionINSPorId(int id)
        {
            try
            {
                var result = await _SELReconsideraciones.ListarAtencionINS_Edit(id);

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
        public async Task<IActionResult> ListarApoDIAGPorId(int idate, string id)
        {
            try
            {
                var result = await _Maestros.ListarApoDiagPorId(idate, id);

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
        [HttpPost]
        public async Task<IActionResult> Eliminar(int tipo, int id)
        {
            try
            {
                var result = new Mensaje_Del();

                if (tipo==1) //DX
                {
                    result = await _dELReconsideraciones.EliminarAtencionDia(id);
                }
                else if (tipo == 2) //MED
                {
                    result = await _dELReconsideraciones.EliminarAtencionMed(id);

                }
                else if (tipo == 3) //APO
                {
                    result = await _dELReconsideraciones.EliminarAtencionApo(id);

                }
                else if (tipo == 4) //INS
                {
                    result = await _dELReconsideraciones.EliminarAtencionIns(id);

                }


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
        public async Task<IActionResult> InsertarAtenDiagnosticoREc(getInsertarAtencionDIA datos)
        {
            try
            {
                var result = await _iNSReconsideraciones.InsertarAtenDiagnostico(datos);

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
        public async Task<IActionResult> InsertarAtenProcedimientoREc(getInsertarAtencionAPO datos)
        {
            try
            {
                var result = await _iNSReconsideraciones.InsertarAtenProcedimiento(datos);

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
        public async Task<IActionResult> InsertarAtenInsumosREc(getInsertarAtencionINS datos)
        {
            try
            {
                var result = await _iNSReconsideraciones.InsertarAtenInsumos(datos);

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
        public async Task<IActionResult> GetInsumosId(string V_INS_CODINS)
        {
            try
            {
                var medic = await _SELReconsideraciones.ListarInsumosId(V_INS_CODINS);
                if (medic != null)
                {
                    return new JsonResult(new { IsSuccess = true, Result = medic });
                }
                else
                {
                    return new JsonResult(new { IsSuccess = false });
                }
            }
            catch (Exception)
            {
                return new JsonResult(new { IsSuccess = false });
            }
        }
        public async Task<IActionResult> EliminarAtencionTotal(int N_ATE_IDNUMREG)
        {
            try
            {
                var result = await _dELReconsideraciones.EliminarAtencionTotal(N_ATE_IDNUMREG);

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
        public async Task<IActionResult> PermitirMatriz(int id)
        {
            try
            {
                var result = await _SELReconsideraciones.ListarMatriz(id);
                return new JsonResult(new { IsSuccess = true, result = result });
            }
            catch (Exception)
            {
                return new JsonResult(new { IsSuccess = false });
            }
        }

        public async Task<IActionResult> MatrizValFUAV( int id)
        {
            ViewBag.Titulo_Modal = "MATRIZ DE VALIDACIÓN";
            var result = await _SELReconsideraciones.ListarMatriz(id);
            return PartialView(result);
        }
    }
}

