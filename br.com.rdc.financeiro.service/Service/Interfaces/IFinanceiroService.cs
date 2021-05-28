using br.com.rdc.financeiro.application.DTO;
using br.com.rdc.financeiro.domain.Financeiro.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace br.com.rdc.financeiro.service.Financeiro.Interfaces
{
    public interface IFinanceiroService
    {
        Task<int> IncluirLancamentos(IList<Lancamento> lancamentos);
        Task<(IList<Lancamento>, IDictionary<string, decimal>)> ListarLancamentos(string data);
    }
}
