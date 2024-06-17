using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUI.ViewComponents._Layout
{
    public class _LayoutFooterComponent:ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
