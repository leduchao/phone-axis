using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneAxis.Application.Queries.User;

namespace PhoneAxis.Api.Controllers;

[Authorize]
[Route("api/users")]
[ApiController]
public class UsersController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("get-all-users")]
    public async Task<IActionResult> GetAllUsers()
    {
        var response = await _mediator.Send(new GetAllUserQuery());
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet("get-user-basic-info")]
    public async Task<IActionResult> GetUserBasicInfo()
    {
        var response = await _mediator.Send(new GetUserBasicInfoQuery());
        return StatusCode(response.StatusCode, response);
    }
}
