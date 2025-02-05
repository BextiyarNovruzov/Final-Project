using Gymon.Core.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Gymon.MVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        if (User.Identity.IsAuthenticated)
        {
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            // Admin rolüne sahip kullanıcıyı Admin Dashboard'a yönlendir
            if (role == Roles.Admin.ToString())
            {
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }

            // Diğer giriş yapmış kullanıcıları Home sayfasına yönlendir
            return View(); // Home/Index'e yönlendirme yapar
        }

        // Giriş yapmamış kullanıcıyı Login sayfasına yönlendir
        return RedirectToAction("Login", "Account");
    }

    public async Task<IActionResult> AccessDenied()
    {
        return View();
    }
}

