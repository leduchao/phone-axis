using MediatR;
using PhoneAxis.Application.DTOs.Auth;
using PhoneAxis.Application.Interfaces.Services;
using PhoneAxis.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace PhoneAxis.Application.Queries.Auth;

public record SignInQuery(
    [Required][EmailAddress] string Email, 
    [Required][Length(6, 100)] string Password, 
    bool RememberMe) : IRequest<Result<SignInResponse>>;

public class SignInQueryHandler(IAuthService authService) : IRequestHandler<SignInQuery, Result<SignInResponse>>
{
    private readonly IAuthService _authService = authService;

    public async Task<Result<SignInResponse>> Handle(SignInQuery command, CancellationToken cancellationToken)
    {
        var result = await _authService.SignInAsync(command);
        return result;
    }
}
