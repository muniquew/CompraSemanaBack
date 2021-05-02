using CompraSemana.Core.Service.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompraSemana.Core.Service.Interfaces
{
    public interface ICompraService
    {
        Task<CompraDTO> ObterCompraPorId(int id);
        Task<IEnumerable<CompraDTO>> ObterTodasCompras();
        Task<bool> Adicionar(CompraDTO compra);
        Task<bool> Atualizar(CompraDTO compra);
        Task<bool> Deletar(int id);
    }
}
