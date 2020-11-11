using System;
using GraphQL.Models;

namespace GraphQL.GraphQL
{

    public class CreateCustomerInput
    {
        public string FirstName { get; set; }
        public string GivenName { get; set; }
        public string Bio { get; set; }
        public Customer.Sex_enum Sex { get; set; }
    }
    
}
