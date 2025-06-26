using PhoneAxis.Application.Commands.Auth;
using PhoneAxis.Application.DTOs.Auth;
using PhoneAxis.Application.Queries.Auth;
using PhoneAxis.Domain.Common;
using PhoneAxis.Domain.Entities;

namespace PhoneAxis.Application.Interfaces.Services;

public interface IAuthService : IBaseService<MasterUser>
{
    Task<Result> SignUpAsync(SignUpCommand command);

    Task<Result<SignInResponse>> SignInAsync(SignInQuery command);

    Task SignOutAsync();

    Task<bool> ConfirmPasswordAsync(Guid userId);
    
    Task<bool> ConfirmEmailAsync(string email);

    Task<bool> ConfirmPhoneNumberAsync(Guid userId);
}
