using Microsoft.AspNetCore.Mvc;

namespace Gymon.MVC.Controllers
{
    public class TestController : Controller
    {
        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("TestKey", "TestValue");
            return Content("Session set");
        }

        public IActionResult GetSession()
        {
            var value = HttpContext.Session.GetString("TestKey");
            return Content(value ?? "No value found in session");
        }
    }

}
