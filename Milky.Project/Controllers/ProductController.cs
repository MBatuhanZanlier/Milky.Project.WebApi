﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BussinessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace Milky.Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _productService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _productService.TInsert(product);
            return Ok("Ürün Başarıyla Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            _productService.TDelete(id);
            return Ok("Ürün Başarıtla Silindi");
        }
        [HttpPut] 
        public IActionResult UpdateProduct(Product product)
        {
            _productService.TUpdate(product);
            return Ok("Ürün Başarıyla Güncellendi");
        }
        [HttpGet("GetProduct")] 
        public IActionResult GetProduct(int id) 
        { 
            var values=_productService.TGetById(id);
            return Ok(values);
        }
        [HttpGet("GetProductWithCategory")] 
        public IActionResult GetProductWithCategory()
        {
            var values = _productService.TGetProductsWithCategory(); 
            return Ok(values);
        }
    }
}
