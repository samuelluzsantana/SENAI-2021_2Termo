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
    //tipo de resposta da API será JSON
    [Produces("application/json")]
    //Define que a rota de uma requisição sera no formato dominio/api/nomeController
    [Route("api/[controller]")]
    //Define que é um controlador de API
    [ApiController]

    public class TiposHabilidadeController : ControllerBase
    {
        /// <summary>
        /// Objeto _tiposHabilidadesRepository que recebe todos os metodos da Interface dos Tipo de habilidades
        /// </summary>
        private ITiposHabilidadeRepository _tiposHabilidadesRepository { get; set; }

        /// <summary>
        /// instancia o objeto _tiposHabilidadesRepository Para que haja refernecia no repositorio TiposhabilidadeRepository.
        /// </summary>
        public TiposHabilidadeController()
        {
            _tiposHabilidadesRepository = new TiposHabilidadesRepository();
        }

        /// <summary>
        /// Lista todas as Habilidades cadastradas no BD 
        /// </summary>
        /// <returns>Uma Lista de habilidades</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna uma lista com todos os tipos de habilidade
            return Ok(_tiposHabilidadesRepository.Listar());
        }

        [HttpGet("Habilidade")]
        public IActionResult GetHabilidade()
        {
            //Retorna uma lista com todos os tipos de habilidade e suas habilidades
            return Ok(_tiposHabilidadesRepository.ListarHabilidade());
        }

        /// <summary>
        /// Busca um tipo de habilidade através do seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>um tipo de habilidade buscada</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_tiposHabilidadesRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo tipo de habilidade
        /// </summary>
        /// <param name="novoTipo">Objeto Tipo que sera cadastrado</param>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TiposHabilidade novoTipo)
        {
            //faz a chamada para o metodo
            _tiposHabilidadesRepository.Cadastrar(novoTipo);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um tipo de habilidade existente
        /// </summary>
        /// <param name="id">ID do tipo de habilidade que será atualizada</param>
        /// <param name="tiposHabilidade">Objeto tipoAtualizado com as novas informações</param>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposHabilidade tiposHabilidade)
        {
            //faz aa chamada para o metodo
            _tiposHabilidadesRepository.Atualizar(id, tiposHabilidade);

            //retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta uma tipo de habilidade existente 
        /// </summary>
        /// <param name="id">ID do  Tipo de habilidade que será deletada</param>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {   //faz a chamada para um metodo
            _tiposHabilidadesRepository.Deletar(id);

            //retorna um status code
            return StatusCode(204);
        }
    }
}
