using Dapr.Actors;

namespace dapr10.ServiceDefaults;

public interface IWeatherApiClient : IActor
{
    Task<WeatherForecast[]> GetWeatherAsync();
}


public class WeatherForecast
{
    public DateOnly Date { get; set; }
    
    public int TemperatureC { get; set; }
    
    public string Summary { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}