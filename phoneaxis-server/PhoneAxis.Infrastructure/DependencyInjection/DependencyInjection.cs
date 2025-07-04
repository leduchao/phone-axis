﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using PhoneAxis.Infrastructure.Persistence;
using PhoneAxis.Application.Interfaces.Services;
using PhoneAxis.Infrastructure.Implements.Services;
using PhoneAxis.Application.Interfaces.Repositories;
using PhoneAxis.Infrastructure.Implements.Repositories;
using PhoneAxis.Application.Interfaces;
using PhoneAxis.Infrastructure.Implements;
using System.Data;
using MySqlConnector;

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

        // db connection for dapper using my sql
        services.AddScoped<IDbConnection>(sp => new MySqlConnection(configuration.GetConnectionString(PhoneAxisDbContext)));

        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<RoleSeeder>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
