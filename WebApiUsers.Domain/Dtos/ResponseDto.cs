namespace WebApiUsers.Domain.Dtos
{
    public class ResponseDto<T>
    {
        public string? Response { get; set; }
        public string? Message { get; set; }
        public T Data { get; set; }

    }
}
