using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraSemana.Core.Service.DTO
{
    public class CompraProdutoDTO
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int UnidadeId { get; set; }
        public int QtdProduto { get; set; }
        public int Situacao { get; set; }
    }
}
