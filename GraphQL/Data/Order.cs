using System;
using System.ComponentModel.DataAnnotations;

namespace GraphQL.Models
{
    public class Order
    {
        public int OrderId { get; set; }

         [StringLength(1000)]
        public string Description { get; set; }
        
        [Required]
      
        public int CustomerId { get; set; }

         [Required]
        public Customer Customer { get; set; }
    }
}
