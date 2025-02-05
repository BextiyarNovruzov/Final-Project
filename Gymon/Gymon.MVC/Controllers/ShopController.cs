using Microsoft.AspNetCore.Mvc;

namespace Gymon.MVC.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Product()
        {
            return View();
        }
        public IActionResult ProductDetails()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult CartCheckout()
        {
            return View();
        }
    }
}
