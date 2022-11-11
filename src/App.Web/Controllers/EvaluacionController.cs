using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using App.Services.IServices;
using App.ViewModels;
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
            IValRcRvRecosideraciones valRcRvRecosideraciones, IFileUploadFTP fileUploadFTP, IOptions<URLReadFile> uRLReadFile)

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
        }

        public async Task<IActionResult> Index(int id)
        {
            ViewBag.DescDisa = "LIMA NORTE";
            ViewBag.DescUE = "HOSPITAL CARLOS LAFRNACO LA HOZ";
            ViewBag.DesEESS = "222222222-HOSPITALLANFRANCO";

            ViewBag.PeriodoRec = "2019-1 del 01/07/2022 al 26/08/2022";

            ViewBag.Titulo = "REGISTRO DE RECONSIDERACION A EVALUAR";

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
                ViewBag.Titulo_Modal = "ACTUALIZACIÓN DEL MEDICAMENTO";
            }
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
                ViewBag.Titulo_Modal = "ACTUALIZACIÓN DEL PROCEDIMIENTO";
            }
            await ListDiag(idate);
            var codtabla = "04";
            await ListObs(idate, codtabla);
            ViewBag.vbId = id;
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
                ViewBag.Titulo_Modal = "ACTUALIZACIÓN DEL INSUMO";
            }

            await ListDiag(idate);
            var codtabla = "03";
            await ListObs(idate, codtabla);

            ViewBag.vbId = id;
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

    }
}

