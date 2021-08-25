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
    public class HabilidadesController : ControllerBase
    {
        /// <summary>
        /// Objeto _HabilidadeRepository que recebe todos os metodos da Interface das habilidades
        /// </summary>
        private IHabilidadesRepository _habilidadesRepository { get; set; }

        /// <summary>
        /// instancia o objeto _habilidadesRepository Para que haja refernecia no repositorio habilidadeRepository.
        /// </summary>
        public HabilidadesController()
        {
            _habilidadesRepository = new HabilidadeRepository();
        }


        /// <summary>
        /// Lista todas as Habilidades
        /// </summary>
        /// <returns>Uma lista de todas as Habilidades e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //retorna resposta da requisição
            return Ok(_habilidadesRepository.Listar());
        }



        /// <summary>
        /// Atualiza uma habilidade existente
        /// </summary>
        /// <param name="id">ID da habilidade que será atualizada</param>
        /// <param name="habilidadeAtualizada">Objeto habilidadeAtualizada com as novas informações e um status code (204)</param>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Habilidade habilidadeAtualizada)
        {
            //faz aa chamada para o metodo
            _habilidadesRepository.Atualizar(id, habilidadeAtualizada);

            //retorna um status code
            return StatusCode(204);
        }


        /// <summary>
        /// Buscamos um Habilidade através do seu Id 
        /// </summary>
        /// <param name="id">id da Habilidade que sera buscado</param>
        /// <returns>Uma habiliade enconrado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_habilidadesRepository.BuscarPorId(id));
        }


        /// <summary>
        /// Cadastra uma nova habilidade 
        /// </summary>
        /// <param name="novaHabilidade">Objeto novaHabilidade que sera cadastrada</param>
        /// <returns>UM status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Habilidade novaHabilidade)
        {
            //faz a chamada para o metodo
            _habilidadesRepository.Cadastrar(novaHabilidade);

            return StatusCode(201);
        }


        /// <summary>
        /// Deleta Habilidade existente 
        /// </summary>
        /// <param name="id">ID da habilidade que será deletada</param>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {   //faz a chamada para um metodo
            _habilidadesRepository.Deletar(id);

            //retorna um status code
            return StatusCode(204);
        }


        /// <summary>
        /// Lista uma habilidade e seu tipo
        /// </summary>
        /// <returns>uma habilidade e seu tipo</returns>
        /// <returns>Uma lista de todas as Habilidades e um status code 200 - Ok</returns>
        [HttpGet("Tipo")]
        public IActionResult GetTipo()
        {
            //retorna resposta da requisição
            return Ok(_habilidadesRepository.ListarTipo());
        }

    }
}
