using br.com.rdc.financeiro.domain.Financeiro.Model;
using br.com.rdc.financeiro.persistence.Core.Interfaces;
using br.com.rdc.financeiro.persistence.Financeiro.Interfaces;
using br.com.rdc.financeiro.persistence.Financeiro.Repositories;
using br.com.rdc.financeiro.service.Financeiro;
using br.com.rdc.financeiro.service.Financeiro.Interfaces;
using br.com.rdc.financeiro.test.Helpers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Xunit;

namespace br.com.rdc.financeiro.test
{
    public class LancamentoTest
    {
        private static IConnectionFactory _connectionFactory = new TestSqlConnectionFactory("Server=localhost\\SQLEXPRESS;Database=FINANCIAMENTO;Trusted_Connection=True;");
        private static ILancamentoRepository _lancamentoRepository = new LancamentoRepository(_connectionFactory);
        private static IFinanceiroService _financeiroService = new FinanceiroService(_lancamentoRepository);

        [Fact]
        public async void ListarLancamentosTest_Ok()
        {
            var result = await _financeiroService.ListarLancamentos("2020-12");

        }

        [Fact]
        public async void IncluirLancamentosTest_Ok()
        {
            var lancamentos = new List<Lancamento>();
            lancamentos.Add(new Lancamento(DateTime.Now.ToString(), 1000, "Décimo terceiro RDC", "Itau", "c"));
            lancamentos.Add(new Lancamento(DateTime.Now.ToString(), 2000, "Salario RDC", "Itau", "c"));
            lancamentos.Add(new Lancamento(DateTime.Now.ToString(), 50.0M, "Tarifa da conta", "Itau", "d"));

            var result = await _financeiroService.IncluirLancamentos(lancamentos);

            Assert.Equal(3, result);
        }

        [Fact]
        public async void IncluirLancamentosTest_Nok()
        {
            var lancamentos = new List<Lancamento>();
            lancamentos.Add(new Lancamento(DateTime.Now.ToString(), -1000, "Décimo terceiro RDC", "Itau", "c"));

            var result = await _financeiroService.IncluirLancamentos(lancamentos);

            Assert.NotEqual(1, result);
        }

        [Fact]
        public async void IncluirLancamentosTest_Nok2()
        {
            var lancamentos = new List<Lancamento>();
            lancamentos.Add(new Lancamento(DateTime.Now.ToString(), 1000, "Décimo terceiro RDC", "Itau", "t"));

            var result = await _financeiroService.IncluirLancamentos(lancamentos);

            Assert.NotEqual(1, result);
        }
    }
}
