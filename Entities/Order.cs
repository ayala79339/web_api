using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Order
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public decimal TotalSum { get; set; }
        [Required]        
        public DateTime OrderDate { get; set; } = DateTime.Now;
        [Key]
        public int Id { get; set; }
    }
}
