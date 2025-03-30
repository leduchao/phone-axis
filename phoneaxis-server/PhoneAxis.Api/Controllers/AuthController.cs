using Microsoft.AspNetCore.Mvc;
using PhoneAxis.Application.DTOs.Auth;
using PhoneAxis.Application.Interfaces.Services;

namespace PhoneAxis.Api.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var response = await _authService.LoginAsync(request);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpPost("signup")]
    public async Task<IActionResult> Signup(SignupRequest request)
    {
        var response = await _authService.SignupAsync(request);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
}
