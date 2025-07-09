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
		if (result.IsSuccess && result.Data is not null)
		{
			Response.Cookies.Append("access_token", result.Data.AccessToken ?? string.Empty, new CookieOptions
			{
				HttpOnly = true,
				Secure = true,
				SameSite = SameSiteMode.None,
				Expires = DateTimeOffset.UtcNow.AddDays(1.5)
			});

			var successResult = Result<UserBasicInfo>.Success(result.Data.UserInfo, result.Message);
			return StatusCode(successResult.StatusCode, successResult);
		}

		Response.Cookies.Delete("access_token");

		return StatusCode(result.StatusCode, result);
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
}
