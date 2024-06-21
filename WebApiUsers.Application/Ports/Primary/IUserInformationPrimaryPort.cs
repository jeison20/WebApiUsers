using WebApiUsers.Domain.Dtos;
using WebApiUsers.Domain.POCOs;

namespace WebApiUsers.Application.Ports.Primary
{
    public interface IUserInformationPrimaryPort
    {
        Task<ResponseDto<UserInformationDto>> HandleGetUserByIdAsync(int id);
        Task<ResponseDto<List<UserInformationDto>>> HandleGetUsersAsync();
        Task<ResponseDto<UserInformationDto>> HandleAddUserAsync(CreateUserDto user);
        Task<ResponseDto<UserInformationDto>> HandleUpdateUserAsync(UpdateUserDto user);
        Task<ResponseDto<UserInformationDto>> HandleDeleteUserAsync(int id);
    }
}
