using WeatherApi.Proto;
using WeatherApp.GrpcService;
using WeatherApp.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<WeatherApp.GrpcService.Services.WeatherService>();


app.MapDefaultEndpoints();

app.Run();
