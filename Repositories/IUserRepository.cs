using Entities;
using System;
using System.Collections.Generic;
using System.Text;
 
    namespace Repositories
    {
        public interface IUserRepository
        {
             Task<User?> GetById(int id);           
             Task<User?> GetByEmail(string email);
             Task<User?> AddUser(User user);
             Task Update(int id, User userToUpdate);
         
        }
    }
 
