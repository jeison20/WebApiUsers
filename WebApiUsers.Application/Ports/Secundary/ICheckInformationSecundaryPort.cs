using WebApiUsers.Domain.POCOs;

namespace WebApiUsers.Application.Ports.Secundary
{
    public interface ICheckInformationSecundaryPort
    {
        Task<int> CreateRecord(SearchHistory searchHistory);

        Task<List<SearchHistory>> GetRecords();
    }
}
