using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WeatherApp.Web.Model;

namespace WeatherApp.Web.Pages
{
    public class WeatherCacheModel : PageModel
    {
        private WeatherHttpClient _weatherHttpClient;
        public List<WeatherDto> WeatherForecast { get; set; }
        public WeatherCacheModel(WeatherHttpClient weatherHttpClient) {
            _weatherHttpClient = weatherHttpClient;

        }  
        //get the weather data from the api
        public async Task OnGetAsync()
        {
            WeatherForecast = await _weatherHttpClient.GetCacheWeatherForecastAsync();
        }
    }
}
