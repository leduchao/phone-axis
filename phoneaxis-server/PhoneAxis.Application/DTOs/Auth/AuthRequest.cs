using System.ComponentModel.DataAnnotations;

namespace PhoneAxis.Application.DTOs.Auth;

public class AuthRequest(string? userName, string? email, string password)
{
    [MinLength(5)]
    public string? UserName { get; set; } = userName;

    [MinLength(5)]
    [EmailAddress]
    public string? Email { get; set; } = email;

    [Required]
    [MinLength(6)]
    public string Password { get; set; } = password;
}
