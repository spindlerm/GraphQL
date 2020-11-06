using System.Threading.Tasks;
using GraphQL.Data;
using GraphQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQL.GraphQL
{
    public class CustomerMutation
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
    }

    

   
}
