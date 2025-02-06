using CodeTest.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CodeTest.Domain;

public static class DependencyInjection
{
    public static void AddProcessors(this IServiceCollection services)
    {
        // Register your custom chain-of-responsibility processor
        services.AddScoped<ApproveMissionProcessor>();
    }
}