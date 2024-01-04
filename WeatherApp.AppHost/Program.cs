using Microsoft.Extensions.Hosting;

var builder = DistributedApplication.CreateBuilder(args);
var redis = builder.AddRedisContainer("redisCache");
var weatherApi = builder.AddProject<Projects.WeatherApp_GrpcService>("weather-api");
var gateway = builder.AddProject<Projects.WeatherApp_Gateway>("gateway")
                       .WithReference(weatherApi)
                       .WithReference(redis);

builder.AddProject<Projects.WeatherApp_Web>("web")
        .WithReference(gateway);

builder.Build().Run();
