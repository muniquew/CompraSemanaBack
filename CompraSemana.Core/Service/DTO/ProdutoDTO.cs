using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraSemana.Core.Service.DTO
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public int Situacao { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public int CategoriaId { get; set; }
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
