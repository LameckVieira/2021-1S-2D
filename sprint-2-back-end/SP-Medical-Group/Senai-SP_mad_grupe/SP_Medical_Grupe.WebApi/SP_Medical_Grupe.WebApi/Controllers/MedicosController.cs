using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SP_Medical_Grupe.WebApi.Interfaces;
using SP_Medical_Grupe.WebApi.Repositories;
using SP_Medical_Grupe.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Grupe.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private IMedicoRepository _medicoRepository { get; set; }

        public MedicosController()
        {
            _medicoRepository = new MedicoRepository();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_medicoRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_medicoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Medico medicoNovo)
        {
            try
            {
                _medicoRepository.Cadastrar(medicoNovo);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Medico medicoAtualizado)
        {
            try
            {
                _medicoRepository.Atualizar(id, medicoAtualizado);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _medicoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

    }
}
