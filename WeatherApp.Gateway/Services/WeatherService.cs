using WeatherApi.Proto;
using WeatherApp.Gateway.Services.Interface;

namespace WeatherApp.Gateway.Services
{
    public class WeatherServiceGrpc : IWeatherService
    {
        private readonly WeatherService.WeatherServiceClient _weatherClient;
        private readonly ILogger<WeatherServiceGrpc> _logger;
        public WeatherServiceGrpc(WeatherService.WeatherServiceClient weatherClient, ILogger<WeatherServiceGrpc> logger)
        {
            _weatherClient = weatherClient;
            _logger = logger;
        }
        public async Task<List<WeatherForecast>> GetWeatherForecastAsync()
        {
            _logger.LogInformation($"Get data from service gRPC at {DateTime.UtcNow}");
            var res = await _weatherClient.GetWeatherAsync(new GetWeatherRequest() { Country = "VN" });
            return res.WeatherForecasts.ToList();
        }
    }
}
