using PhoneAxis.Application.DTOs.Auth;

namespace PhoneAxis.Application.Interfaces.Services;

public interface IAuthService
{
    Task<AuthResponse> SignUpAsync(SignUpRequest request);

    Task<AuthResponse> SignInAsync(SignInRequest request);

    Task SignOutAsync();

    Task<bool> ConfirmPasswordAsync(Guid userId);
    
    Task<bool> ConfirmEmailAsync(string email);

    Task<bool> ConfirmPhoneNumberAsync(Guid userId);
}
