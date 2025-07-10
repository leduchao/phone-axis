using PhoneAxis.Application.DTOs.User;

namespace PhoneAxis.Application.DTOs.Auth;

public record SignInResponse(TokenModel? TokenModel, UserBasicInfo? UserInfo);
