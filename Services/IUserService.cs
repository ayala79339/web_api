using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IUserService
    {
        User Login(UserLog log);
        User GetUserById(int id);
        User UpdateUser(User user);
        User AddUser(User user);
    }
}
