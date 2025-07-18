using MediatR;
using PhoneAxis.Application.DTOs.Product;
using PhoneAxis.Application.Interfaces;
using PhoneAxis.Domain.Common;
using PhoneAxis.Domain.Enums;

namespace PhoneAxis.Application.Queries.Product;

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

        string sqlQuery = """
            SELECT
                p.Id AS ProductId,
                p.ProductCode AS ProductCode,
                p.ImageUrl AS ProductImage,
                p.ProductName,
                p.Price AS OriginalPrice,
                p.Description,
                p.Slug,
                pi.Url AS ImageUrl,
                p.ProductType,
                c.CategoryName AS Brand,
                p.Sku,
                p.DiscountPercentage
            FROM Products AS p
            INNER JOIN Categories AS c ON c.ID = p.CategoryId
            LEFT JOIN ProductImages AS pi ON pi.ProductId = p.Id
            WHERE p.Id = @ProductId AND p.IsDeleted = @IsDeleted
            """;

        var rows = await _productRepo.DapperQueryAsync<ProductDetailsRaw>(
            sqlQuery,
            new { ProductId = productId, IsDeleted = false });

        if (rows is null || rows.Count == 0)
        {
            return Result<ProductDetails>.Fail(["Product not found"]);
        }

        var result = new ProductDetails(
            rows[0].ProductId, 
            rows[0].ProductCode, 
            rows[0].ProductImage, 
            rows[0].ProductName, 
            rows[0].OriginalPrice, 
            rows[0].Description, 
            rows[0].Slug,
			[.. rows.Where(r => !string.IsNullOrEmpty(r.ImageUrl))
                    .Select(r => r.ImageUrl!)
                    .Distinct()],
			((ProductType)rows[0].ProductType).ToString(),
			rows[0].Brand, 
            rows[0].Sku, 
            rows[0].DiscountPercentage);

        return Result<ProductDetails>.Success(result, "Get product details successfully");
    }
}
