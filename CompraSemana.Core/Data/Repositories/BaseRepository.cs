using CompraSemana.Core.Data.Interfaces;
using Dapper;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<BaseRepository> _logger;


        public BaseRepository(IConnectionFactory connection, ILogger<BaseRepository> logger)
        {
            _connection = connection;
            _logger = logger;
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception {0} no comando {1} params {2}", ex.Message, query, parameters);
                return default;
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception {0} no comando {1} params {2}", ex.Message, query, parameters);
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception {0} no comando {1} params {2}", ex.Message, query, parameters);
                return false;
            }
        }

    }
}
