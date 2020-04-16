using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Serilog.RequestLoggingMiddleware;
using E_Commerce2.LogExtensions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace E_Commerce2
{
    public class Program
    {
        private readonly IConfiguration Configuration;
        public Program(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
      //  public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
      //.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
      //.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
      //    .Build();
        public static void Main(string[] args)
        {
           
            Log.Logger = new LoggerConfiguration()
            .WriteTo.File("log.txt")
            
                     .CreateLogger();

            //try
            //{
                Log.Information("Getting the motors running...");

                CreateWebHostBuilder(args).Build().Run();

        
            //}
            //catch (Exception ex)
            //{
            //    Log.Fatal(ex, "Host terminated unexpectedly");
        
            //}
            //finally
            //{
            //    Log.CloseAndFlush();
            //}
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
              WebHost.CreateDefaultBuilder(args)
                  .UseStartup<Startup>();
    }
}
