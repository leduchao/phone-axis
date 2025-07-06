using MediatR;
using PhoneAxis.Application.Interfaces;
using PhoneAxis.Application.Interfaces.Repositories;
using PhoneAxis.Domain.Common;
using PhoneAxis.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace PhoneAxis.Application.Commands.Product;

public sealed record CreateProdductCommand(
    [Required] string ProductImage, 
    [Required] string ProductName, 
    string Description, 
    [Range(0, double.MaxValue)] decimal Price, 
    Guid CategoryId,
    ProductType Type = ProductType.None, 
    [Range(0, 100)] decimal DiscountPercentage = 0) : IRequest<Result>;

public class CreateProductCommandHandler(IBaseRepository<Domain.Entities.Product> productRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateProdductCommand, Result>
{
    private readonly IBaseRepository<Domain.Entities.Product> _productRepository = productRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(CreateProdductCommand request, CancellationToken cancellationToken)
    {
        var newproduct = new Domain.Entities.Product
        {
            ImageUrl = request.ProductImage,
            ProductName = request.ProductName,
            Description = request.Description,
            Price = request.Price,
            CategoryId = request.CategoryId,
            ProductType = request.Type,
            DiscountPercentage = request.DiscountPercentage
        };

        await _productRepository.AddAsync(newproduct);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success("Product created successfully");
    }
}