using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUI.ViewComponents._Default
{
    public class DefaultTestimonialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        { return View(); }
    }
}
