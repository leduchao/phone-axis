using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneAxis.Api.Utils;
using PhoneAxis.Application.Commands.Category;
using PhoneAxis.Application.Queries.Category;
using PhoneAxis.Domain.Common;

namespace PhoneAxis.Api.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoriesController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("get-all-category")]
    public async Task<IActionResult> GetAllCategory()
    {
        var result = await _mediator.Send(new GetAllCategoryQuery());
        if (!result.IsSuccess)
        {
            return result.ToErrorActionResult();
        }

        return Ok(result);
    }

    [HttpPost("create-category")]
    public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.IsSuccess)
        {
            return result.ToErrorActionResult();
        }

        return Ok(result);
    }
}
