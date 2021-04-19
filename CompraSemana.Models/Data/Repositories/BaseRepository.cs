using CompraSemana.Core.Data.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraSemana.Core.Data.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly IConnectionFactory _connection;

        public BaseRepository(IConnectionFactory connection)
        {
            _connection = connection;
        }

        public async Task<T> QuerySingleOrDefault<T>(string query, object parameters = null)
        {
            try
            {
                using (var conn = _connection.Connection())
                {
                    return await conn.QueryFirstOrDefaultAsync<T>(query, parameters);
                }
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public async Task<IEnumerable<T>> QueryAll<T>(string query, object parameters = null)
        {
            try
            {
                using (var conn = _connection.Connection())
                {
                    return await conn.QueryAsync<T>(query, parameters);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> Execute(string query, object parameters = null)
        {
            try
            {
                using (var conn = _connection.Connection())
                {
                    var id = await conn.ExecuteAsync(query, parameters);

                    if(id > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
