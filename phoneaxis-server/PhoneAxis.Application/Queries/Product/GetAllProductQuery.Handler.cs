using MediatR;
using PhoneAxis.Application.DTOs.Product;
using PhoneAxis.Application.Interfaces.Repositories;
using PhoneAxis.Domain.Common;

namespace PhoneAxis.Application.Queries.Product;

public class GetAllProductQueryHandler(IBaseRepository<Domain.Entities.Product> productRepository) : IRequestHandler<GetAllProductQuery, Result<IList<ProductListItem>>>
{
    private readonly IBaseRepository<Domain.Entities.Product> _productRepository = productRepository;

    public async Task<Result<IList<ProductListItem>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllProjected(p => 
            new ProductListItem(
                p.Id, 
                p.ImageUrl, 
                p.ProductName, 
                p.Description ?? string.Empty, 
                p.Slug, 
                p.Category.CategoryName, 
                p.Price, 
                p.DiscountPercentage));

        return Result<IList<ProductListItem>>.Success(products, "Get all product successfully");
    }
}
