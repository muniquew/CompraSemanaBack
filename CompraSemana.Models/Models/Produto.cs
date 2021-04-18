namespace CompraSemana.Core.Models
{
    class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Situacao { get; set; }
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
    }
}
