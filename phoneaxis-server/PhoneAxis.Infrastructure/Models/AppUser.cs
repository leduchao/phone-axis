using Microsoft.AspNetCore.Identity;

namespace PhoneAxis.Infrastructure.Models;

public class AppUser : IdentityUser<Guid>
{
    public string? RefreshToken { get; set; }
}
