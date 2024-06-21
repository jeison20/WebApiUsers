namespace WebApiUsers.Domain.Dtos
{
    public class InformationResponseDto
    {
        public List<NewsDto>? News { get; set; }
        public WeatherDto? Weathers { get; set; }
    }
}
