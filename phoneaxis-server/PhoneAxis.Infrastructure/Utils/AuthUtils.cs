namespace PhoneAxis.Infrastructure.Utils;

public static class AuthUtils
{
    public static string GenerateRandomUsername()
    {
        return $"User{DateTime.Now:yyyyMMddHHmmssfff}";
    }
}
