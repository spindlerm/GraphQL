using System.Threading.Tasks;
using System;
using GraphQL.Data;
using GraphQL.Models;
using HotChocolate;
using HotChocolate.Types;
using AutoMapper;

namespace GraphQL.GraphQL
{
    public class Mutation
    {
        public async Task<CreateCustomerPayload> CreateCustomerAsync(
             CreateCustomerInput input,
             [Service] ApplicationDbContext context)
         {
             var customer = new Customer
             {
                 FirstName = input.FirstName,
                 GivenName = input.GivenName,
                 Bio = input.Bio,
                 Sex = input.Sex
             };

             context.Add(customer);
             await context.SaveChangesAsync();

             return new CreateCustomerPayload(customer);
         }


        public Customer UpdateCustomer(UpdateCustomerInput input, [Service] ApplicationDbContext context,  [Service] IMapper mapper)
        {
            var customerToUpdate = context.Customers.Find(input.CustomerId);

            if(customerToUpdate == null)
                throw new CustomerNotFoundException() { CustomerId = input.CustomerId };



            var model = mapper.Map<UpdateCustomerInput, Customer>(input, customerToUpdate);

             context.Customers.Update(customerToUpdate);
             context.SaveChanges();

   
            return customerToUpdate;
        }

             
        public Customer DeleteCustomer(DeleteCustomerInput input, [Service] ApplicationDbContext context)
        {
            var customerToDelete = context.Customers.Find(input.CustomerId);

            if(customerToDelete == null)
                throw new CustomerNotFoundException() { CustomerId = input.CustomerId };
            
             context.Customers.Remove(customerToDelete);
             context.SaveChanges();

   
            return customerToDelete;
        }
    }
}
