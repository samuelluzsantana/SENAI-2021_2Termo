using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projeto_roman_senai_webApi.Domains;
using projeto_roman_senai_webApi.Interfaces;
using projeto_roman_senai_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_roman_senai_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private IProjetoRepository _projetoRepository { get; set; }

        public ProjetoController()
        {
            _projetoRepository = new ProjetoRepository();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_projetoRepository.ListarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "É preciso estar logado como professor para adicionar um novo projeto.",
                    ex
                });
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Projeto novoProjeto)
        {
            try
            {
                _projetoRepository.Cadastrar(novoProjeto);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "É preciso estar logado como professor para adicionar um novo projeto.",
                    ex
                });
            }
        }
    }
}
