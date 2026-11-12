using Entities;
using System;
using System.Collections.Generic;
using System.Text;
 
    namespace Repositories
    {
        public interface IUserRepository
        {
             User GetById(int id);           
             User GetByEmail(string email);
             User AddUser(User user);
             User Update(User user);
         
        }
    }
 
