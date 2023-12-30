using WeatherApi.Proto;

namespace WeatherApp.Gateway.Services.Interface
{
    public interface IWeatherService
    {

        Task<List<WeatherForecast>> GetWeatherForecastAsync();
    }
}
