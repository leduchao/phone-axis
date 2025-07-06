using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using PhoneAxis.Application.DTOs.User;
using PhoneAxis.Application.Interfaces.Repositories;
using PhoneAxis.Application.Interfaces.Services;
using PhoneAxis.Domain.Common;
using PhoneAxis.Domain.Constants;
using PhoneAxis.Domain.Entities;
using PhoneAxis.Infrastructure.Models;

namespace PhoneAxis.Infrastructure.Implements.Services;

public class UserService(IBaseRepository<MasterUser> masterUserRepository, UserManager<AppUser> userManager) : IUserService
{
    private readonly IBaseRepository<MasterUser> _masterUserRepository = masterUserRepository;
    private readonly UserManager<AppUser> _userManager = userManager;

    public async Task<Result<UserBasicInfor>> GetUserBasicInforAsync(Guid userId)
    {
        var masterUser = await _masterUserRepository.GetByIdProjectedAsync(userId, p => new { p.FirstName, p.ProfilePicture });
        if (masterUser is null) 
            return Result<UserBasicInfor>.Fail([$"Not found master user with ID={userId}"], StatusCodes.Status404NotFound);

        var appUser = await _userManager.FindByIdAsync(userId.ToString());
        if (appUser is null) 
            return Result<UserBasicInfor>.Fail([$"Not found user with ID={userId}"], StatusCodes.Status404NotFound);

        var isAdminUser = await _userManager.IsInRoleAsync(appUser, Role.Admin);
        var result = new UserBasicInfor(isAdminUser, masterUser.FirstName, masterUser.ProfilePicture);

        return Result<UserBasicInfor>.Success(result, "Get user info successfully");
    }

    public async Task<IList<string>> GetUserRolesAsync(Guid userId)
    {
        var appUser = await _userManager.FindByIdAsync(userId.ToString()) 
            ?? throw new KeyNotFoundException("User not found");

        var userRole = await _userManager.GetRolesAsync(appUser);
        return userRole;
    }
}
