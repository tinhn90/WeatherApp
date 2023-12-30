using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherApi.Proto;
using WeatherApp.Gateway.Services.Interface;

namespace WeatherApp.Gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private IWeatherService _weatherService;

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
    {
        _logger = logger;
        _weatherService = weatherService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<List<WeatherForecast>> GetAsync()
    {
        _logger.LogInformation($"Get weather {DateTime.UtcNow.ToString()}");

        return await _weatherService.GetWeatherForecastAsync();
    }
}
