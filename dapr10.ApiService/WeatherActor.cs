using Dapr.Actors;
using Dapr.Actors.Runtime;
using dapr10.ServiceDefaults;

namespace dapr10.ApiService;

[Actor]
public class WeatherActor(ActorHost host) : Actor(host), IWeatherApiClient
{
    string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

    
    public async Task<WeatherForecast[]> GetWeatherAsync()
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                    { Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = summaries[Random.Shared.Next(summaries.Length)]
                })
            .ToArray();
        return forecast;
    }
}