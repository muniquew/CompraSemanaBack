using CompraSemana.Core.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraSemana.Core.Service.Interfaces
{
    public interface IUnidadeService
    {
        Task<UnidadeDTO> ObterUnidadePorId(int id);
        Task<IEnumerable<UnidadeDTO>> ObterTodasUnidades();
        Task<bool> Adicionar(UnidadeDTO unidade);
        Task<bool> Atualizar(UnidadeDTO unidade);
        Task<bool> Deletar(int id);
    }
}
