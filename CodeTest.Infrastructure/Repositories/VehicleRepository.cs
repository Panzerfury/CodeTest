using CodeTest.Application.Interfaces.Repositories;
using CodeTest.Domain.Entities;

namespace CodeTest.Infrastructure.Repositories;

public class VehicleRepository : IVehicleRepository
{
    public Task AddAsync(Vehicle vehicle)
    {
        throw new NotImplementedException();
    }
}