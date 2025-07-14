using MediatR;
using PhoneAxis.Application.DTOs.Product;
using PhoneAxis.Application.Interfaces.Repositories;
using PhoneAxis.Domain.Common;

namespace PhoneAxis.Application.Queries.Product;

public record GetProductDetailsQuery(string Slug) : IRequest<Result<ProductDetails>>;

public partial class GetProductDetailsQueryHandler(IBaseRepository<Domain.Entities.Product> productRepo) : IRequestHandler<GetProductDetailsQuery, Result<ProductDetails>>
{
    private readonly IBaseRepository<Domain.Entities.Product> _productRepo = productRepo;

    public async Task<Result<ProductDetails>> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
    {
        var match = RegexHelper.SlugProductIdRegex().Match(request.Slug);
        if (!match.Success || !Guid.TryParse(match.Value, out var productId))
        {
            return Result<ProductDetails>.Fail(["Invalid product URL"]);
        }

        var product = await _productRepo.GetByIdProjectedAsync(
            productId, 
            p => new ProductDetails(
                p.Id, 
                p.ProductCode, 
                p.ImageUrl, 
                p.ProductName, 
                p.Price, 
                p.Description, 
                p.Slug, 
                p.ProductImages.Select(x => x.Url).ToList(), 
                p.ProductType.ToString(), 
                p.Category.CategoryName, 
                p.Sku, 
                p.DiscountPercentage));

        if (product is null)
        {
            return Result<ProductDetails>.Fail(["Product not found"]);
        }

        return Result<ProductDetails>.Success(product, "Get product details successfully");
    }
}
