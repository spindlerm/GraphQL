using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GraphQL.Models;

namespace GraphQL.Data
{
    public class ApplicationDbContext : DbContext
     {
         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
         {
         }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            modelBuilder.Entity<Customer>()
                .HasData(
                    new Customer
                    {
                        CustomerId = 1,
                        FirstName = "John",
                        GivenName = "Doe",
                        Sex = Customer.Sex_enum.Male,
                        Bio = "This is John's Bio - Yay"
                    },
                    new Customer
                    {
                        CustomerId = 2,
                        FirstName = "Jane",
                        GivenName = "Doe",
                        Sex = Customer.Sex_enum.Female
                    }
        );
    }

         public DbSet<Customer> Customers { get; set; }
     }
}
