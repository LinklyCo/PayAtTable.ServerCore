using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace PayAtTable.ServerCore
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var hostBuilder = Host.CreateDefaultBuilder(args);


#if SERVICE
                bool isService = true;
                if (Debugger.IsAttached || args.Contains("--console"))
                {
                    isService = false;
                }

                var pathToContentRoot = Directory.GetCurrentDirectory();
                if (isService)
                {
                    var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
                    pathToContentRoot = Path.GetDirectoryName(pathToExe);
                }

                if (isService)
                {
                    hostBuilder.UseWindowsService();
                }
#else
                bool isService = false;
                var pathToContentRoot = Directory.GetCurrentDirectory();
#endif

                // Build default configuration using appsetting.json from same path as exe
                var config = new ConfigurationBuilder()
                    .SetBasePath(pathToContentRoot) // default
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();


                hostBuilder
                    .UseContentRoot(pathToContentRoot)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>()
                            .UseConfiguration(config) 
                            .CaptureStartupErrors(true)
                            .UseSerilog((hostingContext, loggerConfiguration) =>
                            {
                                loggerConfiguration
                                    .ReadFrom.Configuration(hostingContext.Configuration)
                                    .MinimumLevel.Override("Microsoft.AspNetCore", Serilog.Events.LogEventLevel.Warning)
                                    .Enrich.FromLogContext()
                                    .Enrich.WithProperty("ApplicationName", typeof(Program).Assembly.GetName().Name)
                                    .Enrich.WithProperty("Environment", hostingContext.HostingEnvironment);
#if DEBUG
                                loggerConfiguration.Enrich.WithProperty("DebuggerAttached", System.Diagnostics.Debugger.IsAttached);
#endif

                            });
                    })
                    .Build()
                    .Run();
            }
            catch (Exception ex)
            {
                // Create default logger if start-up failed and prevented serilog from loading
                if (Log.Logger == null || Log.Logger.GetType().Name == "SilentLogger")
                {
                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .WriteTo.Console()
                        .CreateLogger();
                }
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
