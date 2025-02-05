using Microsoft.AspNetCore.Mvc;

namespace Gymon.MVC.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
