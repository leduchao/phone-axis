using PhoneAxis.Application.DTOs.User;
using PhoneAxis.Domain.Common;

namespace PhoneAxis.Application.Interfaces.Services;

public interface IUserService
{
    Task<Result<UserBasicInfo>> GetUserBasicInforAsync(Guid userId);

    Task<IList<string>> GetUserRolesAsync(Guid userId);

    Task<(bool, Guid?, string?)> ValidateRefreshTokenAsync(string refreshToken);

    Task UpdateRefreshTokenAsync(string userId, string refreshToken);
}
