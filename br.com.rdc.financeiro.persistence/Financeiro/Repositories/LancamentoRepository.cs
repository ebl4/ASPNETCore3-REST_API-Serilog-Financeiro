using br.com.rdc.financeiro.domain.Financeiro.Model;
using br.com.rdc.financeiro.persistence.Core.Interfaces;
using br.com.rdc.financeiro.persistence.Financeiro.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace br.com.rdc.financeiro.persistence.Financeiro.Repositories
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly IConnectionFactory _connection;

        public LancamentoRepository(IConnectionFactory connection)
        {
            _connection = connection;
        }

        public async Task<int> IncluirLancamentos(IList<Lancamento> lancamentos)
        {
            int result = 0;
            string sql = "INSERT INTO TB_LANCAMENTO (Data, Valor, Descricao, Conta, Tipo) VALUES (CONVERT(DATETIME, @Data, 101), @Valor, @Descricao, @Conta, @Tipo)";

            using(var connectionDb = _connection.Connection())
            {
                result = await connectionDb.ExecuteAsync(sql, lancamentos);
            }

            return result;
        }

        public async Task<IList<Lancamento>> ListarLancamentos()
        {
            string sql = "SELECT * FROM TB_LANCAMENTO";

            IList<Lancamento> listLancamentos = new List<Lancamento>();

            using (var connectionDb = _connection.Connection())
            {
                connectionDb.Open();

                var result = await connectionDb.QueryAsync<dynamic>(sql);

                foreach (var item in result.ToList())
                {
                    var lancamento = new Lancamento(item.Id, (string)Convert.ToString(item.Data), (decimal)item.Valor, (string)item.Descricao, (string)item.Conta, (string)item.Tipo);
                    listLancamentos.Add(lancamento);
                }
            }

            return listLancamentos.ToList();
        }

        public async Task<IList<Lancamento>> ListarLancamentos(string data)
        {
            string sql = "SELECT * FROM TB_LANCAMENTO WHERE FORMAT(DATA, 'yyyy-MM')=@Data";

            IList<Lancamento> listLancamentos = new List<Lancamento>();

            using(var connectionDb = _connection.Connection())
            {
                connectionDb.Open();

                var result = await connectionDb.QueryAsync<dynamic>(sql, new { Data = data});

                foreach(var item in result.ToList())
                {
                    var lancamento = new Lancamento(item.Id, (string) Convert.ToString(item.Data), (decimal)item.Valor, (string)item.Descricao, (string)item.Conta, (string)item.Tipo);
                    listLancamentos.Add(lancamento);
                }
            }

            return listLancamentos.ToList();
        }
    }
}
