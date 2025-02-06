using CodeTest.Application.Interfaces.Repositories;
using CodeTest.Domain.Entities;
using CodeTest.Infrastructure.Data;

namespace CodeTest.Infrastructure.Repositories;

public class StarshipRepository(MyAppDbContext context) : IStarshipRepository
{
    public async Task AddAsync(Starship starship)
    {
        context.Starships.Add(starship);
        await context.SaveChangesAsync();
    }
}