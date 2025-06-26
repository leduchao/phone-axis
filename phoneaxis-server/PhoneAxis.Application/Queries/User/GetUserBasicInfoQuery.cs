using MediatR;
using PhoneAxis.Application.DTOs.User;
using PhoneAxis.Application.Interfaces.Services;
using PhoneAxis.Domain.Common;

namespace PhoneAxis.Application.Queries.User;

public record GetUserBasicInfoQuery() : IRequest<Result<UserBasicInfor>>;

public class GetUserBasicInfoQueryHandler(IUserService userService, IJwtService jwtService) : IRequestHandler<GetUserBasicInfoQuery, Result<UserBasicInfor>>
{
    private readonly IUserService _userService = userService;
    private readonly IJwtService _jwtService = jwtService;

    public async Task<Result<UserBasicInfor>> Handle(GetUserBasicInfoQuery request, CancellationToken cancellationToken)
    {
        var userId = _jwtService.GetUserIdFromAccessToken();
        if (userId is not null) 
            return await _userService.GetUserBasicInforAsync(userId.Value);

        return Result<UserBasicInfor>.Fail(["User ID not found in token."]);
    }
}
