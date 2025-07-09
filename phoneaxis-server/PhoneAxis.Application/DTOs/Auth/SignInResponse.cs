using PhoneAxis.Application.DTOs.User;

namespace PhoneAxis.Application.DTOs.Auth;

public record SignInResponse(string? AccessToken, UserBasicInfo? UserInfo);
