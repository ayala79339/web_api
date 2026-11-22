using Entities; 
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly AppDbContext appContext;

        public UserRepository(AppDbContext appContext)
        {
            this.appContext = appContext;
        }
        public async Task<User?> AddUser(User user)
        {
             
            await appContext.Users.AddAsync(user);
            await appContext.SaveChangesAsync();
            return user;
        }
        public async Task<User?> GetByEmail(string email)
        { 
            return await appContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public Task<User?> GetById(int id)
        {
            return appContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task Update(int id,User userToUpdate)
        {
            userToUpdate.Id=id;             
            appContext.Users.Update(userToUpdate);
            await appContext.SaveChangesAsync();
        }
    }
}
