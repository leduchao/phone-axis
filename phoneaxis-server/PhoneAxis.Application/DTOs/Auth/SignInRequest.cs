namespace PhoneAxis.Application.DTOs.Auth;

public class SignInRequest(string? username, string? email, string password, bool rememberMe) 
    : AuthRequest(username, email, password)
{
    public bool RememberMe { get; set; } = rememberMe;
}
