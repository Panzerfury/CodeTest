using CodeTest.Application.Interfaces.HttpClients;

namespace CodeTest.Infrastructure.ExternalServices.StarWarsClient;

public class StarWarsClient(HttpClient httpClient) : IStarWarsClient
{
    
}