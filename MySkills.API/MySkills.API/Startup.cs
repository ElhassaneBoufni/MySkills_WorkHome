using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
//using MySkills.Application.Customers.Commands.CreateCustomer;

//using MySkills.Application.Products.Queries.GetProduct;

using MySkills.Common;

using MySkills.Persistence;
using NSwag.AspNetCore;
using System.Reflection;

using MySkills.Persistence.Contracts.UnitOfWork;
using MySkills.Persistence.UnitOfWork;
using MySkills.DomainModel;
using MySkills.BL.Contracts;
using MySkills.BL;

namespace MySkills.Domain
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // Add DbContext using SQL Server Provider
            //services.AddDbContext<MySkillsDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("MySkillsDatabase")));
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            // Inject BL 
           
            services.AddScoped<IFaq, BLFaq>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // the API�s can be accessed from any origin globally
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // inject CORS into a container
            app.UseCors(options => options.AllowAnyOrigin());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
