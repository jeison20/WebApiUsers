using AutoMapper;
using WebApiUsers.Domain.Dtos;
using WebApiUsers.Domain.POCOs;

namespace WebApiUsers.Domain
{
    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SearchHistory, SearchHistoryDto>();
                cfg.CreateMap<User, CreateUserDto>();
                cfg.CreateMap<User, UpdateUserDto>();
            });

            var mapper = new Mapper(config);
            return mapper;

        }
    }
}
