using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Category
    {
        [Required]
        public string CategoryName { get; set; }
        [Key]
        public int Id { get; set; }
    }
}
