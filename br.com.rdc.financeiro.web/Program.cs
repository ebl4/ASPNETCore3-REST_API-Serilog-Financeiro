using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using System;

namespace br.com.rdc.financeiro.web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Elasticsearch(
                    options:
                        new ElasticsearchSinkOptions(
                            new Uri("http://localhost:9200"))
                        {
                            AutoRegisterTemplate = true,
                            AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
                            IndexFormat = "financeiroapi-{0:yyyy.MM}"
                        })
                //.WriteTo.SQLite(Environment.GetEnvironmentVariable("BaseLog"), tableName: "LogsAPIFinanceiro")
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                Log.Information("Inicializando..");
                CreateWebHostBuilder(args).Build().Run();
            } catch (Exception ex)
            {
                Log.Fatal(ex, "Inicialização da aplicação falhou");
            } finally
            {
                Log.CloseAndFlush();
            }
            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseSerilog().UseStartup<Startup>();
    }
}
