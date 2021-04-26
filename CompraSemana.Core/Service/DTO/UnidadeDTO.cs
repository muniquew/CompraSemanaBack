using System.Text.Json.Serialization;

namespace CompraSemana.Core.Service.DTO
{
    public class UnidadeDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public int Situacao { get; set; }
        public string SituacaoDescricao { get; set; }
    }
}
