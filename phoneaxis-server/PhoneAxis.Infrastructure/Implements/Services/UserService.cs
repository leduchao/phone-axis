using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using PhoneAxis.Application.DTOs.User;
using PhoneAxis.Application.Interfaces.Repositories;
using PhoneAxis.Application.Interfaces.Services;
using PhoneAxis.Domain.Common;
using PhoneAxis.Domain.Entities;
using PhoneAxis.Infrastructure.Models;

namespace PhoneAxis.Infrastructure.Implements.Services;

public class UserService(
    IBaseRepository<MasterUser> masterUserRepository, 
    UserManager<AppUser> userManager) : BaseService<MasterUser>(masterUserRepository), IUserService
{
    private readonly UserManager<AppUser> _userManager = userManager;

    public async Task<Result<UserBasicInfor>> GetUserBasicInfor(Guid userId)
    {
        var masterUser = await GetByIdAsync(userId);
        var appUser = await _userManager.FindByIdAsync(userId.ToString());
        if (appUser is null) return Result<UserBasicInfor>.Fail([$"Not found user with ID={userId}"], StatusCodes.Status404NotFound);

        var isAdminUser = await _userManager.IsInRoleAsync(appUser, Role.Admin);
        var result = new UserBasicInfor(isAdminUser, masterUser.FirstName, "None profile picture");

        return Result<UserBasicInfor>.Success(result, "Get user info successfully");
    }
}
