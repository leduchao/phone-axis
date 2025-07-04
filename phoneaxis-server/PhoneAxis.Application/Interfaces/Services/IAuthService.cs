using PhoneAxis.Application.Commands.Auth;
using PhoneAxis.Application.DTOs.Auth;
using PhoneAxis.Application.Queries.Auth;
using PhoneAxis.Domain.Common;

namespace PhoneAxis.Application.Interfaces.Services;

public interface IAuthService
{
    Task<Result> SignUpAsync(SignUpCommand command);

    Task<Result<SignInResponse>> SignInAsync(SignInQuery command);

    Task SignOutAsync();

    Task<bool> ConfirmPasswordAsync(Guid userId);
    
    Task<bool> ConfirmEmailAsync(string email);

    Task<bool> ConfirmPhoneNumberAsync(Guid userId);
}
