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
    public class ClassesController : ControllerBase
    {
        /// <summary>
        /// Objeto _ClasseRepository que recebe todos os metodos da Interface das classes
        /// </summary>
        private IClassesRepository _ClasseRepository { get; set; }

        /// <summary>
        /// instancia o objeto _ClasseRepository Para que haja refernecia no repositorio ClassRepository.
        /// </summary>
        public ClassesController()
        {
            _ClasseRepository = new ClassRepository();
        }


        /// <summary>
        /// Lista todas as classes
        /// </summary>
        /// <returns>Uma lista de todas as Classes e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //retorna resposta da requisição
            return Ok(_ClasseRepository.Listar());
        }


        /// <summary>
        /// Buscamos um classe através do seu Id 
        /// </summary>
        /// <param name="id">id da classe que sera buscado</param>
        /// <returns>Uma classe enconrado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_ClasseRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Listar as classes e os personagens que possuem aquelas classes
        /// </summary>
        /// <returns>Uma lista de classes com os personagens que possuem aquelas classes</returns>
        [HttpGet("Tipo")]
        public IActionResult GetTipo()
        {
            return Ok(_ClasseRepository.ListarPersonagem());
        }


        /// <summary>
        /// Cadastra uma nova classe 
        /// </summary>
        /// <param name="novaClasse">Objeto novaClasse que sera cadastrada</param>
        /// <returns>UM status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Class novaClasse)
        {
            //faz a chamada para o metodo
            _ClasseRepository.Cadastrar(novaClasse);

            return StatusCode(201);
        }


        /// <summary>
        /// Atualiza uma classe existente
        /// </summary>
        /// <param name="id">ID da Classe que será atualizada</param>
        /// <param name="classeAtualizada">Objeto classeAtualizada com as novas informações e um status code (204)</param>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Class classeAtualizada)
        {
            //faz aa chamada para o metodo
            _ClasseRepository.Atualizar(id, classeAtualizada);

            //retorna um status code
            return StatusCode(204);
        }


        /// <summary>
        /// Deleta Classe existente 
        /// </summary>
        /// <param name="id">ID da habilidade que será deletada</param>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {   //faz a chamada para um metodo
            _ClasseRepository.Deletar(id);

            //retorna um status code
            return StatusCode(204);
        }
    }
}
