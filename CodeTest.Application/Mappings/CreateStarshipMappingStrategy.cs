using CodeTest.Application.CQRS.Starships.Commands;
using CodeTest.Application.Interfaces.Mappings;
using CodeTest.Domain.Entities;

namespace CodeTest.Application.Mappings;

public class CreateStarshipMappingStrategy : IMappingStrategy<CreateStarshipCommand, Starship>
{
    public Starship Map(CreateStarshipCommand command)
    {
        return new Starship
        {
            Name = command.Name,
            Model = command.Model,
            Manufacturer = command.Manufacturer,
            Length = command.Length,
            CostInCredits = command.CostInCredits,
            Crew = command.Crew,
            Passengers = command.Passengers,
            MaxAtmospheringSpeed = command.MaxAtmospheringSpeed,
            CargoCapacity = command.CargoCapacity,
            Consumables = command.Consumables,
            Films = new List<string>(command.Films),
            Pilots = new List<string>(command.Pilots),
            Url = command.Url,
            StarshipClass = command.StarshipClass,
            HyperdriveRating = command.HyperdriveRating,
            Mgtl = command.Mgtl,
            Created = DateTime.UtcNow,
            Edited = DateTime.UtcNow
        };
    }
}