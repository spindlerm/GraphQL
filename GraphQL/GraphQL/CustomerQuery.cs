using System;
using System.Linq;
using HotChocolate;
using GraphQL.Data;
using GraphQL.Models;

namespace GraphQL.GraphQL
{
    public class CustomerQuery
    {
        public IQueryable<Customer> GetCustomers([Service] ApplicationDbContext context) =>
             context.Customers;

    }
}
