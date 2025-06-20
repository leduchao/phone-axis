using MediatR;
using PhoneAxis.Application.DTOs.Auth;
using PhoneAxis.Application.Interfaces.Services;

namespace PhoneAxis.Application.Commands.Auth.SignUp;

public class SignUpCommandHandler(IAuthService authService) : IRequestHandler<SignUpCommand, AuthResponse>
{
    private readonly IAuthService _authService = authService;

    public async Task<AuthResponse> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        var result = await _authService.SignUpAsync(request);
        return result;
    }
}
