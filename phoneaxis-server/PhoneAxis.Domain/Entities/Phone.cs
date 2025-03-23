using System.ComponentModel.DataAnnotations.Schema;
using PhoneAxis.Domain.Enums;

namespace PhoneAxis.Domain.Entities;

public class Phone : BaseEntity
{
    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public PhoneType Type { get; set; } = PhoneType.TouchScreen;

    public int Stock { get; set; }

    public string Sku { get; set; } = string.Empty;

    [ForeignKey(nameof(Category))]
    public string CategoryId { get; set; } = default!;

    public Category Category { get; set; } = default!;

    public string ImageUrl { get; set; } = string.Empty;

    public bool IsFeatured { get; set; }
}
