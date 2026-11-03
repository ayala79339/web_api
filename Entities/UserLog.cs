using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
   public class UserLog
    { 
            [Required]
            public string Email { get; set; }
            [Required]
            public string Password { get; set; }
 
    }
}

