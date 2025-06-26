using MediatR;
using PhoneAxis.Application.DTOs.User;
using PhoneAxis.Application.Interfaces.Repositories;
using PhoneAxis.Domain.Common;
using PhoneAxis.Domain.Entities;

namespace PhoneAxis.Application.Queries.User;

public record GetAllUserQuery() : IRequest<Result<IList<UserInfo>>>;

public class GetAllUserQueryHandler(IBaseRepository<MasterUser> masterUserRepository) : IRequestHandler<GetAllUserQuery, Result<IList<UserInfo>>>
{
    private readonly IBaseRepository<MasterUser> _masterUserRepository = masterUserRepository;

    public async Task<Result<IList<UserInfo>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        var users = await _masterUserRepository.GetAllProjected(p => new UserInfo(p.UserName!, p.FirstName, p.ContactEmail!));
        var result = Result<IList<UserInfo>>.Success(users, "Get all user successfully");
        return result;
    }
}
