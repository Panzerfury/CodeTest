using CodeTest.Application.Interfaces.Repositories;
using CodeTest.Domain.Entities;
using CodeTest.Infrastructure.Data;

namespace CodeTest.Infrastructure.Repositories;

public class VehicleRepository(MyAppDbContext context) : IVehicleRepository
{
    public async Task AddAsync(Vehicle vehicle)
    {
        context.Vehicles.Add(vehicle);
        await context.SaveChangesAsync();
    }
}