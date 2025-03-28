namespace PhoneAxis.Application.DTOs.Auth;

public class AuthRequest
{
    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string Password { get; set; } = string.Empty;

    public AuthRequest()
    {
        
    }

    public AuthRequest(string? userName, string? email, string password)
    {
        UserName = userName;
        Email = email;
        Password = password;
    }
}
