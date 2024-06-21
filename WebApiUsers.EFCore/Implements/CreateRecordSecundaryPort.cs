using WebApiUsers.Application.Ports.Secundary;
using WebApiUsers.Domain.POCOs;
using WebApiUsers.EFCore.DataContext;

namespace WebApiUsers.EFCore.Implements
{
    public class CreateRecordSecundaryPort : ICheckInformationSecundaryPort
    {
        readonly WebApiContext Context;

        public CreateRecordSecundaryPort(WebApiContext context)
        {
            Context = context;
        }

        public async Task<int> CreateRecord(SearchHistory searchHistory)
        {
            Context.Add(searchHistory);
            return Context.SaveChanges();
        }

        public async Task<List<SearchHistory>> GetRecords()
        {
            var lsDataRecords = Context.SearchHistories.OrderByDescending(c => c.Id);


            return lsDataRecords.ToList();
        }
    }
}
