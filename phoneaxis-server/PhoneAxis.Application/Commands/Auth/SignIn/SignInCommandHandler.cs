using MediatR;
using PhoneAxis.Application.DTOs.Auth;
using PhoneAxis.Application.Interfaces.Services;

namespace PhoneAxis.Application.Commands.Auth.SignIn;

public class SignInCommandHandler(IAuthService authService) : IRequestHandler<SignInCommand, AuthResponse>
{
    private readonly IAuthService _authService = authService;

    public async Task<AuthResponse> Handle(SignInCommand command, CancellationToken cancellationToken)
    {
        var result = await _authService.SignInAsync(command);
        return result;
    }
}
