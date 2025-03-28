using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PhoneAxis.Application.DTOs.Auth;

public class AuthResponse
{
    public string? Code { get; set; }

    public string? Message { get; set; }

    public string? AccessToken { get; set; }

    public bool Success { get; set; }

    public AuthResponse()
    {
        
    }

    public static AuthResponse GetSuccessResponse(HttpStatusCode code, string accessToken)
    {
        return new AuthResponse
        {
            Code = code.ToString(),
            Message = string.Empty,
            AccessToken = accessToken,
            Success = true
        };
    }

    public static AuthResponse GetFailureResponse(HttpStatusCode code, string errors)
    {
        return new AuthResponse
        {
            Code = code.ToString(),
            Message = errors,
            AccessToken = string.Empty,
            Success = false
        };
    }
}
