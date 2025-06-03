using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PhoneAxis.Application.Constants;
using PhoneAxis.Application.DTOs.Auth;
using PhoneAxis.Application.Interfaces.Services;
using PhoneAxis.Domain.Entities;
using PhoneAxis.Infrastructure.Models;
using PhoneAxis.Infrastructure.Persistence;
using PhoneAxis.Infrastructure.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PhoneAxis.Infrastructure.Implements.Services;

public class AuthService(
    UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, 
    PhoneAxisDbContext dbContext, IConfiguration configuration) : IAuthService
{
    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly SignInManager<AppUser> _signInManager = signInManager;
    private readonly PhoneAxisDbContext _dbContext = dbContext;
    private readonly IConfiguration _configuration = configuration;

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

    public async Task<AuthResponse> SignInAsync(SignInRequest request)
    {
        var isValidRequest = ValidateAuthRequest(request);
        if (!isValidRequest.Item1) 
            return AuthResponse.Fail(StatusCodes.Status400BadRequest, [isValidRequest.Item2]);

        var appUser = string.IsNullOrEmpty(request.Email) 
            ? await _userManager.FindByNameAsync(request.UserName ?? AuthConstant.UnknownUser) 
            : await _userManager.FindByEmailAsync(request.Email);
        if (appUser is null) 
            return AuthResponse.Fail(StatusCodes.Status404NotFound, [AuthMessageConstant.InvalidCredentials]);

        var result = await _signInManager.CheckPasswordSignInAsync(appUser, request.Password, false);
        if (!result.Succeeded) 
            return AuthResponse.Fail(StatusCodes.Status401Unauthorized, [AuthMessageConstant.InvalidPassword]);

        var accessToken = GenerateJwtToken(appUser);
        return AuthResponse.Success(StatusCodes.Status200OK, AuthMessageConstant.SignInSuccess, accessToken);
    }

    public Task SignOutAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<AuthResponse> SignUpAsync(SignUpRequest request)
    {
        var isValidRequest = ValidateAuthRequest(request);
        if (!isValidRequest.Item1) 
            return AuthResponse.Fail(StatusCodes.Status400BadRequest, [isValidRequest.Item2]);

        if (!string.IsNullOrEmpty(request.Email))
        {
            var existedUser = await _userManager.FindByEmailAsync(request.Email);
            if (existedUser is not null) 
                return AuthResponse.Fail(StatusCodes.Status400BadRequest, [AuthMessageConstant.UserAlreadyExists]);
        }

        var userId = Guid.NewGuid(); // create a same id for both master user and app user

        var masterUser = new MasterUser
        {
            Id = userId,
            UserName = request.UserName,
            FirstName = string.IsNullOrWhiteSpace(request.FirstName) ? AuthUtils.GenerateRandomUsername() : request.FirstName,
            LastName = request.LastName,
            ContactEmail = request.Email
        };

        var appUser = new AppUser
        {
            Id = userId,
            Email = request.Email,
            UserName = request.UserName
        };

        var result = await _userManager.CreateAsync(appUser, request.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description).ToArray();
            return AuthResponse.Fail(StatusCodes.Status401Unauthorized, errors);
        }

        _dbContext.MasterUsers.Add(masterUser);
        await _dbContext.SaveChangesAsync();

        return AuthResponse.Success(StatusCodes.Status201Created, string.Empty, AuthMessageConstant.SignUpSuccess);
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

    private static (bool, string) ValidateAuthRequest(AuthRequest request)
    {
        if (string.IsNullOrEmpty(request.Email) && string.IsNullOrEmpty(request.UserName))
        {
            return (false, AuthMessageConstant.CredentialsRequired);
        }

        if (string.IsNullOrEmpty(request.Password))
        {
            return (false, AuthMessageConstant.PasswordRequired);
        }

        return (true, string.Empty);
    }
}
