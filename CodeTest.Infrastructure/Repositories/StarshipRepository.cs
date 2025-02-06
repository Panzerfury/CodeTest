using CodeTest.Application.Interfaces.Repositories;
using CodeTest.Domain.Entities;

namespace CodeTest.Infrastructure.Repositories;

public class StarshipRepository : IStarshipRepository
{
    public Task AddAsync(Starship starship)
    {
        throw new NotImplementedException();
    }
}