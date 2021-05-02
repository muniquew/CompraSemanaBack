using CompraSemana.Core.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraSemana.Core.Service.Interfaces
{
    public interface IProdutoService
    {
        Task<ProdutoDTO> ObterProdutoPorId(int id);
        Task<IEnumerable<ProdutoDTO>> ObterTodosProdutos();
        Task<bool> Adicionar(ProdutoDTO produto);
        Task<bool> Atualizar(ProdutoDTO produto);
        Task<bool> Deletar(int id);
    }
}
