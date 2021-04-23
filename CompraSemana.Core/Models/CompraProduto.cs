namespace CompraSemana.Core.Models
{
    public class CompraProduto
    {
        public int Id { get; set; }
        public int CompraId { get; set; }
        public int ProdutoId { get; set; }
        public int UnidadeId { get; set; }
        public int QtdProduto { get; set; }
        public int Situacao { get; set; }
    }
}
