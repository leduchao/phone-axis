using PhoneAxis.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneAxis.Domain.Entities;

public class Product : BaseEntity
{
    public string? ProductCode { get; set; }

    public string? ProductName { get; set; }

    public ProductType ProductType { get; set; } = ProductType.None;

    public decimal Price { get; set; }

    public string? Sku { get; set; }

    public int Stock { get; set; }

    public string ImageUrl { get; set; } = null!;

    public string? Description { get; set; }

    public IList<ProductImage> ProductImages { get; set; } = [];

    public Guid CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; } = null!;

    public bool IsFeatured { get; set; } = false;
}
