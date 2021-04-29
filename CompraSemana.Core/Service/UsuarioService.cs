using AutoMapper;
using CompraSemana.Core.Data.Interfaces;
using CompraSemana.Core.Service.DTO;
using CompraSemana.Core.Service.Interfaces;
using CompraSemana.Core.Util;
using CompraSemana.Core.Util.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraSemana.Core.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioDTO> Autenticar(string email, string senha)
        {
            var _usuario = await _usuarioRepository.ConsultarLogin(email);

            if(_usuario == null)
            {
                throw new ServiceException("Usuário informado não existe.");
            }

            bool senhaValida = Security.VerifyHashedPassword(_usuario.Senha, senha);

            if(senhaValida)
            {
                return _mapper.Map<UsuarioDTO>(_usuario);
            }
            else
            {
                throw new ServiceException("Usuário ou senha inválido.");
            }
        }
    }
}
