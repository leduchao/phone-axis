using MediatR;
using PhoneAxis.Application.DTOs.Product;
using PhoneAxis.Domain.Common;

namespace PhoneAxis.Application.Queries.Product;

public sealed record GetAllProductQuery() : IRequest<Result<IList<ProductListItem>>>;
