using CompraSemana.Core.Data.Interfaces;
using CompraSemana.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraSemana.Core.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConnectionFactory _connection;
        private readonly IBaseRepository _baseRepository;

        public UsuarioRepository(IConnectionFactory connection, IBaseRepository baseRepository)
        {
            _connection = connection;
            _baseRepository = baseRepository;
        }

        public async Task<Usuario> ConsultarLogin(string email)
        {
            var sql = "SELECT Id, Nome, Email, Situacao, Senha FROM Usuario Where Email = @Email";

            return await _baseRepository.QuerySingleOrDefault<Usuario>(sql, new { Email = email });
        }

        public async Task<bool> Adicionar(Usuario usuario)
        {
            var sql = "INSERT INTO Usuario (Nome, Email, Situacao, Senha) Values (@Nome, @Email, @Situacao, @Senha);";

            return await _baseRepository.Execute(sql, usuario);
        }

        public async Task<bool> Atualizar(Usuario usuario)
        {
            var sql = "UPDATE Usuario SET Nome = @Nome, Email = @Email, Situacao = @Situacao, Senha = @Senha WHERE Id = @Id;";

            return await _baseRepository.Execute(sql, usuario);
        }
    }
}
