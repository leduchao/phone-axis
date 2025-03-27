using Microsoft.AspNetCore.Identity;

namespace PhoneAxis.Infrastructure.Persistence;

public class AppUser : IdentityUser<Guid>
{
    public string? RefreshToken { get; set; }
}
