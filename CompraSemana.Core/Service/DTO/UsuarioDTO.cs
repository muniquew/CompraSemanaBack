using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CompraSemana.Core.Service.DTO
{
    public class UsuarioDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        //[JsonIgnore]
        public string Senha { get; set; }
        public int Situacao { get; set; }
    }
}
