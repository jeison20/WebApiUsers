using Microsoft.Extensions.DependencyInjection;
using WebApiUsers.Domain.Interfaces;
using WebApiUsers.Services.Services;

namespace WebApiUsers.Services
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddServices(
           this IServiceCollection services)
        {
            services.AddScoped<ICheckNewsInformation, NewsService>();
            services.AddScoped<ICheckWeatherInformation, WeatherService>();


            return services;
        }
    }
}
