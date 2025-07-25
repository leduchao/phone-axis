using Microsoft.AspNetCore.Mvc;
using PhoneAxis.Domain.Common;
using PhoneAxis.Domain.Enums;

namespace PhoneAxis.Api.Utils;

public static class ErrorResultExtensions
{
    public static IActionResult ToErrorActionResult<T>(this Result<T> result)
    {
        //if (result.IsSuccess)
        //    return new OkObjectResult(result.Data);

        return result.ErrorCode switch
        {
            ErrorCode.NotFound => new NotFoundObjectResult(result),
            ErrorCode.BadRequest => new BadRequestObjectResult(result),
            ErrorCode.Conflict => new ConflictObjectResult(result),
            ErrorCode.Unauthorized => new UnauthorizedObjectResult(result),
            ErrorCode.Forbidden => new ForbidResult(),
            _ => new ObjectResult(new { messages = result.ErrorMessages ?? ["Internal server error"] }) { StatusCode = 500 }
        };
    }

    public static IActionResult ToErrorActionResult(this Result result)
    {
        //if (result.IsSuccess)
        //    return new OkResult();

        return result.ErrorCode switch
        {
            ErrorCode.NotFound => new NotFoundObjectResult(result),
            ErrorCode.BadRequest => new BadRequestObjectResult(result),
            ErrorCode.Conflict => new ConflictObjectResult(result),
            ErrorCode.Unauthorized => new UnauthorizedObjectResult(result),
            ErrorCode.Forbidden => new ForbidResult(),
            _ => new ObjectResult(new { messages = result.ErrorMessages ?? ["Internal server error"] }) { StatusCode = 500 }
        };
    }
}
