using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BussinessLayer.Abstract;

namespace Milky.Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public StatisticController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet] 
        public IActionResult CategoryCount() 
        {
            return Ok(_categoryService.TGetCategoryCount());
        }
    }
}
