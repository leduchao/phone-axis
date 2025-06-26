using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using PhoneAxis.Application.Commands.Auth;
using PhoneAxis.Application.Constants;
using PhoneAxis.Application.DTOs.Auth;
using PhoneAxis.Application.Interfaces;
using PhoneAxis.Application.Interfaces.Repositories;
using PhoneAxis.Application.Interfaces.Services;
using PhoneAxis.Application.Queries.Auth;
using PhoneAxis.Domain.Common;
using PhoneAxis.Domain.Constants;
using PhoneAxis.Domain.Entities;
using PhoneAxis.Infrastructure.Models;
using PhoneAxis.Infrastructure.Utils;

namespace PhoneAxis.Infrastructure.Implements.Services;

public class AuthService(
    IJwtService jwtService,
    UserManager<AppUser> userManager,
    SignInManager<AppUser> signInManager,
    IBaseRepository<MasterUser> masterUserRepo,
    IUnitOfWork unitOfWork) : BaseService<MasterUser>(masterUserRepo), IAuthService
{
    private readonly IJwtService _jwtService = jwtService;
    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly SignInManager<AppUser> _signInManager = signInManager;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public Task<bool> ConfirmEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ConfirmPasswordAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ConfirmPhoneNumberAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<SignInResponse>> SignInAsync(SignInQuery command)
    {
        var appUser = await _userManager.FindByEmailAsync(command.Email);
        if (appUser is null)
            return Result<SignInResponse>.Fail([AuthMessageConstant.InvalidCredentials], StatusCodes.Status404NotFound);

        var result = await _signInManager.CheckPasswordSignInAsync(appUser, command.Password, false);
        if (!result.Succeeded)
            return Result<SignInResponse>.Fail([AuthMessageConstant.InvalidPassword], StatusCodes.Status401Unauthorized);

        var authDto = new SignInResponse(_jwtService.GenerateAccessToken(appUser.Id, command.Email));
        return Result<SignInResponse>.Success(authDto, AuthMessageConstant.SignInSuccess);
    }

    public Task SignOutAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Result> SignUpAsync(SignUpCommand command)
    {
        if (!string.IsNullOrEmpty(command.Email))
        {
            var existedUser = await _userManager.FindByEmailAsync(command.Email);
            if (existedUser is not null)
                return Result.Fail([AuthMessageConstant.UserAlreadyExists]);
        }

        var (masterUser, appUser) = GenerateBothTypesOfUser(command);

        var result = await _userManager.CreateAsync(appUser, command.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description).ToArray();
            return Result.Fail(errors);
        }

        await AddUserRoleAsync(appUser);
        await AddAsync(masterUser);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success(AuthMessageConstant.SignUpSuccess, StatusCodes.Status201Created);
    }

    private static (MasterUser, AppUser) GenerateBothTypesOfUser(SignUpCommand command)
    {
        var userId = Guid.NewGuid(); // create a same id for both master user and app user
        var userName = AuthUtils.GenerateUserNameFromEmail(command.Email); // create user name from email
        var firstName = string.IsNullOrWhiteSpace(command.FirstName) ? AuthUtils.GenerateRandomUsername() : command.FirstName;

        var masterUser = new MasterUser(userId, userName, firstName, command.Email);
        var appUser = new AppUser(userId, userName, command.Email);

        return (masterUser, appUser);
    }

    private async Task AddUserRoleAsync(AppUser appUser)
    {
        var roleUsers = await _userManager.GetUsersInRoleAsync(Role.Admin);
        if (roleUsers is null || roleUsers.Count == 0)
            await _userManager.AddToRoleAsync(appUser, Role.Admin);
        else await _userManager.AddToRoleAsync(appUser, Role.User);
    }
}
