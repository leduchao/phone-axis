﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PhoneAxis.Application.DTOs.Auth;
using PhoneAxis.Application.Interfaces.Services;
using PhoneAxis.Domain.Entities;
using PhoneAxis.Infrastructure.Models;
using PhoneAxis.Infrastructure.Persistence;
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

    public async Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        var isValidRequest = CheckValidAuthRequest(request);
        if (!isValidRequest.Item1)
        {
            return AuthResponse.GetFailureResponse(StatusCodes.Status400BadRequest, isValidRequest.Item2);
        }

        var appUser = string.IsNullOrEmpty(request.Email) 
            ? await _userManager.FindByNameAsync(request.UserName ?? "no_name_user") 
            : await _userManager.FindByEmailAsync(request.Email);
        if (appUser is null)
        {
            return AuthResponse.GetFailureResponse(StatusCodes.Status404NotFound, "Your email or user name is not correct");
        }

        var result = await _signInManager.CheckPasswordSignInAsync(appUser, request.Password, false);
        if (!result.Succeeded)
        {
            return AuthResponse.GetFailureResponse(StatusCodes.Status401Unauthorized, "Password is incorrect");
        }

        var accessToken = GenerateJwtToken(appUser);
        return AuthResponse.GetSuccessResponse(StatusCodes.Status200OK, accessToken, "Login successfully");
    }

    public Task LogoutAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<AuthResponse> SignupAsync(SignupRequest request)
    {
        var isValidRequest = CheckValidAuthRequest(request);
        if (!isValidRequest.Item1)
        {
            return AuthResponse.GetFailureResponse(StatusCodes.Status400BadRequest, isValidRequest.Item2);
        }

        if (!string.IsNullOrEmpty(request.Email))
        {
            var existedUser = await _userManager.FindByEmailAsync(request.Email);
            if (existedUser is not null)
            {
                return AuthResponse.GetFailureResponse(StatusCodes.Status400BadRequest, $"User with email '{request.Email}' is existed");
            }
        }

        var userId = Guid.NewGuid(); // create a same id for both master user and app user

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
            var errors = string.Join(Environment.NewLine, result.Errors.Select(e => e.Description));
            return AuthResponse.GetFailureResponse(StatusCodes.Status401Unauthorized, errors);
        }

        _dbContext.MasterUsers.Add(masterUser);
        await _dbContext.SaveChangesAsync();

        return AuthResponse.GetSuccessResponse(StatusCodes.Status201Created, string.Empty, "Register account successfully");
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

    private static (bool, string) CheckValidAuthRequest(AuthRequest request)
    {
        if (string.IsNullOrEmpty(request.Email) && string.IsNullOrEmpty(request.UserName))
        {
            return (false, "Email or user name is required");
        }

        if (string.IsNullOrEmpty(request.Password))
        {
            return (false, "Password is required");
        }

        return (true, string.Empty);
    }
}
