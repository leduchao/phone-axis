namespace PhoneAxis.Application.DTOs.Auth;

public class AuthResponse(int statusCode, string message = "") : BaseResponse(statusCode, message)
{
    public string? AccessToken { get; set; }

    public bool AuthResult { get; set; }

    public static AuthResponse Success(int statusCode, string message = "", string accessToken = "")
    {
        return new AuthResponse(statusCode, message)
        {
            AuthResult = true,
            AccessToken = accessToken
        };
    }

    public static AuthResponse Fail(int code, string[] errors)
    {
        return new AuthResponse(code, string.Empty)
        {
            Errors = errors,
            AuthResult = false,
            AccessToken = string.Empty
        };
    }
}
