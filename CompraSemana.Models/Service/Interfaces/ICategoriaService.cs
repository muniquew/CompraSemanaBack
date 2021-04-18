using CompraSemana.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraSemana.Core.Service.Interfaces
{
    public interface ICategoriaService
    {
        Task<Categoria> ObterCategoriaPorId(int id);
        Task<string> ObterTodasCategorias();
        //Task<IEnumerable<Categoria>> ObterTodasCategorias();
    }
}
