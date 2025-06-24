using Microsoft.AspNetCore.Identity;
using PhoneAxis.Domain.Entities;

namespace PhoneAxis.Infrastructure.Persistence;

public class RoleSeeder(RoleManager<IdentityRole<Guid>> roleManager)
{
    private readonly RoleManager<IdentityRole<Guid>> _roleManager = roleManager;

    public async Task SeedRolesAsync()
    {
        if (!await _roleManager.RoleExistsAsync(Role.Admin))
        {
            var adminRole = new IdentityRole<Guid>(Role.Admin);
            await _roleManager.CreateAsync(adminRole);
        }

        if (!await _roleManager.RoleExistsAsync(Role.User))
        {
            var userRole = new IdentityRole<Guid>(Role.User);
            await _roleManager.CreateAsync(userRole);
        }
    }
}
