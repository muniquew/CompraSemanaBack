using CompraSemana.Core.Data.Interfaces;
using CompraSemana.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraSemana.Core.Data.Repositories
{
    public class CompraRepository : ICompraRepository
    {
        private readonly IConnectionFactory _connection;
        private readonly IBaseRepository _baseRepository;

        public CompraRepository(IConnectionFactory connection, IBaseRepository baseRepository)
        {
            _connection = connection;
            _baseRepository = baseRepository;
        }

        public async Task<Compra> ConsultarUnico(int id)
        {
            var sql = "SELECT Id, DataCompra, QtdItens, Situacao FROM Compra Where Id = @Id";

            return await _baseRepository.QuerySingleOrDefault<Compra>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Compra>> ConsultarTodos()
        {
            var sql = "SELECT Id, DataCompra, QtdItens, Situacao FROM Compra";

            return await _baseRepository.QueryAll<Compra>(sql);
        }

        public async Task<bool> Adicionar(Compra compra)
        {
            var sql = "INSERT INTO Compra (DataCompra, QtdItens, Situacao) Values (@DataCompra, @QtdItens, @Situacao);";

            return await _baseRepository.Execute(sql, compra);
        }

        public async Task<bool> Atualizar(Compra compra)
        {
            var sql = "UPDATE Compra SET DataCompra = @DataCompra, QtdItens = @QtdItens, Situacao = @Situacao WHERE Id = @Id;";

            return await _baseRepository.Execute(sql, compra);
        }

        public async Task<bool> Deletar(int id)
        {
            var sql = "DELETE FROM Compra WHERE Id = @Id;";

            return await _baseRepository.Execute(sql, new { Id = id });
        }
    }
}
