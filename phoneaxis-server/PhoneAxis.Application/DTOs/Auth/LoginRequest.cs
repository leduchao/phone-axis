namespace PhoneAxis.Application.DTOs.Auth;

public class LoginRequest : AuthRequest
{
    public bool RememberMe { get; set; }
}
