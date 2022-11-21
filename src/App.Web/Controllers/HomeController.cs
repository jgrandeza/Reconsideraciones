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

namespace App.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Auth _auth;

    public HomeController(ILogger<HomeController> logger, IOptions<Auth> auth)
    {
        _logger = logger;
        _auth = auth.Value;
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


            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, "8610"),
                    new Claim(ClaimTypes.Name, "RLOPEZV"),
                    new Claim("USU_NOMBREUSUARIO", "LOPEZ\tVASQUEZ\tROSA MARIBEL"),
                    new Claim("IDROL", "329"),
                    new Claim("ROL_DESCRIPCION", "SOLICITANTE"),
                    new Claim("USU_PPDD", ""),
                    new Claim("Foto",  "user.png"),
                    new Claim("ID_SUBMODULO", "391"),
                    new Claim("USU_DISA","190"),
                    new Claim("USU_UE","1422"),
                    new Claim("EESS_CODIGOSIS",""),
                    new Claim("USU_ODSIS", "021"),
                    new Claim("ID_MACROREGION",""),
                    new Claim("USU_DNI",""),
                    new Claim("USU_EMAILINSTITUCIONAL",""),
                    new Claim("V_V_USU_EMAIL",""),
                    new Claim("LUGARTRAB_DESC",""),
                    new Claim("TOKENSESION",""),
                    new Claim("TOKENSALIDA",""),
                    new Claim("EESS_IDESTABLECIMIENTO","0000011470"),
                    new Claim("DISA_DESCRIPCION", "PRUEBA DISA"),
                    new Claim("UE_DESCRIPCION", "PRUEBA UNIDAD EJECUTORA"),
                    new Claim("ESTABLECIMIENTO_DESC"," ESTABLECIMIENTO PRUEBA"),

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


            ViewBag.USU_USUARIO = "ROLEZV";
            ViewBag.USU_DNI = "";
            ViewBag.LUGARTRAB_DESC = "";
            ViewBag.USU_NOMBREUSUARIO = "";
            return RedirectToAction(nameof(ModulosController.Index), "Modulos");



        }


        return View();
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

