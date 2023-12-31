using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;
using WeatherApi.Proto;
using WeatherApp.Gateway.Services.Interface;

namespace WeatherApp.Gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private IWeatherService _weatherService;
    private IDistributedCache _cache;

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService, IDistributedCache distributedCache)
    {
        _logger = logger;
        _weatherService = weatherService;
        _cache = distributedCache;
    }

    [HttpGet]
    [Route("Get")]
    public async Task<List<WeatherForecast>> GetAsync()
    {
        _logger.LogInformation($"Get weather {DateTime.UtcNow.ToString()}");

        return await _weatherService.GetWeatherForecastAsync();
    }
    [HttpGet]
    [Route("GetCache")]
    public async Task<List<WeatherForecast>> GetCacheAsync()
    {
        _logger.LogInformation($"Get weather {DateTime.UtcNow.ToString()}");

        var cacheWeather = await _cache.GetAsync("weather");
        if (cacheWeather == null)
        {
            var data = await _weatherService.GetWeatherForecastAsync();

            await _cache.SetAsync("weather", Encoding.UTF8.GetBytes(JsonSerializer.Serialize(data)),new DistributedCacheEntryOptions() { AbsoluteExpiration = DateTime.Now.AddSeconds(10)});
            return data;
        }

        return JsonSerializer.Deserialize<List<WeatherForecast>>(cacheWeather)??new();
    }
}
