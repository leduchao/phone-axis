using MediatR;
using PhoneAxis.Application.DTOs.Category;
using PhoneAxis.Application.Interfaces.Repositories;
using PhoneAxis.Domain.Common;

namespace PhoneAxis.Application.Queries.Category;

public class GetAllCategoryQueryHandler(IBaseRepository<Domain.Entities.Category> categoryRepository) : IRequestHandler<GetAllCategoryQuery, Result<IList<CategoryListItem>>>
{
    private readonly IBaseRepository<Domain.Entities.Category> _categoryRepository = categoryRepository;

    public async Task<Result<IList<CategoryListItem>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllProjected<CategoryListItem>(
            $"{nameof(Domain.Entities.Category.Id)}, " +
            $"{nameof(Domain.Entities.Category.CategoryName)}, " +
            $"{nameof(Domain.Entities.Category.Description)}",
            null, null);

        return Result<IList<CategoryListItem>>.Success(categories, "Get all categories successfully");
    }
}
