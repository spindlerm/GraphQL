using System;
using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using GraphQL.Data;
using GraphQL.Models;

namespace GraphQL.GraphQL
{
    public class OrderQuery
    {
        [UsePaging]
        public IQueryable<Order> GetOrders([Service] ApplicationDbContext context) =>
             context.Orders;

        public  Order OrdersById(int  id, [Service] ApplicationDbContext context)
        {
            var result =  context.Orders.FirstOrDefault<Order>(x => x.OrderId ==id);
             if(result == null)
                throw new OrderNotFoundException() { OrderId = id};


            return result;
        }
    }
}
