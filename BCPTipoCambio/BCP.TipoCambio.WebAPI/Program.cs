using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.IO;
using System.Net.Http;
using System.Security.Claims;
using BCP.TipoCambio.DependencyResolver;
using BCP.TipoCambio.WebAPI.Infrastructure;
using BCP.TipoCambio.WebAPI.Providers;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using BCP.TipoCambio.WebAPI.Config;
using BCP.TipoCambio.Common.Config;
using Serilog;
using Autofac.Extensions.DependencyInjection;

namespace BCP.TipoCambio.WebAPI
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                    .Build();

        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                        .ReadFrom
                        .Configuration(Configuration)
                        .Enrich.FromLogContext()
                        .CreateLogger();
            try
            {
                Log.Information("Iniciando el servidor...");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "El servidor ha cerrado por error");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseConfiguration(Configuration);
                })
                .UseSerilog();

    }
}
