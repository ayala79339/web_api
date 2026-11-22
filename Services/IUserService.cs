using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IUserService
    {
       Task<User?> Login(UserLog log);
        Task<User?> GetUserById(int id);
        Task UpdateUser(int id,User user);
        Task<User?> AddUser(User user);
    }
}
