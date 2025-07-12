namespace PhoneAxis.Application.DTOs.Product;

public record ProductDetails(
    Guid ProductId,
    string? ProductCode,
    string? ProductImage,
    string ProductName,
    decimal OriginalPrice,
    string? Description,
    string Slug,
    IList<string>? ProductImages,
    string ProductType, // smartphone, headphone...
    string Brand,
    string? Sku,
    decimal DiscountPercentage)
{
    public decimal PromotionalPrice => OriginalPrice * (1 - DiscountPercentage / 100);
};
