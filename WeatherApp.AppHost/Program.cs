using Microsoft.Extensions.Hosting;

var builder = DistributedApplication.CreateBuilder(args);
//var redis = builder.AddRedisContainer("rediscache");

var weatherApi = builder.AddProject<Projects.WeatherApp_GrpcService>("weather-api");
//    .WithReference(redis);
var gateway = builder.AddProject<Projects.WeatherApp_Gateway>("gateway")
                       .WithReference(weatherApi);

builder.AddProject<Projects.WeatherApp_Web>("web")
        .WithReference(gateway);

builder.Build().Run();
