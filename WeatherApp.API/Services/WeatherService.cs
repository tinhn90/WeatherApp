using WeatherApi.Proto;
using WeatherApp.Gateway.Services.Interface;

namespace WeatherApp.Gateway.Services
{
    public class WeatherServiceGrpc : IWeatherService
    {
        private readonly WeatherService.WeatherServiceClient _weatherClient;
        public WeatherServiceGrpc(WeatherService.WeatherServiceClient weatherClient)
        {
            _weatherClient = weatherClient;
        }
        public async Task<List<WeatherForecast>> GetWeatherForecastAsync()
        {
            var res = await _weatherClient.GetWeatherAsync(new GetWeatherRequest() { Country = "VN" });
            return res.WeatherForecasts.ToList();
        }
    }
}
