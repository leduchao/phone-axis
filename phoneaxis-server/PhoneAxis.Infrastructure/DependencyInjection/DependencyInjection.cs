using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using PhoneAxis.Infrastructure.Persistence;
using PhoneAxis.Application.Interfaces.Services;
using PhoneAxis.Infrastructure.Implements.Services;
using PhoneAxis.Application.Interfaces.Repositories;
using PhoneAxis.Infrastructure.Implements.Repositories;
using PhoneAxis.Application.Interfaces;
using PhoneAxis.Infrastructure.Implements;
using PhoneAxis.Infrastructure.Constants;

namespace PhoneAxis.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PhoneAxisDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString(ConnectionStringConstant.SQL_SERVER)));

        // db connection for dapper using sql server
        services.AddScoped<IDbConnectionFactory, SqlConnectionFactory>();

        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<RoleSeeder>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
