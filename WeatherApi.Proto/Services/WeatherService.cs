using Grpc.Core;
using System;
using WeatherApi.Proto;

namespace WeatherApp.Service.Services
{
    public class WeatherService : WeatherApi.Proto.WeatherService.WeatherServiceBase
    {
        private static readonly string[] Summaries = new[]
           {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
           };
        public override Task<WeatherApi.Proto.GetWeatherResponse> GetWeather(WeatherApi.Proto.GetWeatherRequest request, ServerCallContext context)
        {
            var response = new WeatherApi.Proto.GetWeatherResponse();
            var res = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.ToString(),
                TemperatureC = Random.Shared.Next(-20, 55).ToString(),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray();
            response.WeatherForecasts.Add(res);
            return Task.FromResult(response);
        }
    }
}
