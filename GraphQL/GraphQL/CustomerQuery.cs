using System;
using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using GraphQL.Data;
using GraphQL.Models;

namespace GraphQL.GraphQL
{
    public class CustomerQuery
    {
        [UsePaging]
        public IQueryable<Customer> GetCustomers([Service] ApplicationDbContext context) =>
             context.Customers;

    }
}
