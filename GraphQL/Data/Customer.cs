using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace GraphQL.Models
{
    public class Customer
    {
        public enum Sex_enum
        {
            None,
            Male,
            Female
        }
        
        public int CustomerId { get; set; }

        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string GivenName { get; set; }

        [Required]
        public Sex_enum Sex { get; set; }

         [StringLength(1000)]
         public string Bio { get; set; }

         public virtual ICollection<Order> Orders { get; set; }

    }
}