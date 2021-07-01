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
    public class EspecialidadesController : ControllerBase
    {
        private IEspecialidadeRepository _especialidadeRepository { get; set; }

        public EspecialidadesController()
        {
            _especialidadeRepository = new EspecialidadeRepository();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_especialidadeRepository.Listar());
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
                return Ok(_especialidadeRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Especialidade novaEspecialidade)
        {
            try
            {
                _especialidadeRepository.Cadastrar(novaEspecialidade);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Especialidade especialidadeAtualizada)
        {
            try
            {
                _especialidadeRepository.Atualizar(id, especialidadeAtualizada);

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
                _especialidadeRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpGet("medicos-especialidade")]
        public IActionResult GetE()
        {
            try
            {
                return Ok(_especialidadeRepository.ListarMedicos());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}
