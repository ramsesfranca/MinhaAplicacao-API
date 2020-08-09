using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MinhaAplicacao_Cliente.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<WeatherForecast> WeatherForecastList;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44398/weatherforecast"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    WeatherForecastList = JsonConvert.DeserializeObject<List<WeatherForecast>>(apiResponse);
                }
            }

            return View(WeatherForecastList);
        }
    }

    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF { get; set; }
        public string Summary { get; set; }
    }
}
