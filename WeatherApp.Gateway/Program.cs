using Grpc.Net.Client.Web;
using WeatherApi.Proto;
using WeatherApp.Gateway.Services;
using WeatherApp.Gateway.Services.Interface;
using WeatherApp.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
// Add services to the container.
builder.AddRedisDistributedCache("redisCache");

//builder.Services.AddGrpcServiceReference<WeatherService.WeatherServiceClient>("http://localhost:5150");
builder.Services.AddControllers();
builder.Services.AddGrpcClient<WeatherService.WeatherServiceClient>(options =>
{
    options.Address = new Uri("http://weather-api");
}).ConfigurePrimaryHttpMessageHandler(
() => new GrpcWebHandler(new HttpClientHandler()));
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
