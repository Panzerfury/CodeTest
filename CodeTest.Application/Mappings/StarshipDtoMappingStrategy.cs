using CodeTest.Application.DTOs;
using CodeTest.Application.Interfaces.Mappings;
using CodeTest.Domain.Entities;

namespace CodeTest.Application.Mappings;

public class StarshipDtoMappingStrategy : IMappingStrategy<Starship, StarshipDto>
{
    public StarshipDto Map(Starship starship)
    {
        return new StarshipDto()
        {
            Id = starship.Id,
            Name = starship.Name,
            Model = starship.Model,
            Manufacturer = starship.Manufacturer,
            Length = starship.Length,
            CostInCredits = starship.CostInCredits,
            Crew = starship.Crew,
            Passengers = starship.Passengers,
            MaxAtmospheringSpeed = starship.MaxAtmospheringSpeed,
            CargoCapacity = starship.CargoCapacity,
            Consumables = starship.Consumables,
            Films = starship.Films?.ToList() ?? new List<string>(),
            Pilots = starship.Pilots?.ToList() ?? new List<string>(),
            Url = starship.Url,
            StarshipClass = starship.StarshipClass,
            HyperdriveRating = starship.HyperdriveRating,
            Mgtl = starship.Mgtl,
            Created = starship.Created,
            Edited = starship.Edited
        };
    }
}