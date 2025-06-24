using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PhoneAxis.Application.Commands.Auth.SignIn;
using PhoneAxis.Application.Commands.Auth.SignUp;
using PhoneAxis.Application.Constants;
using PhoneAxis.Application.DTOs.Auth;
using PhoneAxis.Application.Interfaces;
using PhoneAxis.Application.Interfaces.Repositories;
using PhoneAxis.Application.Interfaces.Services;
using PhoneAxis.Domain.Common;
using PhoneAxis.Domain.Entities;
using PhoneAxis.Infrastructure.Models;
using PhoneAxis.Infrastructure.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PhoneAxis.Infrastructure.Implements.Services;

public class AuthService(
    UserManager<AppUser> userManager,
    SignInManager<AppUser> signInManager,
    IConfiguration configuration,
    IBaseRepository<MasterUser> masterUserRepo,
    IUnitOfWork unitOfWork) : BaseService<MasterUser>(masterUserRepo), IAuthService
{
    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly SignInManager<AppUser> _signInManager = signInManager;
    private readonly IConfiguration _configuration = configuration;
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

    public async Task<Result<SignInResponse>> SignInAsync(SignInCommand command)
    {
        var appUser = await _userManager.FindByEmailAsync(command.Email);
        if (appUser is null)
            return Result<SignInResponse>.Fail([AuthMessageConstant.InvalidCredentials], StatusCodes.Status404NotFound);

        var result = await _signInManager.CheckPasswordSignInAsync(appUser, command.Password, false);
        if (!result.Succeeded)
            return Result<SignInResponse>.Fail([AuthMessageConstant.InvalidPassword], StatusCodes.Status401Unauthorized);

        var authDto = new SignInResponse(GenerateJwtToken(appUser));
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

        await CreateUserRoleAsync(appUser);
        await AddAsync(masterUser);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success(AuthMessageConstant.SignUpSuccess, StatusCodes.Status201Created);
    }

    private string GenerateJwtToken(AppUser user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private static (MasterUser, AppUser) GenerateBothTypesOfUser(SignUpCommand command)
    {
        var userId = Guid.NewGuid(); // create a same id for both master user and app user
        var userName = AuthUtils.GenerateUserNameFromEmail(command.Email); // create user name from email

        var masterUser = new MasterUser
        {
            Id = userId,
            UserName = userName,
            FirstName = string.IsNullOrWhiteSpace(command.FirstName) ? AuthUtils.GenerateRandomUsername() : command.FirstName,
            ContactEmail = command.Email
        };

        var appUser = new AppUser
        {
            Id = userId,
            UserName = userName,
            Email = command.Email
        };

        return (masterUser, appUser);
    }

    private async Task CreateUserRoleAsync(AppUser appUser)
    {
        var roleUsers = await _userManager.GetUsersInRoleAsync(Role.Admin);
        if (roleUsers is null || roleUsers.Count == 0)
        {
            await _userManager.AddToRoleAsync(appUser, Role.Admin);
        }
        else
        {
            await _userManager.AddToRoleAsync(appUser, Role.User);
        }
    }
}
