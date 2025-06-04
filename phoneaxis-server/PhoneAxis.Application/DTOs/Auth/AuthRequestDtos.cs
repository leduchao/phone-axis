using System.ComponentModel.DataAnnotations;

namespace PhoneAxis.Application.DTOs.Auth;

public record AuthRequest(
    [MinLength(3)] string? UserName, 
    [EmailAddress] string Email, 
    [MinLength(6)] string Password);

public record SignInRequest(string? UserName, string Email, string Password, bool RememberMe) : AuthRequest(UserName, Email, Password);

public record SignUpRequest(
    string? UserName, string Email, string Password, 
    [MinLength(3)] string? FirstName, 
    [MinLength(3)] string? LastName,
    [MinLength(6)] string? Address) : AuthRequest(UserName, Email, Password);
