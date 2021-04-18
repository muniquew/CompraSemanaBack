using CompraSemana.Core.Data.Interfaces;
using CompraSemana.Core.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraSemana.Core.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly IConnectionFactory _connection;

        public CategoriaRepository(IConnectionFactory connection) 
        {
            _connection = connection;
        }

        public async Task<Categoria> ConsultarUnico(int id)
        {
            var sql = "Select Id, Descricao, Situacao From Categoria Where Id = :Id";

            try
            {
                using (var conn = _connection.Connection())
                {
                    return await conn.QueryFirstOrDefaultAsync<Categoria>(sql, new { Id = id });
                }
            }
            catch(Exception)
            {
                return default(Categoria);
            }
        }
        
        public async Task<IEnumerable<Categoria>> ConsultarTodos()
        {
            var sql = "Select Id, Descricao, Situacao From Categoria";

            try
            {
                using (var conn = _connection.Connection())
                {
                    return await conn.QueryAsync<Categoria>(sql);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> Adicionar(Categoria categoria)
        {
            var sql = "INSERT INTO Categoria (Descricao, Situacao) Values (@Descricao, @Situacao);";

            try
            {
                using (var conn = _connection.Connection())
                {
                    conn.Open();

                    var result = await conn.ExecuteAsync(sql, categoria);

                    return result;
                }
            }
            catch(Exception)
            {
                //Implementar log
                return 0;
            }
        }

        public Task<int> Atualizar(Categoria entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Categoria>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        
    }
}
