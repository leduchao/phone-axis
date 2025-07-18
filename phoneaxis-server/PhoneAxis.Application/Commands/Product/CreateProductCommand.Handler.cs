using MediatR;
using PhoneAxis.Application.Interfaces;
using PhoneAxis.Domain.Common;

namespace PhoneAxis.Application.Commands.Product;

public class CreateProductCommandHandler(IBaseRepository<Domain.Entities.Product> productRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateProductCommand, Result>
{
    private readonly IBaseRepository<Domain.Entities.Product> _productRepository = productRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var newProduct = new Domain.Entities.Product(request.ProductName, request.Price)
        {
            ImageUrl = request.ProductImage,
            Description = request.Description,
            CategoryId = request.CategoryId,
            ProductType = request.Type,
            DiscountPercentage = request.DiscountPercentage
        };

        await _productRepository.AddAsync(newProduct);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success("Product created successfully");
    }
}