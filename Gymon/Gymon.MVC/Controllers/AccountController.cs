using Gymon.BL.Services.Imlements;
using Gymon.BL.Services.Interfaces;
using Gymon.BL.ViewModels.AuthVMs;
using Gymon.Core.Entities;
using Gymon.Core.Enums;
using Gymon.Core.Repostitories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Engines;
using System.Security.Claims;

namespace Gymon.MVC.Controllers
{
    public class AccountController(IAuthtService service, IUserRepository repo) : Controller
    {
        bool isAuthonticate => User.Identity?.IsAuthenticated ?? false;

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            if (isAuthonticate) return RedirectToAction("Index", "Home");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (isAuthonticate) return RedirectToAction("Index", "Home");
            await service.RegisterAsync(vm);
            return RedirectToAction("Login", "Account");

        }



        public async Task<IActionResult> Login()
        {
            if (isAuthonticate) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm, string? ReturnUrl = null)
        {
            if (isAuthonticate)
            {
                // Kullanıcı giriş yapmışsa, rolünü kontrol et
                var role = User.FindFirst(ClaimTypes.Role)?.Value;

                if (role == Roles.Admin.ToString())
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });  // Admin paneline yönlendir
                }

                return RedirectToAction("Index", "Home");  // Diğer kullanıcılar için Home/Index
            }
            await service.LoginAsync(vm);
            if (string.IsNullOrEmpty(ReturnUrl))
            {
                return RedirectToAction("Index", "Home");
            }
            return LocalRedirect(ReturnUrl);

        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await service.LogoutAsync();
            return RedirectToAction("Login", "Account");
        }

    }
}
