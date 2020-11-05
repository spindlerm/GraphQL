using System.ComponentModel.DataAnnotations;

namespace GraphQL.Models
{
    public class Customer
    {
        public enum Sex_enum
        {
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
    }
}