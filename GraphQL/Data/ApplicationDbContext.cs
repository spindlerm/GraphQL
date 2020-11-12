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
                .HasMany(c => c.Orders)
                .WithOne(e => e.Customer);
            
           modelBuilder.Entity<Order>()
                .HasOne(c => c.Customer)
                .WithMany(e => e.Orders);
        
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

        modelBuilder.Entity<Order>()
                    .HasData(
                        new Order
                        {
                            OrderId = 1,
                            Description = "A test order",
                            CustomerId = 1
                        },
                        new Order
                        {
                            OrderId = 2,
                            CustomerId = 2,
                            Description = "A second test order"
                        }
            );
    }

         public DbSet<Customer> Customers { get; set; }
         public DbSet<Order> Orders { get; set; }
     }
}
