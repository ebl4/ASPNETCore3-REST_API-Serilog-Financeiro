using br.com.rdc.financeiro.persistence.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace br.com.rdc.financeiro.test.Helpers
{
    public class TestSqlConnectionFactory : IConnectionFactory
    {
        private string _CONNECTION_STRING;

        public TestSqlConnectionFactory(string CONNECTION_STRING)
        {
            _CONNECTION_STRING = CONNECTION_STRING;
        }
        public IDbConnection Connection()
        {
            return new SqlConnection(_CONNECTION_STRING);
        }
    }
}
