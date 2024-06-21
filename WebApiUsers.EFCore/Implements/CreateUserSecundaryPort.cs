using Microsoft.EntityFrameworkCore;
using WebApiUsers.Application.Ports.Secundary;
using WebApiUsers.Domain.POCOs;
using WebApiUsers.EFCore.DataContext;

namespace WebApiUsers.EFCore.Implements
{
    public class CreateUserSecundaryPort: IUserInformationSecundaryPort
    {
        readonly WebApiContext Context;

        public CreateUserSecundaryPort(WebApiContext context)
        {
            Context = context;
        }

        public async Task<int> CreateUser(User user)
        {
            await Context.AddAsync(user);
            return Context.SaveChanges();
        }

        public async Task<List<User>> GetUsers()
        {
            var lsDataRecords = Context.Users.OrderByDescending(c => c.Id);
            return await lsDataRecords.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            var result = await Context.Users.FindAsync(id);
            return result;
        }

        public async Task<User> UpdateUser(User user)
        {
            Context.Users.Update(user);
            Context.SaveChanges();
            return user;
        }

        public async Task DeleteUser(int id)
        {
            var user = await Context.Users.FindAsync(id);
            Context.Users.Remove(user);
            await Context.SaveChangesAsync();
        }
    }
}
