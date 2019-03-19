using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MySkills.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;

namespace MySkills.WebUI
{
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         var host = CreateWebHostBuilder(args).Build();

    //         // using (var scope = host.Services.CreateScope())
    //         // {
    //         //     try
    //         //     {
    //         //         var context = scope.ServiceProvider.GetService<MySkillsDbContext>();
    //         //         context.Database.Migrate();

    //         //         MySkillsInitializer.Initialize(context);
    //         //     }
    //         //     catch (Exception ex)
    //         //     {
    //         //         var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    //         //         logger.LogError(ex, "An error occurred while migrating or initializing the database.");
    //         //     }
    //         // }

    //         host.Run();
    //     }

    //     public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    //         new WebHostBuilder()
    //             .UseKestrel()
    //             .UseContentRoot(Directory.GetCurrentDirectory())
    //             .ConfigureAppConfiguration((hostingContext, config) =>
    //             {
    //                 var env = hostingContext.HostingEnvironment;
    //                 config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    //                       .AddJsonFile($"appsettings.Local.json", optional: true, reloadOnChange: true)
    //                       .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
    //                 config.AddEnvironmentVariables();
    //             })
    //             .ConfigureLogging((hostingContext, logging) =>
    //             {
    //                 logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
    //                 logging.AddConsole();
    //                 logging.AddDebug();
    //             })
    //             .UseStartup<Startup>();
    // }
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }

}
