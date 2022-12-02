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

namespace App.Web.Controllers
{
    public class FUAConsultaController : Controller
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


        public FUAConsultaController(DataContextApp dbContext, IAuxiliares auxiliares, IMaestros maestros,
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
            @ViewBag.PeriodoList= Resumen.RREC_PERIODO + "-" + Resumen.RREC_MES;
            @ViewBag.EESS = Resumen.RREC_IDEESS;
        }

        public async Task<IActionResult> Index(int id)
        {

            await RecEstado(id);

            ViewBag.ATE_IDNUMREG = id;
          

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
 
        public async Task<IActionResult> InsumosEvalV(int id, int est)
        {
            var result = await _SELReconsideraciones.ListarIAtencionINSxID(id);
            await RecEstado(id);
            var permite = 0;
            permite = est;
            ViewBag.Permite = est;

            return PartialView(result);
        }

        public async Task<IActionResult> InfSoliRecEval(int id)
        {

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
 
        public async Task<IActionResult> InfSoliRecCostEval(int id)
        {
            var result = await _SELReconsideraciones.ListarCostosxEVAL(id);
            return PartialView(result);
        }

        public async Task<IActionResult> AccionEvaluacionV(int Id)
        {

            ViewBag.Titulo_Modal = "DATOS DE EVALUACIÓN";
            //var result = await _SELReconsideraciones.ListarAteSustxID(idate);
            await RecEstado(Id);
            return PartialView();
        }

        public async Task<IActionResult> ListarObsEvalV(int id)
        {

            var result = await _SELReconsideraciones.ListarObservacionesSust(id);

            return PartialView(result);
        }
        public async Task<IActionResult> InfSoliRecSusEval(int id)
        {
            ViewBag.url_sis = _uRLReadFile.URL_Read_SIS;
            var result = await _SELReconsideraciones.ListarAteSusArch(id);
            return PartialView(result);
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


    }
}

