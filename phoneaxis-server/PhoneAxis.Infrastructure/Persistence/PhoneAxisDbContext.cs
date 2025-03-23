using Microsoft.EntityFrameworkCore;
using PhoneAxis.Domain.Entities;

namespace PhoneAxis.Infrastructure.Persistence;

public class PhoneAxisDbContext(DbContextOptions<PhoneAxisDbContext> options) : DbContext(options)
{
    DbSet<Phone> Phones { get; set; }

    DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSnakeCaseNamingConvention();
        base.OnModelCreating(modelBuilder);
    }
}
