using System.ComponentModel.DataAnnotations;

namespace PhoneAxis.Application.DTOs.Product;

public sealed record ProductListItem(
    Guid ProductId, 
    string ProductImage,
    string ProductName,
    string Description,
    string Slug,
    string Brand,
    decimal OriginalPrice,
    decimal DiscountPercentage)
{
    public decimal PromotionalPrice => OriginalPrice * (1 - DiscountPercentage / 100);
}

