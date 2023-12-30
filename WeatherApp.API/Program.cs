using WeatherApi.Proto;
using WeatherApp.Gateway.Services;
using WeatherApp.Gateway.Services.Interface;
using WeatherApp.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
// Add services to the container.
builder.Services.AddHttpForwarderWithServiceDiscovery();
builder.Services.AddGrpcServiceReference<WeatherService.WeatherServiceClient>("http://weatherapi");
//builder.Services.AddGrpcServiceReference<WeatherService.WeatherServiceClient>("http://localhost:5150");
builder.Services.AddControllers();
builder.Services.AddScoped<IWeatherService, WeatherServiceGrpc>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
