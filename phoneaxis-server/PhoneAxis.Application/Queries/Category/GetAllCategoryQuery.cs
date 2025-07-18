using MediatR;
using PhoneAxis.Application.DTOs.Category;
using PhoneAxis.Domain.Common;

namespace PhoneAxis.Application.Queries.Category;

public record GetAllCategoryQuery() : IRequest<Result<IList<CategoryListItem>>>;
