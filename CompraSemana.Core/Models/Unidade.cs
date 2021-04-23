using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraSemana.Core.Models
{
    public class Unidade
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public int Situacao { get; set; }
    }
}
