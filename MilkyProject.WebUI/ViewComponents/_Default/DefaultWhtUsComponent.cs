using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUI.Dtos.WhyUsDtos;
using Newtonsoft.Json;

namespace MilkyProject.WebUI.ViewComponents._Default
{
    public class DefaultWhtUsComponent : ViewComponent
    { 
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultWhtUsComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        { 
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44328/api/WhyUs"); 
            if (responseMessage.IsSuccessStatusCode) 
            { 
               var jsonData=await responseMessage.Content.ReadAsStringAsync(); 
               var values=JsonConvert.DeserializeObject<List<ResultWhyUsDto>>(jsonData); 
               return View(values);
            }
            return View(); 
        }
    }
}
