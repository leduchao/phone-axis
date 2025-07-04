﻿using PhoneAxis.Application.DTOs.User;
using PhoneAxis.Domain.Common;

namespace PhoneAxis.Application.Interfaces.Services;

public interface IUserService
{
    Task<Result<UserBasicInfor>> GetUserBasicInforAsync(Guid userId);

    Task<IList<string>> GetUserRolesAsync(Guid userId);
}
