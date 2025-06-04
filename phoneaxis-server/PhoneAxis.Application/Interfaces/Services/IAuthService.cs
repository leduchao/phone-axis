using PhoneAxis.Application.DTOs.Auth;
using PhoneAxis.Domain.Entities;

namespace PhoneAxis.Application.Interfaces.Services;

public interface IAuthService : IBaseService<MasterUser>
{
    Task<AuthResponse> SignUpAsync(SignUpRequest request);

    Task<AuthResponse> SignInAsync(SignInRequest request);

    Task SignOutAsync();

    Task<bool> ConfirmPasswordAsync(Guid userId);
    
    Task<bool> ConfirmEmailAsync(string email);

    Task<bool> ConfirmPhoneNumberAsync(Guid userId);
}
