using CompraSemana.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraSemana.Core.Data.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> ConsultarUnico(int id);
        Task<IEnumerable<Produto>> ConsultarTodos();
        Task<bool> Adicionar(Produto produto);
        Task<bool> Atualizar(Produto produto);
        Task<bool> Deletar(int id);
    }
}
