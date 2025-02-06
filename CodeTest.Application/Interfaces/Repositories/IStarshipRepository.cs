using CodeTest.Domain.Entities;

namespace CodeTest.Application.Interfaces.Repositories;

public interface IStarshipRepository
{
    Task AddAsync(Starship starship);
}