using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PhoneAxis.Application.DTOs.Auth;
using PhoneAxis.Application.Interfaces.Services;
using PhoneAxis.Domain.Entities;
using PhoneAxis.Infrastructure.Models;
using PhoneAxis.Infrastructure.Persistence;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
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

    public async Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        var appUser = string.IsNullOrEmpty(request.Email) 
            ? await _userManager.FindByEmailAsync(request.UserName ?? "noneuser") 
            : await _userManager.FindByEmailAsync(request.Email);

        if (appUser is null)
        {
            return AuthResponse.GetFailureResponse(HttpStatusCode.Unauthorized, "User not found");
        }

        var result = await _signInManager.CheckPasswordSignInAsync(appUser, request.Password, false);
        if (!result.Succeeded)
        {
            return AuthResponse.GetFailureResponse(HttpStatusCode.Unauthorized, "Invalid password");
        }

        var accessToken = GenerateJwtToken(appUser);
        return AuthResponse.GetSuccessResponse(HttpStatusCode.OK, accessToken);
    }

    public Task LogoutAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<AuthResponse> SignupAsync(SignupRequest request)
    {
        var userId = Guid.NewGuid();

        var masterUser = new MasterUser
        {
            Id = userId,
            UserName = request.UserName,
            FirstName = request.FirstName,
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
            var errors = string.Join(",", result.Errors.Select(e => e.Description));
            return AuthResponse.GetFailureResponse(HttpStatusCode.BadRequest, errors);
        }

        _dbContext.MasterUsers.Add(masterUser);
        await _dbContext.SaveChangesAsync();

        var accessToken = GenerateJwtToken(appUser);
        return AuthResponse.GetSuccessResponse(HttpStatusCode.Created, accessToken);
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
            expires: DateTime.Now.AddDays(30),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
