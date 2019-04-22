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
using Microsoft.EntityFrameworkCore;
using NSwag.AspNetCore;
using System.Reflection;
using MySkills.Persistance.EntityFramework;
using MySkills.Core.Interfaces.IUnitOfWork;
using MySkills.Core.Interfaces.Services;
using MySkills.Core.Services;
using MySkills.Persistance.EntityFramework.UnitOfWork;


namespace MySkills.API
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
            // services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });


            // Add DbContext using SQL Server Provider
            services.AddDbContext<MySkillsDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MySkillsDatabase")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            // Inject services
            services.AddTransient<INotesService, NotesService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

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

            //loggerFactory.AddLog4Net();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
