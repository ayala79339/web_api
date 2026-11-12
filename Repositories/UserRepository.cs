using Entities;
using Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;


namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly string FilePath = "Users.txt";
 
        public User AddUser(User user)
        {   int numberOfUsers = System.IO.File.ReadLines(FilePath).Count();
            user.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(FilePath, userJson + Environment.NewLine);

            return user;
        }
        public User GetByEmail(string email)
        {
            using (StreamReader reader = System.IO.File.OpenText(FilePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Email == email)
                        return user;
                }
            }
            return null;

        }

        public  User GetById(int id)
        {  using (StreamReader reader = System.IO.File.OpenText(FilePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Id == id)
                        return  user;
                }
            }
            return null;

        }

        public User Update(User userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(FilePath))

            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User curruser = JsonSerializer.Deserialize<User>(currentUserInFile);

                    if (curruser.Id == userToUpdate.Id)
                    {
                        textToReplace = currentUserInFile;
                        break;
                    }

                }
            }
            if (textToReplace != string.Empty)
            {
                userToUpdate.Id = userToUpdate.Id;
                string text = System.IO.File.ReadAllText(FilePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));

                System.IO.File.WriteAllText(FilePath, text);
            }
             return  userToUpdate;
        }
    }
}
