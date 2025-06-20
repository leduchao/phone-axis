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

    public async Task<AuthResponse> SignInAsync(SignInCommand command)
    {
        var appUser = await _userManager.FindByEmailAsync(command.Email);
        if (appUser is null)
            return AuthResponse.Fail(StatusCodes.Status404NotFound, [AuthMessageConstant.InvalidCredentials]);

        var result = await _signInManager.CheckPasswordSignInAsync(appUser, command.Password, false);
        if (!result.Succeeded)
            return AuthResponse.Fail(StatusCodes.Status401Unauthorized, [AuthMessageConstant.InvalidPassword]);

        var accessToken = GenerateJwtToken(appUser);
        return AuthResponse.Success(StatusCodes.Status200OK, AuthMessageConstant.SignInSuccess, accessToken);
    }

    public Task SignOutAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<AuthResponse> SignUpAsync(SignUpCommand command)
    {
        if (!string.IsNullOrEmpty(command.Email))
        {
            var existedUser = await _userManager.FindByEmailAsync(command.Email);
            if (existedUser is not null)
                return AuthResponse.Fail(StatusCodes.Status400BadRequest, [AuthMessageConstant.UserAlreadyExists]);
        }

        var (masterUser, appUser) = GenerateBothTypesOfUser(command);

        var result = await _userManager.CreateAsync(appUser, command.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description).ToArray();
            return AuthResponse.Fail(StatusCodes.Status401Unauthorized, errors);
        }

        await AddAsync(masterUser);
        await _unitOfWork.SaveChangesAsync();

        return AuthResponse.Success(StatusCodes.Status201Created, AuthMessageConstant.SignUpSuccess, string.Empty);
    }

    private string GenerateJwtToken(AppUser user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName ?? "No name"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
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
}
