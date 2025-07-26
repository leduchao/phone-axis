using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneAxis.Api.Constants;
using PhoneAxis.Api.Utils;
using PhoneAxis.Application.Commands.Auth;
using PhoneAxis.Application.Constants;
using PhoneAxis.Application.DTOs.User;
using PhoneAxis.Application.Errors;
using PhoneAxis.Application.Queries.Auth;
using PhoneAxis.Domain.Common;
using PhoneAxis.Domain.Enums;

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
        if (!result.Succeeded)
        {
            RemoveCookie(CookieKeyConstant.ACCESS_TOKEN);
            return BadRequest(result);
        }

        else if (result.Data is not null && result.Data.TokenModel is not null)
        {
            SetCookie(CookieKeyConstant.ACCESS_TOKEN, result.Data.TokenModel.AccessToken, DateTimeOffset.UtcNow.AddDays(1.5));
            SetCookie(CookieKeyConstant.REFRESH_TOKEN, result.Data.TokenModel.RefreshToken, DateTimeOffset.UtcNow.AddDays(15));

            return Ok(Result<UserBasicInfo>.Success(result.Data.UserInfo));
        }

        return BadRequest(Result.Failure([AuthError.SignInFail]));
    }

    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp(SignUpCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.Succeeded) return BadRequest(result);

        return Ok();
    }

    [HttpPost("sign-out")]
    public IActionResult SignOutUser()
    {
        RemoveCookie(CookieKeyConstant.ACCESS_TOKEN);
        return Ok(Result.Success());
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken()
    {
        var refreshToken = GetCookie(CookieKeyConstant.REFRESH_TOKEN);
        if (string.IsNullOrEmpty(refreshToken))
        {
            return Unauthorized(Result.Failure([AuthError.InvalidRefreshToken]));
        }

        var result = await _mediator.Send(new RefreshTokenCommand(refreshToken));
        if (result is null)
        {
            return BadRequest(Result.Failure([AuthError.RefreshTokenFail]));
        }

        SetCookie(CookieKeyConstant.ACCESS_TOKEN, result.AccessToken, DateTimeOffset.UtcNow.AddDays(1.5));
        SetCookie(CookieKeyConstant.REFRESH_TOKEN, result.RefreshToken, DateTimeOffset.UtcNow.AddDays(15));

        return Ok(Result.Success());
    }

    private string? GetCookie(string key)
    {
        return Request.Cookies[key];
    }

    private void SetCookie(string key, string value, DateTimeOffset expires)
    {
        Response.Cookies.Append(key, value, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None,
            Expires = expires
        });
    }

    private void RemoveCookie(string key)
    {
        Response.Cookies.Delete(key);
    }
}
