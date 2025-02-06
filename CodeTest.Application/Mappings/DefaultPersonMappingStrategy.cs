using CodeTest.Application.DTOs;
using CodeTest.Application.Interfaces.Mappings;
using CodeTest.Shared.Contracts;

namespace CodeTest.Application.Mappings;

public class DefaultPersonMappingStrategy : IMappingStrategy<StarWarsPersonResponse?, PersonDto?>
{
    public PersonDto? Map(StarWarsPersonResponse? apiPerson)
    {
        if (apiPerson == null) return null;

        return new PersonDto
        {
            Name = apiPerson.Name,
            BirthYear = apiPerson.BirthYear,
            EyeColor = apiPerson.EyeColor,
            Gender = apiPerson.Gender,
            HairColor = apiPerson.HairColor,
            Height = apiPerson.Height,
            Mass = apiPerson.Mass,
            SkinColor = apiPerson.SkinColor,
            Homeworld = apiPerson.Homeworld,
            Films = apiPerson.Films,
            Species = apiPerson.Species,
            Starships = apiPerson.Starships,
            Vehicles = apiPerson.Vehicles,
            Url = apiPerson.Url,
            Created = apiPerson.Created,
            Edited = apiPerson.Edited
        };
    }
}