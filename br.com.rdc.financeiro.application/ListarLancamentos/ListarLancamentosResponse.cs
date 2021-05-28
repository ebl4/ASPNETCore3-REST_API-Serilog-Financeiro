using br.com.rdc.financeiro.application.DTO;
using System.Collections.Generic;

namespace br.com.rdc.financeiro.application.IncluirLancamentos
{
    public class ListarLancamentosResponse
    {
        public IDictionary<string, decimal> Totalizadores { get; set; }
        public IList<LancamentoDTO> Lancamentos { get; set; }
    }
}
