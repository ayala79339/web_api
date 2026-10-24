using System.ComponentModel.DataAnnotations;

namespace web_api
{
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
    public class UsersLog
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        

    }
}
