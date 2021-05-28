using System.Data;

namespace br.com.rdc.financeiro.persistence.Core.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection Connection();
    }
}
