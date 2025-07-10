using Microsoft.AspNetCore.Identity;

namespace PhoneAxis.Infrastructure.Models;

public class AppUser : IdentityUser<Guid>
{
    public string? RefreshToken { get; set; }

    public DateTime? RefreshTokenExpireAt { get; set; }

    public AppUser()
    {
        
    }

    public AppUser(Guid id, string userName, string email)
    {
        Id = id;
        UserName = userName;
        Email = email;
    }
}
