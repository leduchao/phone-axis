using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhoneAxis.Domain.Entities;
using PhoneAxis.Infrastructure.Models;

namespace PhoneAxis.Infrastructure.Persistence;

public class PhoneAxisDbContext(DbContextOptions<PhoneAxisDbContext> options) : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>(options)
{
	public DbSet<Product> Products { get; set; }

	public DbSet<ProductImage> ProductImages { get; set; }

	public DbSet<Category> Categories { get; set; }

	public DbSet<Order> Orders { get; set; }

	public DbSet<OrderDetail> OrderDetails { get; set; }

	public DbSet<MasterUser> MasterUsers { get; set; }

	public DbSet<Cart> Carts { get; set; }

	public DbSet<CartItem> CartItems { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		foreach (var entityType in builder.Model.GetEntityTypes())
		{
			var tableName = entityType.GetTableName();
			if (!string.IsNullOrEmpty(tableName) && tableName.StartsWith("AspNet"))
			{
				entityType.SetTableName(tableName[6..]);
			}
		}

		builder.Entity<Product>()
			.Property(p => p.Price)
			.HasPrecision(18, 4);

		builder.Entity<Product>()
			.Property(p => p.DiscountPercentage)
			.HasPrecision(5, 2);

		builder.Entity<Order>()
			.Property(p => p.TotalAmount)
			.HasPrecision(18, 4);

		builder.Entity<OrderDetail>()
			.Property(p => p.UnitPrice)
			.HasPrecision(18, 4);

		builder.Entity<CartItem>()
			.Property(p => p.UnitPrice)
			.HasPrecision(18, 4);
	}
}
