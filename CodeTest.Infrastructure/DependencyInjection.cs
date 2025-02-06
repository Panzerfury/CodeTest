using CodeTest.Application.Interfaces.HttpClients;
using CodeTest.Application.Interfaces.Repositories;
using CodeTest.Infrastructure.Data;
using CodeTest.Infrastructure.ExternalServices.StarWarsClient;
using CodeTest.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
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

    public static void AddDatabaseContext(this IServiceCollection services)
    {
        services.AddDbContext<MyAppDbContext>(options =>
            options.UseInMemoryDatabase("MyInMemoryDb"));
    }
    
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<IStarshipRepository, StarshipRepository>();
    }
}