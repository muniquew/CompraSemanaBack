using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CompraSemana.Core.Service.DTO
{
    public class UnidadeDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public string Sigla { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public int Situacao { get; set; }
        public string SituacaoDescricao
        {
            get
            {
                return this.Situacao switch
                {
                    1 => "Ativo",
                    0 => "Inativo",
                    _ => " - ",
                };
            }
        }
    }
}
