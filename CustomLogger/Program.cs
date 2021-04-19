using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomLogger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
           
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });

        static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureLogging(builder =>
            builder.ClearProviders()
                .AddProvider(
                    new ColorConsoleLoggerProvider(
                        new ColorConsoleLoggerConfiguration
                        {
                            LogLevel = LogLevel.Error,
                            Color = ConsoleColor.Red
                        }))
                .AddColorConsoleLogger()
                .AddColorConsoleLogger(configuration =>
                {
                    configuration.LogLevel = LogLevel.Information;
                    configuration.Color = ConsoleColor.DarkMagenta;
                }));
    }
}