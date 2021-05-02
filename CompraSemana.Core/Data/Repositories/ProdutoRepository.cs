using CompraSemana.Core.Data.Interfaces;
using CompraSemana.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraSemana.Core.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IConnectionFactory _connection;
        private readonly IBaseRepository _baseRepository;

        public ProdutoRepository(IConnectionFactory connection, IBaseRepository baseRepository)
        {
            _connection = connection;
            _baseRepository = baseRepository;
        }

        public async Task<Produto> ConsultarUnico(int id)
        {
            var sql = "SELECT Id, Nome, Situacao, CategoriaId FROM Produto Where Id = @Id";

            return await _baseRepository.QuerySingleOrDefault<Produto>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Produto>> ConsultarTodos()
        {
            var sql = "SELECT Id, Nome, Situacao, CategoriaId FROM Produto";

            return await _baseRepository.QueryAll<Produto>(sql);
        }

        public async Task<bool> Adicionar(Produto produto)
        {
            var sql = "INSERT INTO Produto (Nome, Situacao, CategoriaId) Values (@Nome, @Situacao, @CategoriaId);";

            return await _baseRepository.Execute(sql, produto);
        }

        public async Task<bool> Atualizar(Produto produto)
        {
            var sql = "UPDATE Produto SET Nome = @Nome, Situacao = @Situacao, CategoriaId = @CategoriaId WHERE Id = @Id;";

            return await _baseRepository.Execute(sql, produto);
        }

        public async Task<bool> Deletar(int id)
        {
            var sql = "DELETE FROM Produto WHERE Id = @Id;";

            return await _baseRepository.Execute(sql, new { Id = id });
        }
    }
}
