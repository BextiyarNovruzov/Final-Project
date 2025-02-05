using Microsoft.AspNetCore.Mvc;

namespace Gymon.MVC.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SecoundAbout()
        {
            return View();
        }
    }
}
