using MediatR;
using PhoneAxis.Application.Constants;
using PhoneAxis.Application.DTOs.Auth;
using PhoneAxis.Application.Interfaces.Services;
using PhoneAxis.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace PhoneAxis.Application.Queries.Auth;

public record SignInQuery(
    [Required][EmailAddress] string Email, 
    [Required][Length(6, 100)] string Password, 
    bool RememberMe) : IRequest<Result<SignInResponse>>;

public class SignInQueryHandler(IAuthService authService, IUserService userService) : IRequestHandler<SignInQuery, Result<SignInResponse>>
{
    private readonly IAuthService _authService = authService;
    private readonly IUserService _userService = userService;

    public async Task<Result<SignInResponse>> Handle(SignInQuery command, CancellationToken cancellationToken)
    {
        var signInResult = await _authService.SignInAsync(command);
        if (signInResult.IsSuccess && signInResult.Data is not null)
        {
            var userInfoResult = await _userService.GetUserBasicInforAsync(signInResult.Data.UserId);
            return Result<SignInResponse>.Success(
                new SignInResponse(signInResult.Data.TokenModel, userInfoResult.Data), 
                AuthMessageConstant.SignInSuccess);
        }

        return Result<SignInResponse>.Fail(signInResult.Errors, signInResult.StatusCode);

    }
}
