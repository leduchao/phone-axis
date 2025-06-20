using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneAxis.Application.DTOs.Auth;
using PhoneAxis.Application.Interfaces.Services;

namespace PhoneAxis.Api.Controllers;

[AllowAnonymous]
[Route("api/auth")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn(SignInRequest request)
    {
        var response = await _authService.SignInAsync(request);
        if (!response.AuthResult)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp(SignUpRequest request)
    {
        var response = await _authService.SignUpAsync(request);
        if (!response.AuthResult)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
}
