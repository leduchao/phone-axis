using MediatR;
using PhoneAxis.Application.DTOs.Product;
using PhoneAxis.Domain.Common;

namespace PhoneAxis.Application.Queries.Product;

public record GetProductDetailsQuery(string Slug) : IRequest<Result<ProductDetails>>;
