using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        return StatusCode(result.StatusCode, result);
    }

    [HttpPost("create-prduct")]
    public async Task<IActionResult> CreateProduct(CreateProdductCommand command)
    {
        var result = await _mediator.Send(command);
        return StatusCode(result.StatusCode, result);
    }
}
