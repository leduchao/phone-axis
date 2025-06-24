using Microsoft.AspNetCore.Http;
using PhoneAxis.Application.Interfaces.Services;
using System.Security.Claims;

namespace PhoneAxis.Infrastructure.Implements.Services;

public class TokenClaimReader(IHttpContextAccessor httpContextAccessor) : ITokenClaimReader
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public Guid? GetUserId()
    {
        var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIdClaim != null && Guid.TryParse(userIdClaim, out var userId))
            return userId;

        return null;
    }
}
