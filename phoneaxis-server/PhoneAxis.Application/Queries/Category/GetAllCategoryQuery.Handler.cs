using MediatR;
using PhoneAxis.Application.DTOs.Category;
using PhoneAxis.Application.Interfaces.Repositories;
using PhoneAxis.Domain.Common;
using PhoneAxis.Domain.Entities;

namespace PhoneAxis.Application.Queries.Category;

public class GetAllCategoryQueryHandler(IBaseRepository<Domain.Entities.Category> categoryRepository) : IRequestHandler<GetAllCategoryQuery, Result<IList<CategoryListItem>>>
{
    private readonly IBaseRepository<Domain.Entities.Category> _categoryRepository = categoryRepository;

    public async Task<Result<IList<CategoryListItem>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        string sqlQuery = $"""
            SELECT Id, CategoryName, Description
            FROM {_categoryRepository.GetTableName()}
            WHERE {nameof(BaseEntity.IsDeleted)} = @IsDeleted
            """;

        var categories = await _categoryRepository.DapperQueryAsync<CategoryListItem>(
            sqlQuery, 
            new { IsDeleted = false });

        return Result<IList<CategoryListItem>>.Success(categories, "Get all categories successfully");
    }
}
