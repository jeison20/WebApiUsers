﻿using Microsoft.Extensions.Configuration;
using WebApiUsers.Domain.Interfaces;

namespace WebApiUsers.Services.Services
{
    public class WeatherService : ICheckWeatherInformation
    {
        private readonly IConfiguration configuration;
        public WeatherService(IConfiguration Configuration)
        {

            configuration = Configuration;

        }
        public string GetWeatherInformation(string city)
        {
            try
            {
                string? urlService = configuration["ServiceWeatherUrl"]?.ToString();
                string? password = configuration["ServiceWeatherPassword"]?.ToString();

                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"{urlService}={city}&apikey={password}"),
                    Headers =
                {
                    { "accept", "application/json" },
                },
                };
                using var response = client.SendAsync(request).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();
                var body = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                return body;
            }
            catch (Exception)
            {
                return string.Empty;
            }

        }
    }
}
