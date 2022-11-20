using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using App.Data;
using App.Models;
using App.Tools.Services;
using App.ViewModels;
using Microsoft.Extensions.Options;
using ServiceStack;

namespace App.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger _logger;
        private readonly Auth _auth;
        public AccountController(ILogger<AccountController> logger, IOptions<Auth> auth)
        {
            _logger = logger;
            _auth = auth.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            _logger.LogInformation("User {Name} logged out at {Time}.",
                User.Identity.Name, DateTime.UtcNow);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect(_auth.entorno);
        }

       
    }
}
