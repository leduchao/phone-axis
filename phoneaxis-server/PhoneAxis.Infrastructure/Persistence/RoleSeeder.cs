using Microsoft.AspNetCore.Identity;
using PhoneAxis.Domain.Constants;

namespace PhoneAxis.Infrastructure.Persistence;

public class RoleSeeder(RoleManager<IdentityRole<Guid>> roleManager)
{
    private readonly RoleManager<IdentityRole<Guid>> _roleManager = roleManager;

    public async Task SeedRolesAsync()
    {
        if (!await _roleManager.RoleExistsAsync(Role.ADMIN))
        {
            var adminRole = new IdentityRole<Guid>(Role.ADMIN);
            await _roleManager.CreateAsync(adminRole);
        }

        if (!await _roleManager.RoleExistsAsync(Role.USER))
        {
            var userRole = new IdentityRole<Guid>(Role.USER);
            await _roleManager.CreateAsync(userRole);
        }
    }
}
