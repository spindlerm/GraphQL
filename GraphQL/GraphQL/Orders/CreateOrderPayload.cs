using System;
using GraphQL.Models;

namespace GraphQL.GraphQL
{
    public class CreateOrderPayload 
    {
        public CreateOrderPayload(Order order)
         {
             _order = order;
         }

         public Order _order { get; }
    }
}
