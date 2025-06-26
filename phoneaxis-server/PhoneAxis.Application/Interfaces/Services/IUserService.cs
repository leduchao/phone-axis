using PhoneAxis.Application.DTOs.User;
using PhoneAxis.Domain.Common;
using PhoneAxis.Domain.Entities;

namespace PhoneAxis.Application.Interfaces.Services;

public interface IUserService : IBaseService<MasterUser>
{
    Task<Result<UserBasicInfor>> GetUserBasicInforAsync(Guid userId);

    Task<IList<string>> GetUserRolesAsync(Guid userId);
}
