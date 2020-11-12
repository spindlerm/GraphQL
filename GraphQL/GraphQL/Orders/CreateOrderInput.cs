using System;

namespace GraphQL.GraphQL
{
    public class CreateOrderInput
    {
        public string Description { get; set; }
        public int CustomerId { get; set; }
    }
}
