using MediatR;
using PhoneAxis.Application.Interfaces;
using PhoneAxis.Application.Interfaces.Repositories;
using PhoneAxis.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace PhoneAxis.Application.Commands.Category;

public record CreateCategoryCommand([Required] string CategoryName, string? Description) : IRequest<Result>;

public class CreateCategoryCommandHandler(IBaseRepository<Domain.Entities.Category> categoryRepo, IUnitOfWork unitOfWork) : IRequestHandler<CreateCategoryCommand, Result>
{
    private readonly IBaseRepository<Domain.Entities.Category> _categoryRepo = categoryRepo;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var newCategory = new Domain.Entities.Category(request.CategoryName, request.Description);
        await _categoryRepo.AddAsync(newCategory);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success("Category created successfully");
    }
}
