using br.com.rdc.financeiro.persistence.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace br.com.rdc.financeiro.persistence.Core.Helpers
{
    public class DefaultSqlConnectionFactory : IConnectionFactory
    {
        private string _CONNECTION_STRING;

        public DefaultSqlConnectionFactory(IConfiguration configuration)
        {
            _CONNECTION_STRING = configuration["ConnectionStrings:AlternativeConnection"];
        }
        public IDbConnection Connection()
        {
            return new SqlConnection(_CONNECTION_STRING);
        }

    }
}
