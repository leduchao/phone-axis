using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PhoneAxis.Api.DTOs;
using PhoneAxis.Application.Commands.Auth.SignIn;
using PhoneAxis.Application.Commands.Auth.SignUp;

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
            var errors = GetModelStateErrors(ModelState);
            return BadRequest(errors);
        }

        var command = new SignInCommand(request.Email, request.Password, request.RememberMe);
        var response = await _mediator.Send(command);

        return StatusCode(response.StatusCode, response);
    }

    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp(SignUpRequest request)
    {
        if (!ModelState.IsValid)
        {
            var errors = GetModelStateErrors(ModelState);
            return BadRequest(errors);
        }

        var command = new SignUpCommand(request.FirstName, request.Email, request.Password);
        var response = await _mediator.Send(command);

        return StatusCode(response.StatusCode, response);
    }

    private static IEnumerable<string> GetModelStateErrors(ModelStateDictionary modelState)
    {
        return modelState.Values.SelectMany(p => p.Errors).Select(p => p.ErrorMessage);
    }
}
