using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging; 
using System.IO;
using BonsaiHealthWebApi.HealthChecks;

namespace BonsaiHealthWebApi
{
    public class Program
    {
        private static readonly Dictionary<string, Type> _healthcheckScenarios;

        static Program()
        {
            _healthcheckScenarios = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase)
            {
                { "basic", typeof(BasicStartup) },
                { "db", typeof(DbHealthStartup) },
                { "dbcontext", typeof(DbContextHealthStartup) },
                { "liveness", typeof(LivenessProbeStartup) },
                { "writer", typeof(CustomWriterStartup) },
                { "port", typeof(ManagementPortStartup) },

            };
        }
        public static void Main(string[] args)
        {
            BuildHost(args).Run();
        }

        public static IHost BuildHost(string[] args)
        {
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });

            var config1 = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json")
                  .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                  .AddCommandLine(args)
                  .Build();


            var scenario = config1["scenario"] ?? "basic";

            if (!_healthcheckScenarios.TryGetValue(scenario, out var startupType))
            {
                startupType = typeof(BasicStartup);
            }

            return new HostBuilder()
                .ConfigureAppConfiguration(config =>
                {
                    config.AddConfiguration(config1);
                })
                .ConfigureLogging(builder =>
                {
                    builder.SetMinimumLevel(LogLevel.Trace);
                    builder.AddConfiguration(config1);
                    builder.AddConsole();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel();
                    webBuilder.UseStartup(startupType);
                })
                .Build();
        }
        
    }
}
