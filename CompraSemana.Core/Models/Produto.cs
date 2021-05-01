namespace CompraSemana.Core.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Situacao { get; set; }
        public int CategoriaId { get; set; }
    }
}
