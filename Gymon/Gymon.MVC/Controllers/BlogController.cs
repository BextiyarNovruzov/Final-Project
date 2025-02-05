using Microsoft.AspNetCore.Mvc;

namespace Gymon.MVC.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Blogs()
        {
            return View();
        }
        public IActionResult BlogDetails()
        {
            return View();
        }
    }
}
