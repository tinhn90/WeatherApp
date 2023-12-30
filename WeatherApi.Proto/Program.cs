using WeatherApp.Service.Services;
using WeatherApp.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();


// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.

app.MapGrpcService<WeatherService>();
app.MapGet("/", async context =>
{
    var endpointDataSource = context
        .RequestServices.GetRequiredService<EndpointDataSource>();
    await context.Response.WriteAsJsonAsync(new
    {
        results = endpointDataSource
            .Endpoints
            .OfType<RouteEndpoint>()
            .Where(e => e.DisplayName?.StartsWith("gRPC") == true)
            .Select(e => new
            {
                name = e.DisplayName,
                pattern = e.RoutePattern.RawText,
                order = e.Order
            })
            .ToList()
    });
});
app.Run();
