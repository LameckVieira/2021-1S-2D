using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        
            private IEstudioRepository _estudiosRepository { get; set; }

            public EstudiosController()
            {
                _estudiosRepository = new EstudioRepository();
            }
            
            [Authorize]
            [HttpGet]
            public IActionResult Get()
            {
                List<Estudios> listaEstudios = _estudiosRepository.ListarTodos();
                return Ok(listaEstudios);
            }

            [Authorize(Roles ="1")]
            [HttpPost]
            public IActionResult Post(Estudios novoEstudio)
            {
                _estudiosRepository.Cadastrar(novoEstudio);
                return StatusCode(201);
            }

            [HttpDelete]
            public IActionResult Delete(Estudios estudiosDelete)
            {
                _estudiosRepository.Deletar(estudiosDelete.idEstudio);
                return StatusCode(204);
            }

            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                Estudios estudioBuscado = _estudiosRepository.BuscarporId(id);
                if (estudioBuscado == null)
                {
                    return NotFound("Nenhum estudio foi encontrado!");
                }
                return Ok(estudioBuscado);
            }
            [HttpPut]
            public IActionResult PutIdBody(Estudios estudioAtualizado)
            {
                Estudios estudioBuscado = _estudiosRepository.BuscarporId(estudioAtualizado.idEstudio);
                if (estudioBuscado != null)
                {
                    try
                    {
                        _estudiosRepository.Atualizar(estudioAtualizado.idEstudio, estudioAtualizado);
                        return NoContent();
                    }
                    catch (Exception erro)
                    {

                        return BadRequest(erro);
                    }
                }
                return NotFound
                        (
                        new
                        {
                            mensagem = "Estudio NÃo Encontrado."
                        }
                        );
            }
    }
}
