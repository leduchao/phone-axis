using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using PhoneAxis.Infrastructure.Persistence;
using PhoneAxis.Application.Interfaces.Services;
using PhoneAxis.Infrastructure.Implements.Services;

namespace PhoneAxis.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    private const string PhoneAxisDbContext = "PhoneAxisDbContext";

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PhoneAxisDbContext>(options =>
            options.UseMySql(
                configuration.GetConnectionString(PhoneAxisDbContext),
                ServerVersion.AutoDetect(configuration.GetConnectionString(PhoneAxisDbContext))));

        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}
