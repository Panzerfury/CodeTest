using CodeTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeTest.Infrastructure.Data.Configuration;

public class StarshipConfiguration : IEntityTypeConfiguration<Starship>
{
    public void Configure(EntityTypeBuilder<Starship> builder)
    {
        builder.ToTable("Starship");
        builder.HasKey(x => x.Id);
    }
}