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
    public class PacientesController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository { get; set; }

        public PacientesController()
        {
            _pacienteRepository = new PacienteRepository();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_pacienteRepository.Listar());
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
                return Ok(_pacienteRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Paciente novoPaciente)
        {
            try
            {
                _pacienteRepository.Cadastrar(novoPaciente);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Paciente pacienteAtualizado)
        {
            try
            {
                _pacienteRepository.Atualizar(id, pacienteAtualizado);

                return StatusCode(204);
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
                _pacienteRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}
