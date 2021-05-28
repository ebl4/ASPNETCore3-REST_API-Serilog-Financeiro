using br.com.rdc.financeiro.domain.Financeiro.Model;
using System.Collections.Generic;
using System.Linq;

namespace br.com.rdc.financeiro.service.Service.Helpers
{
    public class Totalizador
    {
        public static IDictionary<string, decimal> LancamentoTotalizador(IList<Lancamento> lancamentos)
        {
            var result = new Dictionary<string, decimal>();
            foreach(var item in lancamentos)
            {

                if (result.ContainsKey(item.Conta))
                {
                    if (item.Tipo == "c") result[item.Conta] += item.Valor;
                    else if (item.Tipo == "d") result[item.Conta] -= item.Valor;
                }
                else result.Add(item.Conta, item.Valor);
            }

            result.Add("Saldo", result.Values.Sum());

            return result;
        }
    }
}
