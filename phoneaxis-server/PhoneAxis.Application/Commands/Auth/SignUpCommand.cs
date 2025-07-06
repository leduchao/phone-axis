using MediatR;
using PhoneAxis.Application.Interfaces.Services;
using PhoneAxis.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace PhoneAxis.Application.Commands.Auth;

public record SignUpCommand(
    [Length(3, 100)] string? FirstName, 
    [Required][EmailAddress] string Email, 
    [Required][Length(6, 100)] string Password) : IRequest<Result>;

public class SignUpCommandHandler(IAuthService authService) : IRequestHandler<SignUpCommand, Result>
{
    private readonly IAuthService _authService = authService;

    public async Task<Result> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        var result = await _authService.SignUpAsync(request);
        return result;
    }
}
