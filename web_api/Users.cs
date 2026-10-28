using System.ComponentModel.DataAnnotations;

namespace web_api
{
    //A class for one user is called User (singular), and the file is named after it: User.cs.
    //In C#, public properties are written in PascalCase without underscores (FirstName, LastName).
    //If you rename them, Users.txt still has the old names (First_name, Last_name), so these values
    //won't be read: delete the old lines and register the users again
    public class Users
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string First_name { get; set; }
        [Required]
        public string Last_name { get; set; }
        [Required]
        public int Id { get; set; }

    }
    //A clearer name is LoginUser, in its own file LoginUser.cs
    public class UsersLog
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        

    }
}
