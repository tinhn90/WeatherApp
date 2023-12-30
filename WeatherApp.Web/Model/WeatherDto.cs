namespace WeatherApp.Web.Model
{
    public class WeatherDto
    {
        public string Date { get; set; }

        public string TemperatureC { get; set; }

        public string TemperatureF {  get; set; }

        public string? Summary { get; set; }
    }
}
