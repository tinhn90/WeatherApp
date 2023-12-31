using Newtonsoft.Json;
using WeatherApp.Web.Model;

public  class WeatherHttpClient
{
    private HttpClient _httpClient;
    public WeatherHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }  
    //get the weather data from the api
    public async Task<List<WeatherDto>> GetWeatherForecastAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<WeatherDto>>("WeatherForecast/Get") ?? [];
    }
}