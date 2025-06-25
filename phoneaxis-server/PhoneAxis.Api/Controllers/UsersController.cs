using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneAxis.Application.Interfaces.Services;
using PhoneAxis.Application.Queries.User;
using PhoneAxis.Domain.Entities;

namespace PhoneAxis.Api.Controllers;

[Authorize]
[Route("api/users")]
[ApiController]
public class UsersController(
    IBaseService<MasterUser> masterUserService,
    IMediator mediator, IJwtService jwtService) : ControllerBase
{
    private readonly IBaseService<MasterUser> _masterUserService = masterUserService;
    private readonly IMediator _mediator = mediator;
    private readonly IJwtService _jwtService = jwtService;

    [HttpGet("get-all-users")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _masterUserService.GetAllAsync();
        return Ok(users);
    }

    [HttpGet("get-user-info")]
    public async Task<IActionResult> GetUserInfo()
    {
        var userId = _jwtService.GetUserIdFromAccessToken();
        if (userId is null) return Unauthorized("User ID not found in token.");

        var getUserBasicInfoQuery = new GetUserBasicInfoQuery(userId.GetValueOrDefault());
        var result = await _mediator.Send(getUserBasicInfoQuery);

        return StatusCode(result.StatusCode, result);
    }
}
