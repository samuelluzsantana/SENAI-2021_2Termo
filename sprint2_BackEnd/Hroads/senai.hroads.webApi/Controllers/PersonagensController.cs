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
    public class PersonagensController : ControllerBase
    {
        private IPersonagensRepository _personagensRepository { get; set; }
        public PersonagensController()
        {
            _personagensRepository = new PersonagensRepository();
        }

        /// <summary>
        /// Cadastra um novo Personagem
        /// </summary>
        /// <param name="novoPersonagem">O objeto novoPersonagem recebe as informações a serem cadastradas</param>
        /// <returns>Um Status Code 201 - Created</returns>
        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Post(Personagen novoPersonagem)
        {
            // Chama método
            _personagensRepository.Cadastrar(novoPersonagem);
            // Retorna status code
            return StatusCode(201);
        }

        /// <summary>
        /// Lista todos os personagens
        /// </summary>
        /// <returns>Uma lista de personagens</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_personagensRepository.Listar());
        }

        /// <summary>
        /// Lista todos os personagens com suas respectivas classes
        /// </summary>
        /// <returns>Uma lista de personagens e suas classes</returns>
        [Authorize]
        [HttpGet("Classes")]
        public IActionResult GetClasses()
        {
            return Ok(_personagensRepository.ListarClasses());
        }

        /// <summary>
        /// Busca um personagem através do id
        /// </summary>
        /// <param name="id">Parâmetro id a ser buscado</param>
        /// <returns>Um personagem especifico</returns>
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_personagensRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Atualiza as informaçoes de um personagem
        /// </summary>
        /// <param name="id">Parâmetro id do personagem a ser atualizado</param>
        /// <param name="personagemAtualizado">Objeto personagemAtualizado que vai receber as novas informaçoes</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Personagen personagemAtualizado)
        {
            _personagensRepository.Atualizar(id, personagemAtualizado);
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta um personagem
        /// </summary>
        /// <param name="id">Parâmetro id a ser deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Chama método
            _personagensRepository.Deletar(id);
            // Retorna status code
            return StatusCode(204);
        }


    }
}
