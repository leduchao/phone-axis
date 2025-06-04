using Microsoft.AspNetCore.Mvc;
using PhoneAxis.Application.Interfaces.Services;
using PhoneAxis.Domain.Entities;

namespace PhoneAxis.Api.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController(IBaseService<MasterUser> masterUserService) : ControllerBase
{
    private readonly IBaseService<MasterUser> _masterUserService = masterUserService;

    [HttpGet("get-all-users")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _masterUserService.GetAllAsync();
        return Ok(users);
    }
}
