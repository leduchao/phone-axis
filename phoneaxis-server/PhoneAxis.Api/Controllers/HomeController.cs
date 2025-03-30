using Microsoft.AspNetCore.Mvc;

namespace PhoneAxis.Api.Controllers;

[Route("api/home")]
[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet("index")]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    public IActionResult Index()
    {
        return Ok("Welcome to PhoneAxis Home page");
    }

    [HttpGet("contact")]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    public IActionResult Contact()
    {
        return Ok("Welcome to PhoneAxis Contact page");
    }
}
