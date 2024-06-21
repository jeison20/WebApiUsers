﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApiUsers.Application.Ports.Secundary;
using WebApiUsers.EFCore.DataContext;
using WebApiUsers.EFCore.Implements;

namespace WebApiUsers.EFCore
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPersistence(
          this IServiceCollection services, IConfiguration configuration,
          string connectionStringName)
        {
            string? conn = configuration.GetConnectionString(connectionStringName);

            services.AddDbContext<WebApiContext>(options =>
                    options.UseSqlServer(conn));


            services.AddScoped<ICheckInformationSecundaryPort, CreateRecordSecundaryPort>();
            services.AddScoped<IUserInformationSecundaryPort, CreateUserSecundaryPort>();

            return services;
        }
    }
}
