using CompraSemana.Core.Models;
using CompraSemana.Core.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraSemana.Core.Service.Interfaces
{
    public interface ICategoriaService
    {
        Task<CategoriaDTO> ObterCategoriaPorId(int id);
        Task<IEnumerable<CategoriaDTO>> ObterTodasCategorias();
        Task<bool> Adicionar(CategoriaDTO categoria);
        
    }
}
