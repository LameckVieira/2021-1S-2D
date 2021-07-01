using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SP_Medical_Grupe.WebApi.Domains;
using SP_Medical_Grupe.WebApi.Interfaces;
using SP_Medical_Grupe.WebApi.Repositories;
using SP_Medical_Grupe.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Grupe.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository _consultaRepository { get; set; }

        public ConsultasController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_consultaRepository.Listar());
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
                return Ok(_consultaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Consulta novaConsulta)
        {
            try
            {
                _consultaRepository.Cadastrar(novaConsulta);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Consulta consultaAtualizada)
        {
            try
            {
                _consultaRepository.Atualizar(id, consultaAtualizada);

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
                _consultaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);

            }
        }

        [Authorize(Roles = "2, 3")]
        [HttpGet("minhasconsultas")]
        public IActionResult ListarMinhasConsultas(int id)
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(m => m.Type == JwtRegisteredClaimNames.Jti).Value);
                return Ok(_consultaRepository.ListarMinhasConsultas(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPatch("agendamento/{id}")]
        public IActionResult AtualizarSituacao(int id, Consulta situacao)
        {
            try
            {
                _consultaRepository.Confirmação(id, situacao.Situacao);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro); 
            }
        }

        [Authorize(Roles = "2")]
        [HttpPatch("prontuario/{id}")]
        public IActionResult AtualizarDesc(int id, Consulta descricao)
        {
            try
            {
                _consultaRepository.Prontuario(id, descricao.Descricao);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}
