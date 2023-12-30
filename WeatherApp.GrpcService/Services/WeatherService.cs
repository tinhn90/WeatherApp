using Grpc.Core;
using System;
using WeatherApi.Proto;

namespace WeatherApp.GrpcService.Services
{
    public class WeatherService : WeatherApi.Proto.WeatherService.WeatherServiceBase
    {
        private static readonly string[] Summaries = new[]
           {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
           };
        public override Task<GetWeatherResponse> GetWeather(GetWeatherRequest request, ServerCallContext context)
        {
            var response = new GetWeatherResponse();
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
