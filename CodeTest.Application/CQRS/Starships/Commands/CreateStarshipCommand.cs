using CodeTest.Application.DTOs;
using CodeTest.Application.Interfaces.Mappings;
using CodeTest.Application.Interfaces.Repositories;
using CodeTest.Domain.Entities;
using MediatR;

namespace CodeTest.Application.CQRS.Starships.Commands;

public class CreateStarshipCommand : IRequest<StarshipDto>
{
    public string? Name { get; set; }
    public string? Model { get; set; }
    public string? Manufacturer { get; set; }
    public string? Length { get; set; }
    public string? CostInCredits { get; set; }
    public string? Crew { get; set; }
    public string? Passengers { get; set; }
    public string? MaxAtmospheringSpeed { get; set; }
    public string? CargoCapacity { get; set; }
    public string? Consumables { get; set; }

    // Common collections
    public ICollection<string> Films { get; set; } = new List<string>();
    public ICollection<string> Pilots { get; set; } = new List<string>();

    public string? Url { get; set; }
    public string? StarshipClass { get; set; }
    public string? HyperdriveRating { get; set; }
    public string? Mgtl { get; set; }
}

public class CreateStarshipCommandHandler(
    IStarshipRepository repository,
    IMappingStrategy<CreateStarshipCommand, Starship> createStarshipMap,
    IMappingStrategy<Starship, StarshipDto> starshipMap)
    : IRequestHandler<CreateStarshipCommand, StarshipDto>
{
    public async Task<StarshipDto> Handle(CreateStarshipCommand request, CancellationToken cancellationToken)
    {
        var starShip = createStarshipMap.Map(request);
        await repository.AddAsync(starShip);
        return starshipMap.Map(starShip);
    }
}

//TODO: Add validation