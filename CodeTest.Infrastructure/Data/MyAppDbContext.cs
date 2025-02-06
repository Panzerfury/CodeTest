using CodeTest.Domain.Entities;
using CodeTest.Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CodeTest.Infrastructure.Data;

public class MyAppDbContext : DbContext
{
    public MyAppDbContext(DbContextOptions<MyAppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Starship> Starships { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new StarshipConfiguration());
        modelBuilder.ApplyConfiguration(new VehicleConfiguration());
    }
}