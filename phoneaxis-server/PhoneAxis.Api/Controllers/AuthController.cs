using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneAxis.Api.DTOs;
using PhoneAxis.Api.Utils;
using PhoneAxis.Application.Commands.Auth.SignIn;
using PhoneAxis.Application.Commands.Auth.SignUp;
using PhoneAxis.Domain.Common;

namespace PhoneAxis.Api.Controllers;

[AllowAnonymous]
[Route("api/auth")]
[ApiController]
public class AuthController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn(SignInRequest request)
    {
        if (!ModelState.IsValid)
        {
            var errors = PresentationUtils.GetModelStateErrors(ModelState);
            return BadRequest(Result.Fail([.. errors]));
        }

        var command = new SignInCommand(request.Email, request.Password, request.RememberMe);
        var result = await _mediator.Send(command);

        return StatusCode(result.StatusCode, result);
    }

    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp(SignUpRequest request)
    {
        if (!ModelState.IsValid)
        {
            var errors = PresentationUtils.GetModelStateErrors(ModelState);
            return BadRequest(Result.Fail([.. errors]));
        }

        var command = new SignUpCommand(request.FirstName, request.Email, request.Password);
        var result = await _mediator.Send(command);

        return StatusCode(result.StatusCode, result);
    }
}
