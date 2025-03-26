using Microsoft.EntityFrameworkCore;
using PhoneAxis.Domain.Entities;

namespace PhoneAxis.Infrastructure.Persistence;

public class PhoneAxisDbContext(DbContextOptions<PhoneAxisDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }

    public DbSet<ProductImage> ProductImages { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSnakeCaseNamingConvention();
        base.OnModelCreating(modelBuilder);
    }
}
