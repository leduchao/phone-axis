using MediatR;
using PhoneAxis.Domain.Common;
using PhoneAxis.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace PhoneAxis.Application.Commands.Product;

public sealed record CreateProductCommand(
    [Required] string ProductImage, 
    [Required] string ProductName, 
    string Description, 
    [Range(0, double.MaxValue)] decimal Price, 
    Guid CategoryId,
    ProductType Type = ProductType.Phone, 
    [Range(0, 100)] decimal DiscountPercentage = 0) : IRequest<Result>;
