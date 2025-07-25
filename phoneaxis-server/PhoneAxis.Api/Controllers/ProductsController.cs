using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneAxis.Api.Utils;
using PhoneAxis.Application.Commands.Product;
using PhoneAxis.Application.Queries.Product;

namespace PhoneAxis.Api.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("get-all-product")]
    public async Task<IActionResult> GetAllProducts()
    {
        var result = await _mediator.Send(new GetAllProductQuery());
        if (!result.IsSuccess)
        {
            return result.ToErrorActionResult();
        }

        return Ok(result);
    }

    [HttpGet("products/{slug}")]
    public async Task<IActionResult> GetProductBySlugGuid(string slug)
    {
        var result = await _mediator.Send(new GetProductDetailsQuery(slug));
        if (!result.IsSuccess)
        {
            return result.ToErrorActionResult();
        }

        return Ok(result);
    }

    [HttpPost("create-product")]
    public async Task<IActionResult> CreateProduct(CreateProductCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.IsSuccess)
        {
            return result.ToErrorActionResult();
        }

        return Ok(result);
    }
}
