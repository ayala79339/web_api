using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Id { get; set; }


    }
}
