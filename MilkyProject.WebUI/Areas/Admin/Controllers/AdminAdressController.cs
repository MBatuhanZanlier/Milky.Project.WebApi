using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUI.Dtos.AdressDtos;
using MilkyProject.WebUI.Dtos.ProductDtos;
using MilkyProject.WebUI.Dtos.TestimonialDtos;
using Newtonsoft.Json;
using System.Text;

namespace MilkyProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AdminAdressController : Controller
    { 
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminAdressController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> AdminAdressList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44328/api/Adress");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAdressDto>>(jsonData);
                return View(values);
            }
            return View(); 
            
        }
        [HttpGet] 
        public async Task<IActionResult> UpdateAdress(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44328/api/Adress/GetAdress?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateAdressDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost] 
        public async Task<IActionResult> UpdateAdress(UpdateAdressDto updateAdressDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateAdressDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44328/api/Adress", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AdminAdressList");
            }
            return View();

        }


    }
}
