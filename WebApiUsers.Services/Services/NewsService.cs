using Microsoft.Extensions.Configuration;
using WebApiUsers.Domain.Interfaces;

namespace WebApiUsers.Services.Services
{
    public class NewsService : ICheckNewsInformation
    {
        private readonly IConfiguration configuration;
        public NewsService(IConfiguration Configuration)
        {

            configuration = Configuration;

        }
        public string GetNewsInformation(string city)
        {

            string? urlService = configuration["ServiceNewsUrl"]?.ToString();
            string? password = configuration["ServiceNewsPassword"]?.ToString();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{urlService}{password}&qInTitle={city}"),
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
    }
}
