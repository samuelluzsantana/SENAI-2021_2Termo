using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TiposUsuarioController : ControllerBase
    {
        private ITiposUsuarioRepository _tiposUsuarioRepository { get; set; }
        public TiposUsuarioController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();
        }

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipo">Objeto novoTipo com as informações a serem cadastradas</param>
        /// <returns>Um Status Code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TiposUsuario novoTipo)
        {
            // Chama método
            _tiposUsuarioRepository.Cadastrar(novoTipo);
            // Retorna status code
            return StatusCode(201);
        }

        /// <summary>
        /// Lista todos os tipos de usuário
        /// </summary>
        /// <returns>Uma lista de tipos de usuario</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_tiposUsuarioRepository.Listar());
        }

        /// <summary>
        /// Lista um tipo de usuário atavés do seu id
        /// </summary>
        /// <param name="id">Parâmetro id a ser buscado</param>
        /// <returns>Um tipo de usuario</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_tiposUsuarioRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Atualiza as informaçoes do tipo de usuario
        /// </summary>
        /// <param name="id">Parâmetro id do tipo de usuário a ser atualizado</param>
        /// <param name="tipoAtualizado">Objeto tipoAtualizado que recebe as novas informações</param>
        /// <returns>Status Code 204 - No Content</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposUsuario tipoAtualizado)
        {
            _tiposUsuarioRepository.Atualizar(id, tipoAtualizado);
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta um tipo de usuário
        /// </summary>
        /// <param name="id">Parâmetro id do tipo de usuário a ser deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Chama método
            _tiposUsuarioRepository.Deletar(id);
            // Retorna status code
            return StatusCode(204);
        }
    }
}
