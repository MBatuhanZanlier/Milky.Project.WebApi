using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUI.Dtos.AboutDtos;
using MilkyProject.WebUI.Dtos.ProductDtos;
using MilkyProject.WebUI.Dtos.TestimonialDtos;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MilkyProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AdminTestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminTestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> TestimonialList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44328/api/Testimonial");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44328/api/Testimonial/GetTestimonial?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateTestimonialDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44328/api/Testimonial", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("TestimonialList");
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateTestimonail()
        { return View(); }
        
        [HttpPost]
        public async Task<IActionResult> CreateTestimonail(CreateTestimonialDto createTestimonialDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createTestimonialDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44328/api/Testimonial", stringContent);
            if (responseMessage.IsSuccessStatusCode) { return RedirectToAction("TestimonialList"); }
            return View();
        }
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:44328/api/Testimonial?id=" + id);
            if (responseMessage.IsSuccessStatusCode) { return RedirectToAction("TestimonialList"); }
            return View();
        }

    }
}
