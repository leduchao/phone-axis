namespace PhoneAxis.Application.DTOs.Auth;

public record SignInResult(Guid UserId, TokenModel TokenModel);
