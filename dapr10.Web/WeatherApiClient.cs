using Dapr.Actors;
using Dapr.Actors.Client;
using Dapr.Client;
using dapr10.ServiceDefaults;

namespace dapr10.Web;



public class WeatherApiClient(IActorProxyFactory actorProxyFactory) : IWeatherApiClient
{
    public async Task<WeatherForecast[]> GetWeatherAsync()
    {
        return await actorProxyFactory.CreateActorProxy<IWeatherApiClient>(ActorId.CreateRandom(), "WeatherActor").GetWeatherAsync();
    }
}

