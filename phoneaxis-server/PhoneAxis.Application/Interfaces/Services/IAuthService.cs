using PhoneAxis.Application.DTOs.Auth;

namespace PhoneAxis.Application.Interfaces.Services;

public interface IAuthService
{
    Task<AuthResponse> SignupAsync(SignupRequest request);

    Task<AuthResponse> LoginAsync(LoginRequest request);

    Task LogoutAsync();

    Task<bool> ConfirmPasswordAsync(Guid userId);
    
    Task<bool> ConfirmEmailAsync(string email);

    Task<bool> ConfirmPhoneNumberAsync(Guid userId);
}
