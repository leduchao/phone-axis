namespace PhoneAxis.Application.Constants;

public static class AuthConstant
{
    public const string UnknownUser = "UnknownUser";
}

public static class AuthMessageConstant
{
    public const string CredentialsRequired = "Email or Username is required";
    public const string PasswordRequired = "Password is required";

    public const string InvalidUsername = "Invalid username";
    public const string InvalidPassword = "Invalid password";
    public const string InvalidCredentials = "Invalid credentials (email or username)";
    public const string UserNotFound = "User not found";
    public const string UserExists = "User already exists";

    public const string SignUpSuccess = "User registered successfully";
    public const string SignUpFail = "User registered fail";
    public const string SignInSuccess = "User sign in successfully";
    public const string SignInFail = "User sign in fail";
    public const string SignOutSuccess = "User sign out successfully";
    public const string RefreshTokenSuccess = "Refresh token successfully";
    public const string RefreshTokenFail = "Refresh token fail";
    public const string GetRefreshTokenFail = "Refresh token is invalid";

    public const string SendMailSuccess = "Send mail successfully";
    public const string SendMailFail = "Send mail fail";
    public const string VerifyOtpSuccess = "Verify OTP successfully";
    public const string VerifyOtpFail = "Verify OTP fail";
    public const string UserNotActive = "User is not active";
    public const string UserNotConfirmed = "User is not confirmed";
}
