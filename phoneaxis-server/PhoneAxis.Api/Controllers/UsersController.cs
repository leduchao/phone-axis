using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneAxis.Application.Interfaces.Services;
using PhoneAxis.Application.Queries.User;
using PhoneAxis.Domain.Common;

namespace PhoneAxis.Api.Controllers;

[Authorize]
[Route("api/users")]
[ApiController]
public class UsersController(IMediator mediator, IJwtService jwtService) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    private readonly IJwtService _jwtService = jwtService;

    [HttpGet("get-all-users")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _mediator.Send(new GetAllUserQuery());
        return Ok(users);
    }

    [HttpGet("get-user-basic-info")]
    public async Task<IActionResult> GetUserBasicInfo()
    {
        var userId = _jwtService.GetUserIdFromAccessToken();
        if (userId is null) 
            return StatusCode(StatusCodes.Status400BadRequest, Result.Fail(["User ID not found in token."]));

        var getUserBasicInfoQuery = new GetUserBasicInfoQuery(userId.GetValueOrDefault());
        var result = await _mediator.Send(getUserBasicInfoQuery);

        return StatusCode(result.StatusCode, result);
    }
}
