using MediatR;
using PhoneAxis.Application.Interfaces.Services;
using PhoneAxis.Domain.Common;

namespace PhoneAxis.Application.Commands.Auth.SignUp;

public class SignUpCommandHandler(IAuthService authService) : IRequestHandler<SignUpCommand, Result>
{
    private readonly IAuthService _authService = authService;

    public async Task<Result> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        var result = await _authService.SignUpAsync(request);
        return result;
    }
}
