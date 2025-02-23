using Gymon.BL.ViewModels.Order;
using Microsoft.AspNetCore.Mvc;

namespace Gymon.MVC.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new OrderDetailViewModel()); // Boş bir model ile view'ı döndür
        }
    }
}
