using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiUsers.Domain.POCOs;

namespace WebApiUsers.Application.Ports.Secundary
{
    public interface IUserInformationSecundaryPort
    {
        Task<int> CreateUser(User user);
        Task<List<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task<User> UpdateUser(User user);
        Task DeleteUser(int id);
    }
}
