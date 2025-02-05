using CodeTest.Application.Interfaces.HttpClients;
using CodeTest.Infrastructure.ExternalServices.StarWarsClient;
using Microsoft.Extensions.DependencyInjection;

namespace CodeTest.Infrastructure;

public static class DependencyInjection
{
    public static void AddExternalHttpClient(this IServiceCollection services)
    {
        services.AddHttpClient<IStarWarsClient, StarWarsClient>(client =>
        {
            client.BaseAddress = new Uri("https://swapi.dev/api/");   
        });
    }
}