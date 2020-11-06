using System;
using GraphQL.Models;

namespace GraphQL.GraphQL
{
     public class CreateCustomerPayload
     {
         public CreateCustomerPayload(Customer customer)
         {
             _customer = customer;
         }

         public Customer _customer { get; }
     }
}
