using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wish_list.webAPI.Domains;
using wish_list.webAPI.Interfaces;
using wish_list.webAPI.Repositories;

namespace wish_list.webAPI.Controllers
{
    [Produces("application/json")]
    
    [Route("api/[controller]")]
    
    [ApiController]
    
    public class DesejosController : ControllerBase
    {
        
        private IDesejoRepository _desejoRepository { get; set; }

        
        public DesejosController()
        {
            _desejoRepository = new DesejoRepository();
        }

        
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
              return Ok(_desejoRepository.ListarDesejos());
            }
            
            catch (Exception erro)
            {
              return BadRequest(erro);
            }
        }

       
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
               return Ok(_desejoRepository.BuscarDesejoPorId(id));
            }
            
            catch (Exception erro)
            {
               return BadRequest(erro);
            }
        }

        
        [HttpPost]
        public IActionResult Post(Desejo novoDesejo)
        {
            try
            {
                _desejoRepository.CadastrarDesejo(novoDesejo);

                return StatusCode(201);
            }
            
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        
        [HttpPut("{id}")]
        public IActionResult Put(int id, Desejo desejoAtualizado)
        {
            try
            {
                _desejoRepository.AtualizarDesejo(id, desejoAtualizado);

                return StatusCode(204);
            }
            
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _desejoRepository.DeletarDesejo(id);

                return StatusCode(204);
            }
            
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    
    
    }
}
