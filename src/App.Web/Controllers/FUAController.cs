using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using App.Services.IServices;
using App.Tools;
using App.ViewModels;
using App.ViewModels.INSReconsideraciones;
using App.ViewModels.SELReconsideraciones;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
        private readonly IValRcRvRecosideraciones _IvalRcRvRecosideraciones;
        private readonly IFileUploadFTP _fileUploadFTP;
        private readonly URLReadFile _uRLReadFile;
        private readonly Auth _auth;

        public FUAController(DataContextApp dbContext, IAuxiliares auxiliares, IMaestros maestros,
            ISELReconsideraciones sELReconsideraciones, IUPDReconsideraciones uPDReconsideraciones,
            IINSReconsideraciones iNSReconsideraciones, IDELReconsideraciones dELReconsideraciones,
            IValRcRvRecosideraciones valRcRvRecosideraciones, IFileUploadFTP fileUploadFTP, 
            IOptions<URLReadFile> uRLReadFile, IOptions<Auth> auth)

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
            _auth = auth.Value;
        }
        public async Task<IActionResult> Index(int id, string periodo)
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

            ViewBag.periodo = periodo;

            return PartialView();
        }

        private async Task RecEstado(int id)
        {           
            var Resumen = await _SELReconsideraciones.ResumenRecxID(id);
            ViewBag.RecEstado = Resumen.RREC_ID_ESTADOREC;
            ViewBag.RecEstRV = Resumen.RREC_C_ESTARV;
            @ViewBag.PeriodoList = Resumen.RREC_PERIODO + "-" + Resumen.RREC_MES;
            @ViewBag.EESS = Resumen.RREC_IDEESS;
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

                var Destino = await _Auxiliares.ListarDestinoAsegurado();
                ViewBag.ListDestinoAseg = Destino;

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
            var codtabla = "02";
            await ListObs(idate,codtabla);

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
            var codtabla = "04";
            await ListObs(idate, codtabla);
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
            var codtabla = "03";
            await ListObs(idate, codtabla);

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
                var usuario = await AutenticacionHelper.GetUsuario(HttpContext);
                var aten = await _SELReconsideraciones.ListarIAtencionRecxID(N_ATE_IDNUMREG);
                if (usuario.Name == aten.ATE_IDUSUARIOCREA)
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
                else {
                    return new JsonResult(new { IsSuccess = false, Message = "Esta solicitud sólo puede ser eliminada por el usuario:"+ aten.ATE_IDUSUARIOCREA });
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


        //ACTUALIZAR DATOS FUA
        [HttpPost]
        public async Task<IActionResult> ActualizarDatosFUA(getAtencionRecxID model)
        {
            try
            {
                var result = await _uPDReconsideraciones.Actualizar_FUA(model);

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

        [HttpPost]
        public async Task<IActionResult> ValidarRcRv(int N_ATE_IDNUMREG)
        {
            try
            {
                var validar = await _IvalRcRvRecosideraciones.ValidarRcRvRec(N_ATE_IDNUMREG);


                if (validar.CODIGO == 0)
                {
                    return new JsonResult(new { IsSuccess = true, Message = validar.MENSAJE, result= validar });
                }
                else if (validar.CODIGO == 1)
                {
                    return new JsonResult(new { IsSuccess = true, Message = validar.MENSAJE, result = validar });
                }
                else
                {
                    return new JsonResult(new { IsSuccess = false, Message = validar.MENSAJE, result = validar });
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { IsSuccess = false, Message = "Algo salio mal intente mas tarde." });
            }

        }

        public async Task<IActionResult> ListarObsRcRvFUAV(int id)
        {
            ViewBag.Titulo_Modal = "OBSERVACIONES DEL PROCESO DE RC Y RV";
            var result = await _SELReconsideraciones.ListarObservacionesRcRv(id);
            return PartialView(result);
        }

        public async Task<IActionResult> AccionSustentoFUAV(int idate)
        {
           
            ViewBag.Titulo_Modal = "REGISTRO DEL SUSTENTO";
            var result = await _SELReconsideraciones.ListarAteSustxID(idate);
            await RecEstado(idate);
            return PartialView(result);
        }

        public async Task<IActionResult> ListarObsFUAV(int id)
        {

            var result = await _SELReconsideraciones.ListarObservacionesSust(id);

            return PartialView(result);
        }

        public async Task<IActionResult> AccionArchSusFUAV(int id)
        {
            ViewBag.url_sis = _uRLReadFile.URL_Read_SIS;
            var result = await _SELReconsideraciones.ListarAteSusArch(id);
            ViewBag.Archivo = _auth.Archivo;
            await RecEstado(id);

            return PartialView(result);
        }

        public async Task<IActionResult> RegistrarSustento(getInsertarAteSustento datos)
        {
            try
            {
                var result = await _uPDReconsideraciones.ActualizarAteSustento(datos);

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
        public async Task<IActionResult> SustentoID(int id)
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

        [HttpPost]
        [RequestSizeLimit(2147483647)]       //unit is bytes => 2GB
        [RequestFormLimits(MultipartBodyLengthLimit = 2147483647)]
        public async Task<IActionResult> RegistrarArchSuste(setInsertarAteArchSuste model)
        {
            try
            {
                var path = "";
                if (model.file != null)
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "Sustentos");
                }

                //var usuario = await AutenticacionHelper.GetUsuario(HttpContext);
                var usuario = await App.Tools.AutenticacionHelper.GetUsuario(HttpContext);
                var archivo = model.file.FileName;

                var datos = new setInsertarAteArchSuste2()
                {
                    V_asus_v_rutaarch = model.file != null ? $"uploads/Sustentos" : null,
                    V_asus_v_nombarch = model.file != null ? await ImagenesHelper.UploadFileAsync(path, model.file) : null,
                    V_asus_v_usuariocrea=usuario.Name,
                    N_asus_numregate=model.N_asus_numregate,
                    V_ASUS_V_ARCHIVODESCR=archivo

                };

                var result = await _iNSReconsideraciones.InsertarAtenSustentos(datos);
                if (result.CODIGO == 0)
                {
                    return new JsonResult(new Response { IsSuccess = true, Message = result.MENSAJE });

                }
                else
                {
                    return new JsonResult(new Response { IsSuccess = false, Message = result.MENSAJE });

                }

            }
            catch (Exception ex)
            {
                return new JsonResult(new Response { IsSuccess = false, Message = "Algo salio intente mas tarde." });
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar_Sustento(int id)
        {
            try
            {
                var usuario = await AutenticacionHelper.GetUsuario(HttpContext);
                var dato = await _SELReconsideraciones.ListarAteSustxID(id);
                if (usuario.Name == dato.USUARIOCREA)
                {
                    var archivo = await _SELReconsideraciones.ListarAteSusArchxID(id);

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", archivo.First().asus_v_rutaarch, archivo.First().asus_v_nombarch);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }

                    var result = await _dELReconsideraciones.EliminarSustento(id);


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
                    return new JsonResult(new { IsSuccess = false, Message = "Sólo el usuario que creó el sustento puede eliminar." });
                }

                
            }
            catch (Exception ex)
            {
                return new JsonResult(new { IsSuccess = false, Message = "Algo salio mal intente mas tarde." });

            }

        }

        public async Task<IActionResult> RegistrarEnvioSolicitud(int N_ATE_IDNUMREG)
        {
            try
            {
                var result = await _iNSReconsideraciones.InsertarEnviarSolicitud(N_ATE_IDNUMREG);

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
    }
}

