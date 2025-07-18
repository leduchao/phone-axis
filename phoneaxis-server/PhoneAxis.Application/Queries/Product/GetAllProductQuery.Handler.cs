using MediatR;
using PhoneAxis.Application.DTOs.Product;
using PhoneAxis.Application.Interfaces;
using PhoneAxis.Domain.Common;

namespace PhoneAxis.Application.Queries.Product;

public class GetAllProductQueryHandler(IBaseRepository<Domain.Entities.Product> productRepository) : IRequestHandler<GetAllProductQuery, Result<IList<ProductListItem>>>
{
    private readonly IBaseRepository<Domain.Entities.Product> _productRepository = productRepository;

    public async Task<Result<IList<ProductListItem>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        string sqlQuery = """
            SELECT 
                p.Id AS ProductId, 
                p.ImageUrl AS ProductImage, 
                p.ProductName, 
                p.Description, 
                p.Slug, 
                c.CategoryName AS Brand, 
                p.Price AS OriginalPrice, 
                p.DiscountPercentage
            FROM Products AS p
            JOIN Categories AS c ON p.CategoryId = c.Id
            WHERE p.IsDeleted = @IsDeleted
            """;

        var products = await _productRepository.DapperQueryAsync<ProductListItem>(
            sqlQuery,
            new { IsDeleted = false });

        return Result<IList<ProductListItem>>.Success(products, "Get all product successfully");
    }
}
