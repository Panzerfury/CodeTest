using CodeTest.Application.CQRS.Starships.Commands;
using CodeTest.Application.DTOs;
using CodeTest.Application.Interfaces.Mappings;
using CodeTest.Application.Mappings;
using CodeTest.Domain.Entities;
using CodeTest.Shared.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CodeTest.Application;

public static class DependencyInjection
{
    public static void AddMappings(this IServiceCollection services)
    {
        services.AddScoped<IMappingStrategy<StarWarsPersonResponse?, PersonDto?>, DefaultPersonMappingStrategy>(); // Register strategy
        services.AddScoped<IMappingStrategy<CreateStarshipCommand, Starship>, CreateStarshipMappingStrategy>(); // Register strategy
        services.AddScoped<IMappingStrategy<Starship, StarshipDto>, StarshipDtoMappingStrategy>(); // Register strategy
        services.AddScoped<IMappingStrategy<Exception, ProblemDetails>, ExceptionToProblemDetailsMappingStrategy>(); // Register strategy
    }
}