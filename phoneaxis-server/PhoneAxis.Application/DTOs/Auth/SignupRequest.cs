using System.ComponentModel.DataAnnotations;

namespace PhoneAxis.Application.DTOs.Auth;

public class SignUpRequest(string? userName, string? email, string password, string? firstName) 
    : AuthRequest(userName, email, password)
{
    [MinLength(5)]
    public string? FirstName { get; set; } = firstName;

    [MinLength(3)]
    public string? LastName { get; set; }

    [MinLength(5)]
    public string? Address { get; set; }
}
