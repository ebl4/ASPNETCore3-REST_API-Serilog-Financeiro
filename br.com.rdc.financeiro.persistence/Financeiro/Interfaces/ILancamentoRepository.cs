using br.com.rdc.financeiro.domain.Financeiro.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace br.com.rdc.financeiro.persistence.Financeiro.Interfaces
{
    public interface ILancamentoRepository
    {
        Task<int> IncluirLancamentos(IList<Lancamento> lancamentos);
        Task<IList<Lancamento>> ListarLancamentos(string data);
        Task<IList<Lancamento>> ListarLancamentos();
    }
}
