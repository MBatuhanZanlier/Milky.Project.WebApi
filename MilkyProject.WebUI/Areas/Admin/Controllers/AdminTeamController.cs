using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUI.Dtos.AboutDtos;
using MilkyProject.WebUI.Dtos.TeamDtos;
using Newtonsoft.Json;
using System.Text;

namespace MilkyProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AdminTeamController : Controller
    { private readonly IHttpClientFactory _httpClientFactory;

        public AdminTeamController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> AdminTeamList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44328/api/Team");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTeamDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet] 
        public async Task<IActionResult> AdminTeamUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44328/api/Team/GetTeam?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateTeamDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AdminTeamUpdate(UpdateTeamDto updateTeamDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateTeamDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44328/api/Team", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AdminTeamList");
            }
            return View();
        }
    }
}
