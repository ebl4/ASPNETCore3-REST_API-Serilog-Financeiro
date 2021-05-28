using AutoMapper;
using br.com.rdc.financeiro.application.DTO;
using br.com.rdc.financeiro.application.IncluirLancamentos;
using br.com.rdc.financeiro.domain.Financeiro.Model;
using br.com.rdc.financeiro.persistence.Core.Helpers;
using br.com.rdc.financeiro.persistence.Core.Interfaces;
using br.com.rdc.financeiro.persistence.Financeiro.Interfaces;
using br.com.rdc.financeiro.persistence.Financeiro.Repositories;
using br.com.rdc.financeiro.service.Financeiro;
using br.com.rdc.financeiro.service.Financeiro.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace br.com.rdc.financeiro.web
{
    public class Startup
    {
        public Startup()
        {
            Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IFinanceiroService, FinanceiroService>();
            services.AddSingleton<ILancamentoRepository, LancamentoRepository>();
            services.AddSingleton<IConnectionFactory, DefaultSqlConnectionFactory>();

            services.AddControllers();
            AutoMapperConfig(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AutoMapperConfig(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LancamentoDTO, Lancamento>();
                cfg.CreateMap<Lancamento, LancamentoDTO>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
