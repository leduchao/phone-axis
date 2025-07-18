using MediatR;
using PhoneAxis.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace PhoneAxis.Application.Commands.Category;

public record CreateCategoryCommand([Required] string CategoryName, string? Description) : IRequest<Result>;
