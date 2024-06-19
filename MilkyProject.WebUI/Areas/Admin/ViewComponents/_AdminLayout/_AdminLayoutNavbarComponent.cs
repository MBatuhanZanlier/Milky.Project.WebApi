using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUI.Areas.Admin.ViewComponents._Layout
{
    public class _AdminLayoutNavbarComponent:ViewComponent
    { 
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
