using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PhoneAxis.Application.DTOs.User;
using PhoneAxis.Application.Interfaces;
using PhoneAxis.Application.Interfaces.Services;
using PhoneAxis.Domain.Common;
using PhoneAxis.Domain.Constants;
using PhoneAxis.Domain.Entities;
using PhoneAxis.Domain.Enums;
using PhoneAxis.Infrastructure.Models;

namespace PhoneAxis.Infrastructure.Implements.Services;

public class UserService(IBaseRepository<MasterUser> masterUserRepository, UserManager<AppUser> userManager) : IUserService
{
    private readonly IBaseRepository<MasterUser> _masterUserRepository = masterUserRepository;
    private readonly UserManager<AppUser> _userManager = userManager;

    public async Task<Result<UserBasicInfo>> GetUserBasicInforAsync(Guid userId)
    {
        var masterUser = await _masterUserRepository.GetByIdProjectedAsync(userId, p => new { p.FirstName, p.ProfilePicture });
        if (masterUser is null) 
            return Result<UserBasicInfo>.Fail(ErrorCode.NotFound, [$"Not found master user with ID={userId}"]);

        var appUser = await _userManager.FindByIdAsync(userId.ToString());
        if (appUser is null) 
            return Result<UserBasicInfo>.Fail(ErrorCode.NotFound, [$"Not found user with ID={userId}"]);

        var isAdminUser = await _userManager.IsInRoleAsync(appUser, Role.ADMIN);
        var result = new UserBasicInfo(isAdminUser, masterUser.FirstName, masterUser.ProfilePicture);

        return Result<UserBasicInfo>.Success(result, "Get user info successfully");
    }

    public async Task<IList<string>> GetUserRolesAsync(Guid userId)
    {
        var appUser = await _userManager.FindByIdAsync(userId.ToString()) 
            ?? throw new KeyNotFoundException("User not found");

        var userRole = await _userManager.GetRolesAsync(appUser);
        return userRole;
    }

    public async Task<(bool, Guid?, string?)> ValidateRefreshTokenAsync(string refreshToken)
    {
        var appUser = await _userManager.Users.FirstOrDefaultAsync(
            x => x.RefreshToken == refreshToken && x.RefreshTokenExpireAt > DateTime.UtcNow);

        if (appUser is not null)
        {
            return (true, appUser.Id, appUser.Email);
        }

        return (false, null, null);
    }

    public async Task UpdateRefreshTokenAsync(string userId, string refreshToken)
    {
        var appUser = await _userManager.FindByIdAsync(userId.ToString());
        if (appUser is null) return;

        appUser.RefreshToken = refreshToken;
        appUser.RefreshTokenExpireAt = DateTime.UtcNow;
        await _userManager.UpdateAsync(appUser);
    }
}
