using CompraSemana.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraSemana.Core.Data.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ConsultarLogin(string email);
        Task<bool> Adicionar(Usuario usuario);
        Task<bool> Atualizar(Usuario usuario);
    }
}
