using System.Text.Json.Serialization;

namespace WebApiUsers.Domain.Dtos
{
    public class NewsDto
    {
        public string? Author { get; set; }
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Link { get; set; }

        [JsonPropertyName("image_url")]
        public string? UrlToImage { get; set; }

        [JsonPropertyName("pubDate")]
        public DateTime? PublishedAt { get; set; }

        public string? Content { get; set; }
    }
}
