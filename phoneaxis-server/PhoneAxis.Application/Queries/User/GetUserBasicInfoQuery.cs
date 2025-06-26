using MediatR;
using PhoneAxis.Application.DTOs.User;
using PhoneAxis.Application.Interfaces.Services;
using PhoneAxis.Domain.Common;

namespace PhoneAxis.Application.Queries.User;

public record GetUserBasicInfoQuery(Guid UserId) : IRequest<Result<UserBasicInfor>>;

public class GetUserBasicInfoQueryHandler(IUserService userService) : IRequestHandler<GetUserBasicInfoQuery, Result<UserBasicInfor>>
{
    private readonly IUserService _userService = userService;

    public async Task<Result<UserBasicInfor>> Handle(GetUserBasicInfoQuery request, CancellationToken cancellationToken)
    {
        var result = await _userService.GetUserBasicInfor(request.UserId);
        return result;
    }
}
