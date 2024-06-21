namespace WebApiUsers.Domain.Dtos
{
    public class NewsDataDto
    {

        public string? Status { get; set; }
        public int? TotalResults { get; set; }
        public List<NewsDto>? Results { get; set; }

    }
}
