using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneAxis.Api.Utils;
using PhoneAxis.Application.Queries.User;
using PhoneAxis.Domain.Common;

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
        var result = await _mediator.Send(new GetAllUserQuery());
        if (!result.IsSuccess)
        {
            return result.ToErrorActionResult();
        }

        return Ok(result);
    }

    [HttpGet("get-user-basic-info")]
    public async Task<IActionResult> GetUserBasicInfo()
    {
        var result = await _mediator.Send(new GetUserBasicInfoQuery());
        if (!result.IsSuccess)
        {
            return result.ToErrorActionResult();
        }

        return Ok(result);
    }
}
