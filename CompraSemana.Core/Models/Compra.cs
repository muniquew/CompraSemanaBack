using System;
using System.Collections.Generic;

namespace CompraSemana.Core.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public DateTime DataCompra { get; set; }
        public int QtdItens { get; set; }
        public int Situacao { get; set; }
        public ICollection<CompraProduto> CompraProdutos { get; set; }
    }
}
