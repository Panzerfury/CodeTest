using CodeTest.Domain.Entities;

namespace CodeTest.Application.Interfaces.Repositories;

public interface IVehicleRepository
{
    Task AddAsync(Vehicle vehicle);
}