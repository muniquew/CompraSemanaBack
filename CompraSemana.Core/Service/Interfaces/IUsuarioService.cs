using CompraSemana.Core.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraSemana.Core.Service.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> Autenticar(string email, string senha);
    }
}
