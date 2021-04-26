using CompraSemana.Core.Data.Interfaces;
using CompraSemana.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraSemana.Core.Data.Repositories
{
    public class UnidadeRepository : IUnidadeRepository
    {
        private readonly IConnectionFactory _connection;
        private readonly IBaseRepository _baseRepository;

        public UnidadeRepository(IConnectionFactory connection, IBaseRepository baseRepository)
        {
            _connection = connection;
            _baseRepository = baseRepository;
        }

        public async Task<Unidade> ConsultarUnico(int id)
        {
            var sql = "SELECT Id, Descricao, Sigla, Situacao FROM Unidade Where Id = @Id";

            return await _baseRepository.QuerySingleOrDefault<Unidade>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Unidade>> ConsultarTodos()
        {
            var sql = "SELECT Id, Descricao, Sigla, Situacao FROM Unidade";

            return await _baseRepository.QueryAll<Unidade>(sql);
        }

        public async Task<bool> Adicionar(Unidade unidade)
        {
            var sql = "INSERT INTO Unidade (Descricao, Sigla, Situacao) Values (@Descricao, @Sigla, @Situacao);";

            return await _baseRepository.Execute(sql, unidade);
        }

        public async Task<bool> Atualizar(Unidade unidade)
        {
            var sql = "UPDATE Unidade SET Descricao = @Descricao, Sigla = @Sigla, Situacao = @Situacao WHERE Id = @Id;";

            return await _baseRepository.Execute(sql, unidade);
        }

        public async Task<bool> Deletar(int id)
        {
            var sql = "DELETE FROM Unidade WHERE Id = @Id;";

            return await _baseRepository.Execute(sql, new { Id = id });
        }
    }
}
