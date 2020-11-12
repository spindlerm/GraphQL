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
using AutoMapper;


namespace GraphQL
{
    public class MappingProfile : Profile {
     public MappingProfile() {
         // Add as many of these lines as you need to map your objects
         CreateMap<UpdateCustomerInput, Customer>()
            .ForMember(dest => dest.Sex, opt => opt.MapFrom((source, dest) =>  source.Sex ?? dest.Sex))
            .ForMember(dest => dest.Orders, act => act.Ignore())
            //.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            .ForAllMembers(opts2 => opts2.Condition((src, dest, srcMember) =>
            {
                return srcMember != null;
            }));
     }
 }
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql("Server=192.168.1.253;Database=graphqldemo;User Id=dbuser1;Password=dbuser1;Port=5432;"));
        
            services.AddGraphQLServer()
            .AddType<Customer>()
            .AddType<Order>()
            .AddQueryType<CustomerQuery>()
            .AddMutationType<CustomerMutation>();

            services.AddErrorFilter<CustomerNotFoundExceptionFilter>();

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            var executionPlan = mapperConfig.BuildExecutionPlan(typeof(UpdateCustomerInput), typeof(Customer));

            mapperConfig.AssertConfigurationIsValid();

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
