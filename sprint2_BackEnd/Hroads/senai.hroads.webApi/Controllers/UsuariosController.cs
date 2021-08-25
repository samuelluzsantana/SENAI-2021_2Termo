using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuariosRepository _usuariosRepository { get; set; }
        public UsuariosController()
        {
            _usuariosRepository = new UsuariosRepository();
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">O objeto novoUsuario recebe as informações a serem cadastradas</param>
        /// <returns>Um Status Code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            // Chama método
            _usuariosRepository.Cadastrar(novoUsuario);
            // Retorna status code
            return StatusCode(201);
        }

        /// <summary>
        /// Lista todos os usuários e suas informações
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_usuariosRepository.Listar());
        }

        /// <summary>
        /// Lista os usuários e seus tipos
        /// </summary>
        /// <returns>Uma lista de usuários com seus respectivos tipos</returns>
        [Authorize(Roles = "1")]
        [HttpGet("Tipo")]
        public IActionResult GetTipo()
        {
            return Ok(_usuariosRepository.ListarTipo());
        }

        /// <summary>
        /// Lista um usuário atavés do seu id
        /// </summary>
        /// <param name="id">Parâmetro id a ser buscado</param>
        /// <returns>Um usuário</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_usuariosRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Atualiza as informações de um usuário
        /// </summary>
        /// <param name="id">Parâmetro utilizado na atualização</param>
        /// <param name="usuarioAtualizado">Objeto usuarioAtualizado que armazena as novas informações</param>
        /// <returns>Um Status Code 204 - No Cotent</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuarioAtualizado)
        {
            _usuariosRepository.Atualizar(id, usuarioAtualizado);
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="id">Recebe o parâmetro id para a deleção</param>
        /// <returns>Um status code 204 - No Content</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Chama método
            _usuariosRepository.Deletar(id);
            // Retorna status code
            return StatusCode(204);
        }

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="login">recebe o email e senha do usuário para validação</param>
        /// <returns>Um token</returns>
        [Authorize(Roles = "1")]
        [HttpPost("Login")]
        public IActionResult Login(Usuario login)
        {
            // Busca o usuário pelo e-mail e senha
            Usuario usuarioBuscado = _usuariosRepository.BuscarPorEmailSenha(login.Email, login.Senha);

            // Caso não encontre nenhum usuário com o e-mail e senha informados
            if (usuarioBuscado == null)
            {
                // retorna NotFound com uma mensagem personalizada
                return NotFound("E-mail ou senha incorretos");
            }

            //Caso encontre, prossegue para a criação do token

            // Define os dados que serão fornecidos no token - Payload
            var claims = new[]
            {
                // Formato da Claim = TipoDaClaim, ValorDaClaim
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),
            };

            // Define a chave de acesso ao token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("HROADS-key-autenticacao"));

            // Define as credenciais do token - Header
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Define a composição do token
            var token = new JwtSecurityToken(
                issuer: "HROADS.webApi",               // emissor do token
                audience: "HROADS.webApi",             // destinatário do token
                claims: claims,                        // dados definidos acima (linha 104)
                expires: DateTime.Now.AddMinutes(30),  // tempo de expiração
                signingCredentials: creds               // credenciais do token
                                                        // 
            );

            // Retorna um status code 200 - Ok com o token criado
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
