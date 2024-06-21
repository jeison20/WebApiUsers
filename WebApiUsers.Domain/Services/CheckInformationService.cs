using Newtonsoft.Json;
using WebApiUsers.Domain.Dtos;
using WebApiUsers.Domain.Interfaces;
using WebApiUsers.Domain.POCOs;

namespace WebApiUsers.Domain.Services
{
    public class CheckInformationService
    {
        private readonly ICheckNewsInformation checkNewsInformation;
        private readonly ICheckWeatherInformation checkWeatherInformation;
        public CheckInformationService(ICheckNewsInformation CheckNewsInformation, ICheckWeatherInformation CheckWeatherInformation)
        {

            checkNewsInformation = CheckNewsInformation;
            checkWeatherInformation = CheckWeatherInformation;
        }

        public InformationResponseDto GetCheckInformation(string city)
        {

            string responseNews = checkNewsInformation.GetNewsInformation(city);
            string responseWeather = checkWeatherInformation.GetWeatherInformation(city);
            WeatherDataDto weatherData = JsonConvert.DeserializeObject<WeatherDataDto>(responseWeather);
            NewsDataDto NewsData = JsonConvert.DeserializeObject<NewsDataDto>(responseNews);

            return new InformationResponseDto { News = NewsData?.Results, Weathers = weatherData?.Data?.Values };


        }

        public List<SearchHistoryDto> GetCheckRecordsInformation(List<SearchHistory> searchHistories)
        {

            var ultimosRegistros = searchHistories
            .GroupBy(r => r.City)
            .Select(g => g.OrderByDescending(r => r.Date).First()).ToList();


            var mapper = MapperConfig.InitializeAutomapper();
            List<SearchHistoryDto> lsSearchHistoriesDto = mapper.Map<List<SearchHistoryDto>>(ultimosRegistros);


            return lsSearchHistoriesDto.Distinct().ToList();
        }

    }
}
