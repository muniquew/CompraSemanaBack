using CompraSemana.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraSemana.Core.Data.Interfaces
{
    public interface ICompraRepository
    {
        Task<Compra> ConsultarUnico(int id);
        Task<IEnumerable<Compra>> ConsultarTodos();
        Task<bool> Adicionar(Compra compra);
        Task<bool> Atualizar(Compra compra);
        Task<bool> Deletar(int id);
    }
}
