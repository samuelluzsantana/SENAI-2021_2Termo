using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_peoples_webApi.Domains;
using senai_peoples_webApi.Interfaces;
using senai_peoples_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_peoples_webApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes aos funcionarios
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _funcionarioRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public FuncionariosController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }



        /// <summary>
        /// Lista todos os funcionarios
        /// </summary>
        /// <returns>Uma lista de funcionarios e um status code 200 - Ok</returns>
        /// dominio/api/Funcionarios
        [HttpGet]
        public IActionResult Get()
        {
            // Faz a chamada para o método .ListarTodos()
            // Retorna a lista e um status code 200 - Ok
            List<FuncionarioDomain> funcionarios = _funcionarioRepository.ListarTodos();

            return Ok(funcionarios);
        }

    }
}
