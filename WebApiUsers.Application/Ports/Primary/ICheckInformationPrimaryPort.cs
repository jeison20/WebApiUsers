using WebApiUsers.Domain.Dtos;

namespace WebApiUsers.Application.Ports.Primary
{
    public interface ICheckInformationPrimaryPort
    {

        Task<ResponseDto<InformationResponseDto>> HandleCheckInformation(string city);
        Task<ResponseDto<List<SearchHistoryDto>>> HandleCheckRecordsInformation();

    }
}
