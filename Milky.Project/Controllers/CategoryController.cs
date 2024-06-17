using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BussinessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace Milky.Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _categoryService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _categoryService.TInsert(category);
            return Ok("Kategori Başarıyla Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id) 
        {  
            _categoryService.TDelete(id);
            return Ok("Kategori başarıyla Silindi");
        }
        [HttpPut] 
        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.TUpdate(category);
            return Ok("Ürün başarıyla güncellendi");

        }
        [HttpGet("GetCategory")] 
        public IActionResult GetCategory(int id) 
        { 
             var value=_categoryService.TGetById(id); 
            return Ok(value);
        }
        
    }
}
