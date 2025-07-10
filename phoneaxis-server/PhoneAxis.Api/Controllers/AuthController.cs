using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneAxis.Application.Commands.Auth;
using PhoneAxis.Application.Constants;
using PhoneAxis.Application.DTOs.User;
using PhoneAxis.Application.Queries.Auth;
using PhoneAxis.Domain.Common;

namespace PhoneAxis.Api.Controllers;

[AllowAnonymous]
[Route("api/auth")]
[ApiController]
public class AuthController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn(SignInQuery query)
    {
        var result = await _mediator.Send(query);
        if (!result.IsSuccess)
        {
            Response.Cookies.Delete("access_token");
            return StatusCode(result.StatusCode, result);
        }

        if (result.Data is not null && result.Data.TokenModel is not null)
        {
            Response.Cookies.Append("access_token", result.Data.TokenModel.AccessToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTimeOffset.UtcNow.AddDays(1.5)
            });

            Response.Cookies.Append("refresh_token", result.Data.TokenModel.RefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTimeOffset.UtcNow.AddDays(15)
            });

            var successResult = Result<UserBasicInfo>.Success(result.Data.UserInfo, result.Message);
            return StatusCode(successResult.StatusCode, successResult);
        }

        return StatusCode(StatusCodes.Status400BadRequest, Result.Fail([AuthMessageConstant.SignInFail]));
    }

    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp(SignUpCommand command)
    {
        var result = await _mediator.Send(command);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPost("sign-out")]
    public IActionResult SignOutUser()
    {
        Response.Cookies.Delete("access_token", new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None,
            Path = "/"
        });

        return StatusCode(StatusCodes.Status200OK, Result.Success(AuthMessageConstant.SignOutSuccess));
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken()
    {
        var refreshToken = Request.Cookies["refresh_token"];
        if (string.IsNullOrEmpty(refreshToken))
        {
            return StatusCode(
                StatusCodes.Status401Unauthorized,
                Result.Fail([AuthMessageConstant.GetRefreshTokenFail], StatusCodes.Status401Unauthorized));
        }

        var result = await _mediator.Send(new RefreshTokenCommand(refreshToken));
        if (result is null)
        {
            return StatusCode(StatusCodes.Status400BadRequest, Result.Fail([AuthMessageConstant.RefreshTokenFail]));
        }

        Response.Cookies.Append("access_token", result.AccessToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None,
            Expires = DateTimeOffset.UtcNow.AddDays(1.5)
        });

        Response.Cookies.Append("refresh_token", result.RefreshToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None,
            Expires = DateTimeOffset.UtcNow.AddDays(15)
        });

        return StatusCode(StatusCodes.Status200OK, Result.Success(AuthMessageConstant.RefreshTokenSuccess));

    }
}
