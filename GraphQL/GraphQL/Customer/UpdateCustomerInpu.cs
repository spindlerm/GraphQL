using System;
using GraphQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQL.GraphQL
{

    public class UpdateCustomerInput
    {
        public int CustomerId  { get; set; }
        public string? FirstName { get; set; }
        public string? GivenName { get; set; }
        public string? Bio { get; set; }
        public Customer.Sex_enum? Sex { get; set; }
    }
    
}