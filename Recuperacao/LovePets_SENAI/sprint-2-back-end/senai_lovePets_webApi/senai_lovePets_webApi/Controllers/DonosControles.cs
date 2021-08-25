using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using senai_lovePets_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Controllers
{
    [Produces("Application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DonosController : ControllerBase
    {
        private IDonoRepository _donoRepository { get; set; }

        public DonosController()
        {
            _donoRepository = new DonoRepository();
        }

        /// <summary>
        /// Lista todos os donos cadastrados no banco
        /// </summary>
        /// <returns>Uma lista de donos e um status code - 200 ok</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult List()
        {
            try
            {
                return Ok(_donoRepository.List());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// busca um dono através do seu id
        /// </summary>
        /// <param name="idDono">Id do Dono que sera buscado</param>
        /// <returns>O Dono buscado</returns> 

        [Authorize(Roles = "1")]
        [HttpGet("{idDono}")]
        public IActionResult BuscarPorId(int idDono)
        {
            try
            {
                return Ok(_donoRepository.BuscarPorId(idDono));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra um novo dono no banco
        /// </summary>
        /// <param name="novoDono">Objeto com as novas informações</param>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Dono novoDono)
        {
            try
            {
                _donoRepository.Cadastrar(novoDono);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Atualiza um dono ja cadastrado no banco
        /// </summary>
        /// <param name="idDono">ID do dono que sera atualizado</param>
        /// <param name="donoAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>

        [Authorize(Roles = "1")]
        [HttpPut("{idDono}")]
        public IActionResult Atualizar(int idDono, Dono donoAtualizado)
        {
            try
            {
                _donoRepository.Atualizar(idDono, donoAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        /// <summary>
        /// Deleta um dono
        /// </summary>
        /// <param name="idDono">id do dono que sera deletado</param>
        [Authorize(Roles = "1")]
        [HttpDelete("{idDono}")]
        public IActionResult Deletar(int idDono)
        {
            try
            {
                _donoRepository.Deletar(idDono);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

    }
}
