using PhoneAxis.Domain.Common;

namespace PhoneAxis.Application.Errors;

public static class ProductError
{
    public static readonly Error InvalidProductSlug = new("Product.InvalidSlug", "Invalid product slug");
    public static readonly Error ProductNotFound = new("Product.NotFound", "Product not found");
}
