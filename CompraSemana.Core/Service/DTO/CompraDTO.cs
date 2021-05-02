using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraSemana.Core.Service.DTO
{
    public class CompraDTO
    {
        public int Id { get; set; }
        public DateTime DataCompra { get; set; }
        public int QtdItens { get; set; }
        public int Situacao { get; set; }
        public ICollection<CompraProdutoDTO> CompraProdutos { get; set; }
    }
}
