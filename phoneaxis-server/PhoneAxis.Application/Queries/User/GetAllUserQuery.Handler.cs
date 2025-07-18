using MediatR;
using PhoneAxis.Application.DTOs.User;
using PhoneAxis.Application.Interfaces.Repositories;
using PhoneAxis.Domain.Common;
using PhoneAxis.Domain.Entities;

namespace PhoneAxis.Application.Queries.User;

public class GetAllUserQueryHandler(IBaseRepository<MasterUser> masterUserRepository) : IRequestHandler<GetAllUserQuery, Result<IList<UserInfo>>>
{
    private readonly IBaseRepository<MasterUser> _masterUserRepository = masterUserRepository;

    public async Task<Result<IList<UserInfo>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        string sqlQuery = """
            SELECT UserName, FirstName, ContactEmail
            FROM MasterUsers
            WHERE IsDeleted = @IsDeleted
            """;
        var users = await _masterUserRepository.DapperQueryAsync<UserInfo>(sqlQuery, new { IsDeleted = false });
        var result = Result<IList<UserInfo>>.Success(users, "Get all user successfully");
        return result;
    }
}
