using MediatR;
using PhoneAxis.Application.DTOs.User;
using PhoneAxis.Application.Interfaces.Services;
using PhoneAxis.Domain.Common;
using PhoneAxis.Domain.Enums;

namespace PhoneAxis.Application.Queries.User;

public class GetUserBasicInfoQueryHandler(IUserService userService, IJwtService jwtService) : IRequestHandler<GetUserBasicInfoQuery, Result<UserBasicInfo>>
{
    private readonly IUserService _userService = userService;
    private readonly IJwtService _jwtService = jwtService;

    public async Task<Result<UserBasicInfo>> Handle(GetUserBasicInfoQuery request, CancellationToken cancellationToken)
    {
        var userId = _jwtService.GetUserIdFromAccessToken();
        if (userId is not null) 
            return await _userService.GetUserBasicInforAsync(userId.Value);

        return Result<UserBasicInfo>.Fail(ErrorCode.BadRequest, ["User ID not found in token."]);
    }
}
