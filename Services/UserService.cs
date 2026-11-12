using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Repositories;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo) => _repo = repo;

        public User Login(UserLog log)
        {
            var user = _repo.GetByEmail(log.Email);
            return user;
        }
        public User GetUserById(int id)
        {
            var user = _repo.GetById(id);
            return user;
        }
        public User UpdateUser(User user)
        {
            var updatedUser = _repo.Update(user);
            return updatedUser;
        }
        public User AddUser(User user)
        {
            var addedUser = _repo.AddUser(user);
            return addedUser;
        }
    }
}
