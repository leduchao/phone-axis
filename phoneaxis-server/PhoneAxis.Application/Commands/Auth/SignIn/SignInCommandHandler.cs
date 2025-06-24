using MediatR;
using PhoneAxis.Application.DTOs.Auth;
using PhoneAxis.Application.Interfaces.Services;
using PhoneAxis.Domain.Common;

namespace PhoneAxis.Application.Commands.Auth.SignIn;

public class SignInCommandHandler(IAuthService authService) : IRequestHandler<SignInCommand, Result<AuthDto>>
{
    private readonly IAuthService _authService = authService;

    public async Task<Result<AuthDto>> Handle(SignInCommand command, CancellationToken cancellationToken)
    {
        var result = await _authService.SignInAsync(command);
        return result;
    }
}
