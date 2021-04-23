using CompraSemana.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraSemana.Core.Data.Interfaces
{
    public interface IUnidadeRepository
    {
        Task<Unidade> ConsultarUnico(int id);
        Task<IEnumerable<Unidade>> ConsultarTodos();
        Task<bool> Adicionar(Unidade unidade);
        Task<bool> Atualizar(Unidade unidade);
        Task<bool> Deletar(int id);
    }
}
