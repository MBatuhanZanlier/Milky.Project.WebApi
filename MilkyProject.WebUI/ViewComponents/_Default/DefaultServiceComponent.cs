using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUI.ViewComponents._Default
{
    public class DefaultServiceComponent:ViewComponent
    { 
        public IViewComponentResult Invoke() { return View(); }
    } 
}
