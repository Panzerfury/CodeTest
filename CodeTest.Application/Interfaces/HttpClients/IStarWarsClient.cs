using CodeTest.Application.DTOs;

namespace CodeTest.Application.Interfaces.HttpClients;

public interface IStarWarsClient
{
    Task<PersonDto?> GetPersonAsync(int id);
}