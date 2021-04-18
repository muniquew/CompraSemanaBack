using CompraSemana.Core.Data.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace CompraSemana.Core.Data.Repositories
{
    public class ConnectionFactory : IConnectionFactory
    {
        public IDbConnection Connection()
        {
            return new SqlConnection("Server = (localdb)\\mssqllocaldb; Database = Compras; Trusted_Connection = True");
            //Server = (localdb)\\mssqllocaldb; Database = DBLoja; Trusted_Connection = True
            //Database=Compras.db;Data Source=(localdb)\\MSSQLLocalDB;
        }
    }
}
