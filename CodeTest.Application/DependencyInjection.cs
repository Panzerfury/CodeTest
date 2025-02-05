using CodeTest.Application.Interfaces.Mappings;
using CodeTest.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace CodeTest.Application;

public static class DependencyInjection
{
    public static void AddMappings(this IServiceCollection services)
    {
        services.AddScoped<IPersonMappingStrategy, DefaultPersonMappingStrategy>(); // Register strategy
    }
}