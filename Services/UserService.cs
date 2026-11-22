
using Entities;
using Repositories;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo) => _repo = repo;

        public async Task<User?> Login(UserLog log)
        {
            var user = await _repo.GetByEmail(log.Email);
            return user;
        }
        public async Task<User?> GetUserById(int id)
        {
            var user = await _repo.GetById(id);
            return user;
        }
        public async Task UpdateUser(int id,User user)
        {
            await _repo.Update(id,user);             
        }
        public async Task<User?> AddUser(User user)
        {
            var addedUser = await _repo.AddUser(user);
            return addedUser;
        }
    }
}
