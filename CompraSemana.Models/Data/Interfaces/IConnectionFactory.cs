using System.Data;

namespace CompraSemana.Core.Data.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection Connection();
    }
}
