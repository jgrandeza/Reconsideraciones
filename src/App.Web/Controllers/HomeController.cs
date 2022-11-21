using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using App.Web.Models;
using App.ViewModels;
using Microsoft.Extensions.Options;
using System.Net;
using Microsoft.Build.Framework;
using Newtonsoft.Json;
using App.Tools;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security;
using App.Models;
using App.Services.IServices;
using App.ViewModels.Maestros;
using System.Security.Cryptography;
using System.Data;
using NuGet.Protocol;
using Microsoft.CodeAnalysis.Options;
using Newtonsoft.Json.Linq;

namespace App.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Auth _auth;
    private readonly IMaestros _Maestros;
    public HomeController(ILogger<HomeController> logger, IOptions<Auth> auth,IMaestros maestros)
    {
        _logger = logger;
        _auth = auth.Value;
        _Maestros = maestros;
    }

    public async Task<IActionResult> Index(string token)
    {
        Boolean bProduccion = false;
        if (bProduccion == true)
        {

            string sToken = HttpContext.Request.Query["token"].ToString();
            //  string sToken = "N2U02EZSUU17589LF0A7VZM11";


            //if (!HttpContext.User.Identity.IsAuthenticated)
            //    return Redirect(_auth.entorno); 
            // 1.1. Web Service
            string sServicio = "/Token";
            // 1.2. Parametros
            string sParametro1 = "?token=" + sToken;


            WebRequest oRequest = WebRequest.Create(_auth.RutaWSESeguridad + sServicio + sParametro1);
            // 'Err.Text = "línea 82 : consulta a seguridad"

            WebResponse oResponse = oRequest.GetResponse();
            // Err.text = "línea 84 : pasa consulta seguridad"
            // 1.4. Lectura de respuesta
            // 'Err.Text = "línea 86 : inicia oResponse.GetResponseStream"
            Stream oDataStream = oResponse.GetResponseStream();
            // ' Err.Text = "línea 88 : pasa oResponse.GetResponseStream"
            StreamReader oReader = new StreamReader(oDataStream);
            var sDatos = oReader.ReadToEnd();
            // 1.5. Liberar
            oReader.Close();
            oResponse.Close();

            // 2.1. convertir Jason a Objeto
            //var oJSS = new JavaScriptSerializer();

            var oResultado = JsonConvert.DeserializeObject<AuthResponseDto>(sDatos);

            if (oResultado is not null)
            {
                if (oResultado.ID_RESULTADO.Equals("1"))
                {

                    var Filtro_DISA = new setEESSXUE()
                    {
                        P_V_DISA = oResultado.USU_DISA,
                        P_V_UE = "",
                        P_V_IDEESS = "",
                        P_V_TIPO = "DATOS"
                    };


                    var y1 = await _Maestros.ListarESSXUE(Filtro_DISA);
                    var udisa = "";
                    foreach (var item in y1)
                    {
                        udisa = @item.DISA;
                    }

                    var Filtro_UE = new setEESSXUE()
                    {
                        P_V_DISA = oResultado.USU_DISA,
                        P_V_UE = oResultado.USU_UE,
                        P_V_IDEESS = "",
                        P_V_TIPO = "DATOS"
                    };

                    var y2 = await _Maestros.ListarESSXUE(Filtro_UE);
                    var uejecutora = "";
                    foreach (var item in y2)
                    {
                        uejecutora = @item.EJECUTORA;
                    }

                    var Filtro_EESS = new setEESSXUE()
                    {
                        P_V_DISA = oResultado.USU_DISA,
                        P_V_UE = oResultado.USU_UE,
                        P_V_IDEESS = oResultado.EESS_CODIGOSIS,
                        P_V_TIPO = "DATOS"
                    };
                    var y3 = await _Maestros.ListarESSXUE(Filtro_DISA);
                    var establecimiento = "";
                    foreach (var item in y3)
                    {
                        establecimiento = @item.ESTABLECIMIENTO;
                    }


                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, oResultado.USU_ID.ToString()),
                    new Claim(ClaimTypes.Name, oResultado.USU_USUARIO),
                    new Claim("USU_NOMBREUSUARIO", oResultado.USU_NOMBREUSUARIO),
                    new Claim("IDROL", oResultado.IDROL),
                    new Claim("ROL_DESCRIPCION", oResultado.ROL_DESCRIPCION),
                    new Claim("USU_PPDD", oResultado.USU_PPDD),
                    new Claim("Foto",  "user.png"),
                    new Claim("ID_SUBMODULO", oResultado.ID_SUBMODULO),
                    new Claim("USU_DISA",oResultado.USU_DISA),
                    new Claim("USU_UE",oResultado.USU_UE),
                    new Claim("EESS_CODIGOSIS",oResultado.EESS_CODIGOSIS),
                    new Claim("USU_ODSIS", oResultado.USU_ODSIS),
                    new Claim("ID_MACROREGION",oResultado.ID_MACROREGION),
                    new Claim("USU_DNI",oResultado.USU_DNI),
                    new Claim("USU_EMAILINSTITUCIONAL",oResultado.USU_EMAILINSTITUCIONAL),
                    new Claim("V_V_USU_EMAIL",oResultado.V_V_USU_EMAIL),
                    new Claim("LUGARTRAB_DESC",oResultado.LUGARTRAB_DESC),
                    new Claim("TOKENSESION",oResultado.TOKENSESION),
                    new Claim("TOKENSALIDA",oResultado.TOKENSALIDA),
                    new Claim("DISA_DESCRIPCION", udisa),
                    new Claim("UE_DESCRIPCION",uejecutora),
                    new Claim("ESTABLECIMIENTO_DESC",establecimiento),
                    new Claim("PROGRAMADOR",_auth.Depura), 
                    //UnidadEjecutoraId
                    //eso falta agregar al claims
                };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        IsPersistent = true
                    };
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity), authProperties);
                    _logger.LogInformation("User {Email} logged in at {Time}.", oResultado.USU_ID, DateTime.UtcNow);


                    ViewBag.USU_USUARIO = oResultado.USU_USUARIO;
                    ViewBag.USU_DNI = oResultado.USU_DNI;
                    ViewBag.LUGARTRAB_DESC = oResultado.LUGARTRAB_DESC;
                    ViewBag.USU_NOMBREUSUARIO = oResultado.USU_NOMBREUSUARIO;

                    return RedirectToAction(nameof(ModulosController.Index), "Modulos");

                }
                else
                {
                    return Redirect(_auth.entorno);
                }

            }
            else
            {
                return Redirect(_auth.entorno);
            }

        }
        else
        {

            var disau = "190";
            var ejecu = "1422";
            var eessu = "0000011470";
            var odsisu = "021";
            var usbmodulo = "1";//395,39x

            var Filtro_DISA = new setEESSXUE()
            {
                P_V_DISA = disau,
                P_V_UE = "",
                P_V_IDEESS = "",
                P_V_TIPO = "DATOS"
            };


            var p1 = await _Maestros.ListarESSXUE(Filtro_DISA);
            var udisap = "";
            foreach (var item in p1)
            {
                udisap = @item.DISA;
            }

            var Filtro_UE = new setEESSXUE()
            {
                P_V_DISA = disau,
                P_V_UE = ejecu,
                P_V_IDEESS = "",
                P_V_TIPO = "DATOS"
            };

            var p2 = await _Maestros.ListarESSXUE(Filtro_UE);
            var uejecutorap = "";
            foreach (var item in p2)
            {
                uejecutorap = @item.EJECUTORA;
            }

            var Filtro_EESS = new setEESSXUE()
            {
                P_V_DISA = disau,
                P_V_UE = ejecu,
                P_V_IDEESS = eessu,
                P_V_TIPO = "DATOS"
            };
            var p3 = await _Maestros.ListarESSXUE(Filtro_EESS);
            var establecimientop = "";
            foreach (var item in p3)
            {
                establecimientop = @item.ESTABLECIMIENTO;
            }

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, "8610"),
                    new Claim(ClaimTypes.Name, "RLOPEZV"),
                    new Claim("USU_NOMBREUSUARIO", "LOPEZ\tVASQUEZ\tROSA MARIBEL"),
                    new Claim("IDROL", "329"),
                    new Claim("ROL_DESCRIPCION", "SOLICITANTE"),
                    new Claim("USU_PPDD", ""),
                    new Claim("Foto",  "user.png"),
                    new Claim("ID_SUBMODULO", usbmodulo),//395,39x
                    new Claim("USU_DISA",disau),
                    new Claim("USU_UE",ejecu),
                    new Claim("EESS_CODIGOSIS",eessu),
                    new Claim("USU_ODSIS", odsisu),
                    new Claim("ID_MACROREGION",""),
                    new Claim("USU_DNI",""),
                    new Claim("USU_EMAILINSTITUCIONAL",""),
                    new Claim("V_V_USU_EMAIL",""),
                    new Claim("LUGARTRAB_DESC",""), 
                    new Claim("EESS_IDESTABLECIMIENTO",""),
                    new Claim("TOKENSESION","000001"),
                    new Claim("TOKENSALIDA","000002"),
                    new Claim("DISA_DESCRIPCION", udisap),
                    new Claim("UE_DESCRIPCION",uejecutorap),
                    new Claim("ESTABLECIMIENTO_DESC",establecimientop),
                    new Claim("PROGRAMADOR","local"),

                    //UnidadEjecutoraId
                    //eso falta agregar al claims
                };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                IsPersistent = true
            };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProperties);
            _logger.LogInformation("User {Email} logged in at {Time}.", "8610", DateTime.UtcNow);


            //ViewBag.USU_USUARIO = "ROLEZVxxxxx";
            //ViewBag.USU_DNI = "";
            //ViewBag.LUGARTRAB_DESC = "";
            //ViewBag.USU_NOMBREUSUARIO = "";
            //ViewBag.Programa = "x";
            //var modulo = "393";//Solicitante
            //var modulo = "395";//Evaluador
            //var modulo = "39x";//Periodos
            //var modulo = "39x";//Solicita ampliacion
            //var modulo = "39x";//Evalua ampliacion
            //var modulo = "39x";//Reportes
            return RedirectToAction(nameof(ModulosController.Index), "Modulos");
            //return RedirectToAction(nameof(ModulosController.Index), "Modulos");
            



        }


        return View();
    }

    private void Redireccionar(string Submodulo)
    {
        
        
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}