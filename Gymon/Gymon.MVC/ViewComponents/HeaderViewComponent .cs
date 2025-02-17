using Microsoft.AspNetCore.Mvc;

namespace Gymon.MVC.ViewComponents
{
    public class HeaderViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
