using CodeTest.Application.CQRS.ApproveMissions.Commands;
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
        services.AddSingleton<IMappingStrategy<StarWarsPersonResponse?, PersonDto?>, DefaultPersonMappingStrategy>(); // Register strategy
        services.AddSingleton<IMappingStrategy<CreateStarshipCommand, Starship>, CreateStarshipMappingStrategy>(); // Register strategy
        services.AddSingleton<IMappingStrategy<Starship, StarshipDto>, StarshipDtoMappingStrategy>(); // Register strategy
        services.AddSingleton<IMappingStrategy<Exception, ProblemDetails>, ExceptionToProblemDetailsMappingStrategy>(); // Register strategy
        services.AddSingleton<IMappingStrategy<ApproveMissionCommand, ApproveMission>, ApproveMissionMappingStrategy>(); // Register strategy
    }
}