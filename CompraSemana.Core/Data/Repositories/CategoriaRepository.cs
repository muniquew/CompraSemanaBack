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
        private readonly IBaseRepository _baseRepository;

        public CategoriaRepository(IConnectionFactory connection, IBaseRepository baseRepository)
        {
            _connection = connection;
            _baseRepository = baseRepository;
        }

        public async Task<Categoria> ConsultarUnico(int id)
        {
            var sql = "SELECT Id, Descricao, Situacao FROM Categoria Where Id = @Id";

            return await _baseRepository.QuerySingleOrDefault<Categoria>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Categoria>> ConsultarTodos()
        {
            var sql = "SELECT Id, Descricao, Situacao FROM Categoria";

            return await _baseRepository.QueryAll<Categoria>(sql);
        }

        public async Task<bool> Adicionar(Categoria categoria)
        {
            var sql = "INSERT INTO Categoria (Descricao, Situacao) Values (@Descricao, @Situacao);";

            return await _baseRepository.Execute(sql, categoria);
        }

        public async Task<bool> Atualizar(Categoria categoria)
        {
            var sql = "UPDATE Categoria SET Descricao = @Descricao, Situacao = @Situacao WHERE Id = @Id;";

            return await _baseRepository.Execute(sql, categoria);
        }

        public async Task<bool> Deletar(int id)
        {
            var sql = "DELETE FROM Categoria WHERE Id = @Id;";

            return await _baseRepository.Execute(sql, new { Id = id });
        }
    }
}
