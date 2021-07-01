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
    public class ClinicasController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository { get; set; }

        public ClinicasController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        //[Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_clinicaRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        //[Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_clinicaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        //[Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Clinica novaClinica)
        {
            try
            {
                _clinicaRepository.Cadastrar(novaClinica);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        //[Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Clinica clinicaAtualizada)
        {
            try
            {
                _clinicaRepository.Atualizar(id, clinicaAtualizada);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        //[Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _clinicaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        //[Authorize(Roles = "1")]
        [HttpGet("medicos-da-clinica")]
        public IActionResult GetM()
        {
            try
            {
                return Ok(_clinicaRepository.ListarMedicos());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}
