namespace PhoneAxis.Application.DTOs.Auth;

public class SignupRequest : AuthRequest
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Address { get; set; }
}
