using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class OrderItem
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]      
        public int Quantity { get; set; }
        [Key]
        public int Id { get; set; }
    }
}
