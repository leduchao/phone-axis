using PhoneAxis.Application.Constants;
using PhoneAxis.Domain.Common;

namespace PhoneAxis.Application.Errors;

public static class AuthError
{
    public static readonly Error InvalidCredentials = new("Auth.InvalidCredentials", AuthMessageConstant.InvalidCredentials);
    public static readonly Error InvalidPassword = new("Auth.InvalidPassword", AuthMessageConstant.InvalidPassword);
    public static readonly Error UserExists = new("Auth.UserExists", AuthMessageConstant.UserExists);
    public static readonly Error CreateUserFail = new("Auth.CreateUserFail", AuthMessageConstant.SignUpFail);
    public static readonly Error SignInFail = new("Auth.SignInFail", AuthMessageConstant.SignInFail);
    public static readonly Error InvalidRefreshToken = new("Auth.InvalidRefreshToken", AuthMessageConstant.GetRefreshTokenFail);
    public static readonly Error RefreshTokenFail = new("Auth.RefreshTokenFail", AuthMessageConstant.RefreshTokenFail);
}
