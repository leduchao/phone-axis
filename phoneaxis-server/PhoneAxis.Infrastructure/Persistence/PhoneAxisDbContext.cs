using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PhoneAxis.Domain.Entities;

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
        builder.UseSnakeCaseNamingConvention();
        base.OnModelCreating(builder);

        const string oldPrefix = "AspNet"; // length = 6
        const string removePrefix = "asp_net_";
        const string newPrefix = "app_";

        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();
            if (!string.IsNullOrEmpty(tableName) && tableName.StartsWith(oldPrefix))
            {
                tableName = NamingConventionsExtensions.ToSnakeCase(tableName); // asp_net_... => length = 8
                entityType.SetTableName(string.Concat(newPrefix, tableName.AsSpan(removePrefix.Length)));
                SetConstraintNameToLower(entityType, removePrefix);
            }
        }
    }

    private static void SetConstraintNameToLower(IMutableEntityType entityType, string removePrefix)
    {
        var fks = entityType.GetForeignKeys();
        if (fks is not null && fks.Any())
        {
            foreach(var fk in fks)
            {
                fk.SetConstraintName(NamingConventionsExtensions.ToSnakeCase(fk.GetConstraintName()).Replace(removePrefix, string.Empty));
            }
        }

        var pks = entityType.GetKeys();
        if (pks is not null && pks.Any())
        {
            foreach (var pk in pks)
            {
                pk.SetName(NamingConventionsExtensions.ToSnakeCase(pk.GetDefaultName()).Replace(removePrefix, string.Empty));
            }
        }

        var idxs = entityType.GetIndexes();
        if (idxs is not null && idxs.Any())
        {
            foreach (var idx in idxs)
            {
                idx.SetDatabaseName(NamingConventionsExtensions.ToSnakeCase(idx.GetDatabaseName()).Replace(removePrefix, string.Empty));
            }
        }
    }
}
