using Microsoft.Extensions.DependencyInjection;
using WebApiUsers.Domain.Services;

namespace WebApiUsers.Domain
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDomain(
         this IServiceCollection services)
        {

            services.AddScoped<CheckInformationService>();


            return services;
        }
    }
}
