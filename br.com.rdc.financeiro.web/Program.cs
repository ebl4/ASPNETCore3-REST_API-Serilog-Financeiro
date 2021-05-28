using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

namespace br.com.rdc.financeiro.web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.SQLite(Environment.GetEnvironmentVariable("BaseLog"), tableName: "LogsAPIFinanceiro")
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                Log.Information("Inicializando..");
                CreateWebHostBuilder(args).Build().Run();
            } catch (Exception ex)
            {
                Log.Fatal(ex, "Inicializa��o da aplica��o falhou");
            } finally
            {
                Log.CloseAndFlush();
            }
            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseSerilog().UseStartup<Startup>();
    }
}
