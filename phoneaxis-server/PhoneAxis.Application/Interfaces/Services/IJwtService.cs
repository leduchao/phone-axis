namespace PhoneAxis.Application.Interfaces.Services;

public interface IJwtService
{
    string GenerateAccessToken(Guid userId, string email);

    Guid? GetUserIdFromAccessToken();
}
