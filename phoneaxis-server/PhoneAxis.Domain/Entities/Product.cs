using PhoneAxis.Domain.Common;
using PhoneAxis.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneAxis.Domain.Entities;

public class Product : BaseEntity
{
    public string? ProductCode { get; set; }

    public string ProductName { get; set; } = null!;

    public ProductType ProductType { get; set; } = ProductType.Phone;

    public decimal Price { get; set; }

    public string? Sku { get; set; }

    public int Stock { get; set; }

    public string ImageUrl { get; set; } = null!;

    public string? Description { get; set; }

    public string Slug { get; set; } = null!;

    public IList<ProductImage> ProductImages { get; set; } = [];

    public Guid CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; } = null!;

    public bool IsFeatured { get; set; } = false;

    public decimal DiscountPercentage { get; set; } = 0;

    public Product() { }

    public Product(string productName, decimal productPrice)
    {
        ProductName = productName;
        Price = productPrice;
        Slug = GenerateSlug(productName, Id.ToString());
    }

    private static string GenerateSlug(string productName, string productId)
    {
        productName = productName.ToLowerInvariant();
        productName = RegexHelper.SlugCleanupRegex().Replace(productName, "");
        productName = RegexHelper.SlugWhitespaceRegex().Replace(productName, "-").Trim('-');

        return $"{productName}-{productId}";
    }
}
