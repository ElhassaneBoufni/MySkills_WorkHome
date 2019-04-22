using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;
using Microsoft.Extensions.Logging;

namespace MySkills.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var currentEnv = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var configSerilog = new LoggerConfiguration();

            // Configure Serilog per Environment
            if(currentEnv == EnvironmentName.Development)
            {
                configSerilog = configSerilog
                .MinimumLevel.Debug()
                .WriteTo.Debug(restrictedToMinimumLevel: LogEventLevel.Warning)
                .WriteTo.ColoredConsole(
                    LogEventLevel.Verbose,
                    "{NewLine}{Timestamp:HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}");
            }
            else
            {
                configSerilog = configSerilog
               .MinimumLevel.Warning()
               .WriteTo.File(
                    "Logs/log.txt",
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 31,
                    fileSizeLimitBytes: null
                    );
            }

            // Create the logger
            Log.Logger = configSerilog.CreateLogger();

            try
            {
                Log.Information("Starting web host");
                CreateWebHostBuilder(args).Build().Run();
           }
            catch(Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                // Close and flush the log.
                Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseSerilog() // Set serilog as the loggin provider.

              /* For using Serilog config appSettings.{Env}.Json files
                .UseSerilog((hostingContext, config) => {config.ReadFrom.Configuration(hostingContext.Configuration);})
              */
                .UseStartup<Startup>();
    }
}
