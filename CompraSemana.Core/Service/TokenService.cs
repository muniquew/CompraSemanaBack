using CompraSemana.Core.Models;
using CompraSemana.Core.Service.DTO;
using CompraSemana.Core.Service.Interfaces;
using CompraSemana.Core.Util;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CompraSemana.Core.Service
{
    public class TokenService : ITokenService
    {
        public string CreateToken(UsuarioDTO usuario)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var symmetricKey = Encoding.ASCII.GetBytes(JwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nome)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = jwtHandler.CreateToken(tokenDescriptor);
            return jwtHandler.WriteToken(token);
        }
    }
}
