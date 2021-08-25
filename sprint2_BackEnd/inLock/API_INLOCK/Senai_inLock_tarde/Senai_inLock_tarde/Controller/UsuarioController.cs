using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai_inLock_tarde.Domain;
using Senai_inLock_tarde.Interface;
using Senai_inLock_tarde.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai_inLock_tarde.Controller
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public UsuarioController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost("login")]

        public IActionResult logar(UsuarioDomain usuario)
        {
            UsuarioDomain usuarioBuscado = _UsuarioRepository.Login(usuario.email, usuario.senha);

            if(usuarioBuscado != null)
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),

                    new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.idUsuario.ToString()),

                    new Claim(ClaimTypes.Role, usuarioBuscado.tipoUsuario.titulo)

                };

                var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-autenticacao"));

                var credenciais = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(

                    issuer: "inlock.webapi",

                    audience: "inlock.webapi",

                    claims: claims,

                    expires: DateTime.Now.AddMinutes(15),

                    signingCredentials: credenciais

                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });



            }

            return NotFound("Email ou senha Invalido.");

        }


    }
}
