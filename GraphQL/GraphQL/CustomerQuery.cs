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

         public  Customer CustomerById(int  id, [Service] ApplicationDbContext context)
        {
            var result =  context.Customers.FirstOrDefault<Customer>(x => x.CustomerId ==id);
             if(result == null)
                throw new CustomerNotFoundException() { CustomerId = id};


            return result;
        }
    }
}
