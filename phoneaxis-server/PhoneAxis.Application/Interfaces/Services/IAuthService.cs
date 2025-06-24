using PhoneAxis.Application.Commands.Auth.SignIn;
using PhoneAxis.Application.Commands.Auth.SignUp;
using PhoneAxis.Application.DTOs.Auth;
using PhoneAxis.Domain.Common;
using PhoneAxis.Domain.Entities;

namespace PhoneAxis.Application.Interfaces.Services;

public interface IAuthService : IBaseService<MasterUser>
{
    Task<Result> SignUpAsync(SignUpCommand command);

    Task<Result<AuthDto>> SignInAsync(SignInCommand command);

    Task SignOutAsync();

    Task<bool> ConfirmPasswordAsync(Guid userId);
    
    Task<bool> ConfirmEmailAsync(string email);

    Task<bool> ConfirmPhoneNumberAsync(Guid userId);
}
