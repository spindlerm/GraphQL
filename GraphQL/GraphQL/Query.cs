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
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Customer> GetCustomers([Service] ApplicationDbContext context) =>
            // context.Customers.Include(o=> o.Orders);

              context.Customers;

        [UseFirstOrDefault]
        [UseSelection]
         public  IQueryable<Customer> Customer(int  id, [Service] ApplicationDbContext context)
        {
            var result =  context.Customers
                        .Where(c=> c.CustomerId == id);

             if(result == null)
                throw new CustomerNotFoundException() { CustomerId = id};

            return result;
        }

        [UsePaging]
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Order> GetOrders([Service] ApplicationDbContext context) =>
             context.Orders;


        [UseFirstOrDefault]
        [UseSelection]        
        public  IQueryable<Order> Order(int  id, [Service] ApplicationDbContext context)
        {
            var result =  context.Orders
                        .Where(o=> o.OrderId == id);

             if(result == null)
                throw new OrderNotFoundException() { OrderId = id};

            return result;
        }
    }
}
