using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using App.Data;
using App.Models;
using App.Services.IServices;
using App.Tools;
using App.ViewModels;
using App.ViewModels.INSReconsideraciones;
using App.ViewModels.RptReconsideraciones;
using App.ViewModels.SELReconsideraciones;
using App.ViewModels.UPDReconsideraciones;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Web.Controllers
{
    public class EvaluacionController : Controller
    {
        // GET: /<controller>/
        private readonly DataContextApp _dbContext;
        private readonly IAuxiliares _Auxiliares;
        private readonly IMaestros _Maestros;
        private readonly ISELReconsideraciones _SELReconsideraciones;
        private readonly IUPDReconsideraciones _uPDReconsideraciones;
        private readonly IDELReconsideraciones _dELReconsideraciones;
        private readonly IINSReconsideraciones _iNSReconsideraciones;
        private readonly IValRcRvRecosideraciones _IvalRcRvRecosideraciones;
        private readonly IFileUploadFTP _fileUploadFTP;
        private readonly URLReadFile _uRLReadFile;
        

        public EvaluacionController(DataContextApp dbContext, IAuxiliares auxiliares, IMaestros maestros,
            ISELReconsideraciones sELReconsideraciones, IUPDReconsideraciones uPDReconsideraciones,
            IINSReconsideraciones iNSReconsideraciones, IDELReconsideraciones dELReconsideraciones,
            IValRcRvRecosideraciones valRcRvRecosideraciones, IFileUploadFTP fileUploadFTP, 
            IOptions<URLReadFile> uRLReadFile)

        {
            _dbContext = dbContext;
            _Auxiliares = auxiliares;
            _Maestros = maestros;
            _SELReconsideraciones = sELReconsideraciones;
            _uPDReconsideraciones = uPDReconsideraciones;
            _dELReconsideraciones = dELReconsideraciones;
            _iNSReconsideraciones = iNSReconsideraciones;
            _IvalRcRvRecosideraciones = valRcRvRecosideraciones;
            _fileUploadFTP = fileUploadFTP;
            _uRLReadFile = uRLReadFile.Value; 
        }
        private async Task RecEstado(int id)
        {
            var Resumen = await _SELReconsideraciones.ResumenRecxID(id);
            ViewBag.RecEstado = Resumen.RREC_ID_ESTADOREC;
            ViewBag.RecEstRV = Resumen.RREC_C_ESTARV;
            @ViewBag.PeriodoRec = Resumen.RREC_PERIODO + "-" + Resumen.RREC_MES;
        }

        public async Task<IActionResult> Index(int id)        {
 

            await RecEstado(id);

            ViewBag.ATE_IDNUMREG = id;

            return PartialView();
        }

        public async Task<IActionResult> InfSoliRecEval(int id)
        {

            return PartialView();
        }



        public async Task<IActionResult> InfGeneralEvalV(int id)
        {
            try
            {
                var Componente = await _Auxiliares.ListarComponentes();
                ViewBag.LisComponente = Componente;

                var TipoDocIdent = await _Auxiliares.ListarTipoDocIdentidad();
                ViewBag.ListTipoDocIdent = TipoDocIdent;

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

                var Destino = await _Auxiliares.ListarDestinoAsegurado();
                ViewBag.ListDestinoAseg = Destino;

            }
            catch (Exception aa)
            {

                throw;
            }


            return PartialView();
        }

        public async Task<IActionResult> DiagnosticosEvalV(int id, int est)
        {

            var result = await _SELReconsideraciones.ListarIAtencionDIAxID(id);
            await RecEstado(id);
            var permite = 0;
            permite = est;
            ViewBag.Permite = est;

            return PartialView(result);
        }

        public async Task<IActionResult> AccionDiagnosticoEvalV(string tipo, int id)
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
            else if (Convert.ToInt32(tipo) == 3)
            {
                ViewBag.Tipo = tipo;
                ViewBag.Titulo_Modal = "VISOR DEL DIAGNOSTICO";
            }

            var result = await _Auxiliares.ListarTipoDiagnostico();
            ViewBag.ListTipoDX = result;
            ViewBag.vbId = id;
            
            return PartialView();
        }

        public async Task<IActionResult> MedicamentosEvalV(int id, int est)
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
        public async Task<IActionResult> AccionMedicamentosEvalV(string tipo, int id, int idate)
        {

            if (Convert.ToInt32(tipo) == 1)
            {
                ViewBag.Tipo = tipo;
                ViewBag.Titulo_Modal = "REGISTRO DE MEDICAMENTO";
            }
            else if (Convert.ToInt32(tipo) == 2)
            {
                ViewBag.Tipo = tipo;
                ViewBag.Titulo_Modal = "ACTUALIZACIÓN DEL MEDICAMENTO A EVALUAR";
            }
            ViewBag.IdMed=id;
            await ListDiag(idate);
            var codtabla = "02";
            await ListObs(idate, codtabla);

            return PartialView();
        }
        private async Task ListObs(int idate, string codtabla)
        {
            var obs = await _SELReconsideraciones.ListarIAtencionOBSxID(idate, codtabla);
            ViewBag.ListObs = obs;
        }

        private async Task ListDiag(int idate)
        {
            var dx = await _SELReconsideraciones.ListarIAtencionDIAxID(idate);
            ViewBag.ListDX = dx;
        }

        public async Task<IActionResult> ProcedimientosEvalV(int id, int est)
        {

            var result = await _SELReconsideraciones.ListarIAtencionAPOxID(id);
            await RecEstado(id);
            var permite = 0;
            permite = est;
            ViewBag.Permite = est;

            return PartialView(result);
        }

        public async Task<IActionResult> AccionProcedimientosEvalV(string tipo, int id, int idate)
        {
            if (Convert.ToInt32(tipo) == 1)
            {
                ViewBag.Tipo = tipo;
                ViewBag.Titulo_Modal = "REGISTRO DE PROCEDIMIENTOS";
            }
            else if (Convert.ToInt32(tipo) == 2)
            {
                ViewBag.Tipo = tipo;
                ViewBag.Titulo_Modal = "ACTUALIZACIÓN DEL PROCEDIMIENTO A EVALUAR";
            }
            await ListDiag(idate);
            var codtabla = "04";
            await ListObs(idate, codtabla);
            ViewBag.IdApo = id;
            return PartialView();
        }
        public async Task<IActionResult> InsumosEvalV(int id, int est)
        {
            var result = await _SELReconsideraciones.ListarIAtencionINSxID(id);
            await RecEstado(id);
            var permite = 0;
            permite = est;
            ViewBag.Permite = est;

            return PartialView(result);
        }
        public async Task<IActionResult> AccionInsumosEvalV(string tipo, int id, int idate)
        {
            if (Convert.ToInt32(tipo) == 1)
            {
                ViewBag.Tipo = tipo;
                ViewBag.Titulo_Modal = "REGISTRO DE INSUMO";
            }
            else if (Convert.ToInt32(tipo) == 2)
            {
                ViewBag.Tipo = tipo;
                ViewBag.Titulo_Modal = "ACTUALIZACIÓN DEL INSUMO A EVALUAR";
            }

            await ListDiag(idate);
            var codtabla = "03";
            await ListObs(idate, codtabla);

            ViewBag.IdIns = id;
            return PartialView();
        }



        public async Task<IActionResult> MaternoInfantilEvalV(int id, int est)
        {
            var permite = 0;
            permite = est;
            ViewBag.Permite = est;
            await RecEstado(id);

            return PartialView();
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
        public async Task<IActionResult> ListarAtencionMEDPorId(int id)
        {
            try
            {
                var result = await _SELReconsideraciones.ListarAtencionMedEditxID(id);

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
        public async Task<IActionResult> SustentoEvalID(int id)
        {
            try
            {
                var dato = await _SELReconsideraciones.ListarAteSustxID(id);

                return new JsonResult(new { IsSuccess = true, result = dato });

            }
            catch (Exception)
            {
                return new JsonResult(new { IsSuccess = false });
            }
        }
        public async Task<IActionResult> InfSoliRecSusEval(int id)
        {
            ViewBag.url_sis = _uRLReadFile.URL_Read_SIS;
            var result = await _SELReconsideraciones.ListarAteSusArch(id);
            return PartialView(result);
        }
        public async Task<IActionResult> InfSoliRecCostEval(int id)
        {
            var result = await _SELReconsideraciones.ListarCostosxEVAL(id);
            return PartialView(result);
        }

        public async Task<IActionResult> AccionEvaluacionV(int Id)
        {

            ViewBag.Titulo_Modal = "REGISTRO DE EVALUACIÓN";
            //var result = await _SELReconsideraciones.ListarAteSustxID(idate);
            await RecEstado(Id);
            return PartialView();
        }

        public async Task<IActionResult> ListarObsEvalV(int id)
        {

            var result = await _SELReconsideraciones.ListarObservacionesSust(id);

            return PartialView(result);
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarMedEval(setActualizarMedEval model)
        {
            try
            {
                var usuario = await App.Tools.AutenticacionHelper.GetUsuario(HttpContext);
                var datos = new setActualizarMedEval()
                {
                    N_AMED_ICANTAPROBADAODSIS = model.N_AMED_ICANTAPROBADAODSIS,
                    V_AMED_V_MOTIVO_CAMBIO = model.V_AMED_V_MOTIVO_CAMBIO,
                    V_AMED_IDUSUARIOACT = usuario.Name,
                    N_AMED_IDNUMREG = model.N_AMED_IDNUMREG

                };

                var result = await _uPDReconsideraciones.Actualizar_CantMed_Evaluacion(datos);

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
        public async Task<IActionResult> ActualizarApoEval(setActualizarApoEval model)
        {
            try
            {
                var usuario = await App.Tools.AutenticacionHelper.GetUsuario(HttpContext);
                var datos = new setActualizarApoEval()
                {
                    N_AAPO_ICANTAPROBADAODSIS = model.N_AAPO_ICANTAPROBADAODSIS,
                    V_AAPO_V_MOTIVO_CAMBIO = model.V_AAPO_V_MOTIVO_CAMBIO,
                    V_AAPO_IDUSUARIOACT = usuario.Name,
                    N_AAPO_IDNUMREG = model.N_AAPO_IDNUMREG

                };

                var result = await _uPDReconsideraciones.Actualizar_CantApo_Evaluacion(datos);

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
        public async Task<IActionResult> ActualizarInsEval(setActualizarInsEval model)
        {
            try
            {
                var usuario = await App.Tools.AutenticacionHelper.GetUsuario(HttpContext);
                var datos = new setActualizarInsEval()
                {
                    N_AINS_ICANTIDADAPROBADAODSIS = model.N_AINS_ICANTIDADAPROBADAODSIS,
                    V_AINS_V_MOTIVO_CAMBIO = model.V_AINS_V_MOTIVO_CAMBIO,
                    V_AINS_IDUSUARIOACT = usuario.Name,
                    N_AINS_IDNUMREG = model.N_AINS_IDNUMREG

                };

                var result = await _uPDReconsideraciones.Actualizar_CantIns_Evaluacion(datos);

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

        public async Task<IActionResult> RegistrarSustentoEval(SetInsertarEvaluacion datos)
        {
            try
            {
                var usuario = await AutenticacionHelper.GetUsuario(HttpContext);

                var sustento = new SetInsertarEvaluacion()
                {
                    P_I_IDATENCION= datos.P_I_IDATENCION,
                    P_V_USUARIO   = usuario.Name,
                    P_V_OBSGENERAL= datos.P_V_OBSGENERAL,
                    P_V_OBSDETALLE= datos.P_V_OBSDETALLE,
                    P_N_ESTADOREC = datos.P_N_ESTADOREC,
                    P_V_CRITERIOA1= datos.P_V_CRITERIOA1,
                    P_V_CRITERIOA2= datos.P_V_CRITERIOA2,
                    P_V_CRITERIOA3= datos.P_V_CRITERIOA3,
                    P_V_CRITERIOA4= datos.P_V_CRITERIOA4,
                    P_V_CRITERIOB1= datos.P_V_CRITERIOB1,
                    P_V_CRITERIOB2= datos.P_V_CRITERIOB2,
                    P_V_CRITERIOB3= datos.P_V_CRITERIOB3,
                    P_V_CRITERIOB4= datos.P_V_CRITERIOB4

                 };

                var result = await _uPDReconsideraciones.ActualizarAteEvaluacion(sustento);

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

        public async Task<IActionResult> EvaluacionId(int id)
        {
            try
            {
               
                var dato = await _SELReconsideraciones.ListarEvaluacionxID(id);
                ViewBag.usuarioEvaluo = dato.V_USUEVALUA;
                return new JsonResult(new { IsSuccess = true, result = dato });

            }
            catch (Exception)
            {
                return new JsonResult(new { IsSuccess = false });
            }
        }
        public async Task<IActionResult> EliminarEvaluacion(int P_I_IDATENCION)
        {
            try
            {
                var dato = await _SELReconsideraciones.ListarEvaluacionxID(P_I_IDATENCION);
                ViewBag.usuarioEvaluo = dato.V_USUEVALUA;
                var usuario = await AutenticacionHelper.GetUsuario(HttpContext);
                if (ViewBag.UsuarioEvaluo == usuario.Name)
                {

                    var result = await _dELReconsideraciones.EliminarEvaluacion(P_I_IDATENCION);

                    if (result.CODIGO == 0)
                    {
                        return new JsonResult(new { IsSuccess = true, Message = result.MENSAJE });
                    }
                    else
                    {
                        return new JsonResult(new { IsSuccess = false, Message = result.MENSAJE });
                    }
                }
                else {
                    return new JsonResult(new { IsSuccess = false, Message = ViewBag.UsuarioEvaluo + ": Usuario no autorizado" });
                }
            }
            catch (Exception)
            {
                return new JsonResult(new { IsSuccess = false });
            }
        }

        
    }
}

