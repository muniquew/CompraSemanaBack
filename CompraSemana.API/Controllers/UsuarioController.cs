using CompraSemana.Core.Service.DTO;
using CompraSemana.Core.Service.Interfaces;
using CompraSemana.Core.Util.Exception;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompraSemana.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ITokenService _tokenService;

        public UsuarioController(IUsuarioService usuarioService, ITokenService tokenService)
        {
            _usuarioService = usuarioService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Autenticar([FromBody] UsuarioDTO usuario)
        {
            var _usuario = await _usuarioService.Autenticar(usuario.Email, usuario.Senha);

            if (_usuario == null)
            {
                throw new ServiceException("Usuário ou senha inválido.");
            }

            var jwtToken = _tokenService.CreateToken(_usuario);
            _usuario.Senha = string.Empty;

            return new
            {
                usuario = _usuario,
                token = jwtToken
            };
        }
    }
}
