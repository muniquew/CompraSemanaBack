using CompraSemana.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraSemana.Core.Data.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<Categoria> ConsultarUnico(int id);
        Task<IEnumerable<Categoria>> ConsultarTodos();
        Task<bool> Adicionar(Categoria categoria);
        Task<bool> Atualizar(Categoria categoria);
        Task<bool> Deletar(int id);
    }
}
