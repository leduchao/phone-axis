namespace PhoneAxis.Application.DTOs.Auth;

public class AuthResponse
{
    public int Code { get; set; }

    public string? Message { get; set; }

    public string? AccessToken { get; set; }

    public bool Success { get; set; }

    public AuthResponse()
    {
        
    }

    public static AuthResponse GetSuccessResponse(int code, string accessToken = "", string message = "")
    {
        return new AuthResponse
        {
            Code = code,
            Message = message,
            AccessToken = accessToken,
            Success = true
        };
    }

    public static AuthResponse GetFailureResponse(int code, string errors)
    {
        return new AuthResponse
        {
            Code = code,
            Message = errors,
            AccessToken = string.Empty,
            Success = false
        };
    }
}
