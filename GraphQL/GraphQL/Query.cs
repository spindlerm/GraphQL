using System;
using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using GraphQL.Data;
using GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.GraphQL
{
    public class Query
    {
        [UsePaging]
        public IQueryable<Customer> GetCustomers([Service] ApplicationDbContext context) =>
             context.Customers.Include(o=> o.Orders);


         public  Customer Customer(int  id, [Service] ApplicationDbContext context)
        {
            var result =  context.Customers
                        .Where(c=> c.CustomerId == id)
                        .Include(c => c.Orders)
                        .FirstOrDefault();

             if(result == null)
                throw new CustomerNotFoundException() { CustomerId = id};

            return result;
        }

        [UsePaging]
        public IQueryable<Order> GetOrders([Service] ApplicationDbContext context) =>
             context.Orders.Include(o=> o.Customer);


        public  Order Order(int  id, [Service] ApplicationDbContext context)
        {
            var result =  context.Orders
                        .Where(o=> o.OrderId == id)
                        .Include(o => o.Customer)
                        .FirstOrDefault();

             if(result == null)
                throw new OrderNotFoundException() { OrderId = id};

            return result;
        }
    }
}
