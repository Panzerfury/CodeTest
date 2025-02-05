using CodeTest.Application.DTOs;
using CodeTest.Shared.Contracts;

namespace CodeTest.Application.Interfaces.Mappings;

public interface IPersonMappingStrategy
{
    PersonDto? Map(StarWarsPersonResponse? apiPerson);
}