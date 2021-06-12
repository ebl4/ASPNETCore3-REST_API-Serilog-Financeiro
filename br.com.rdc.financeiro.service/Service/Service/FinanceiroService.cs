using br.com.rdc.financeiro.domain.Financeiro.Model;
using br.com.rdc.financeiro.persistence.Financeiro.Interfaces;
using br.com.rdc.financeiro.service.Financeiro.Interfaces;
using br.com.rdc.financeiro.service.Service.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace br.com.rdc.financeiro.service.Financeiro
{
    public class FinanceiroService : IFinanceiroService
    {
        private readonly ILancamentoRepository _repository;

        public FinanceiroService(ILancamentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> IncluirLancamentos(IList<Lancamento> lancamentos)
        {
            return await _repository.IncluirLancamentos(lancamentos);
        }

        public async Task<(IList<Lancamento>, IDictionary<string, decimal>)> ListarLancamentos()
        {
            var lancamentos = await _repository.ListarLancamentos();
            var totalizador = Totalizador.LancamentoTotalizador(lancamentos);

            return (lancamentos, totalizador);
        }

        public async Task<(IList<Lancamento>, IDictionary<string, decimal>)> ListarLancamentos(string data)
        {
            var lancamentos = await _repository.ListarLancamentos(data);
            var totalizador = Totalizador.LancamentoTotalizador(lancamentos);

            return (lancamentos, totalizador);
        }
    }
}
