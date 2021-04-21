using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraSemana.Core.Service.DTO
{
    public class CategoriaDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Situacao { get; set; }
        public string SituacaoDescricao { get; set; }
    }
}
