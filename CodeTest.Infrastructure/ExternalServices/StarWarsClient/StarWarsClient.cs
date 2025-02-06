using System.Text.Json;
using CodeTest.Application.DTOs;
using CodeTest.Application.Interfaces.HttpClients;
using CodeTest.Application.Interfaces.Mappings;
using CodeTest.Shared.Contracts;

namespace CodeTest.Infrastructure.ExternalServices.StarWarsClient;

public class StarWarsClient(HttpClient httpClient, IMappingStrategy<StarWarsPersonResponse?, PersonDto?> mappingStrategy) : IStarWarsClient
{
    public async Task<PersonDto?> GetPersonAsync(int id)
    {
        var response = await httpClient.GetAsync($"people/{id}");

        if (!response.IsSuccessStatusCode)
            return null;
        
        var json = await response.Content.ReadAsStringAsync();
        var apiPerson = JsonSerializer.Deserialize<StarWarsPersonResponse>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        return apiPerson == null ? null : mappingStrategy.Map(apiPerson);
    }
}