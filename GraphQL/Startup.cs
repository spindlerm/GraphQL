using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using GraphQL.Data;
using GraphQL.GraphQL;
using GraphQL.Models;


namespace GraphQL
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql("Server=192.168.1.253;Database=graphqldemo;User Id=dbuser1;Password=dbuser1;Port=5432;"));
        
            services.AddGraphQLServer()
            .AddType<Customer>()
            .AddQueryType<CustomerQuery>()
            .AddMutationType<CustomerMutation>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
         public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
         {
             if (env.IsDevelopment())
             {
                 app.UseDeveloperExceptionPage();
             }

             app.UseRouting();

             app.UseEndpoints(endpoints =>
             {
                 endpoints.MapGraphQL();
             });
         }
    }
}
