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
    public class TiposUsuariosController : ControllerBase
    {
        private ITiposUsuarioRepository _tiposUsuarioRepository { get; set; }

        public TiposUsuariosController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tiposUsuarioRepository.Listar());
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
                return Ok(_tiposUsuarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TiposUsuario novoTipo)
        {
            try
            {
                _tiposUsuarioRepository.Cadastrar(novoTipo);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposUsuario tipoAtualizado)
        {
            try
            {
                _tiposUsuarioRepository.Atualizar(id, tipoAtualizado);

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
                _tiposUsuarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpGet("usuarios-tipos")]
        public IActionResult GetU()
        {
            try
            {
                return Ok(_tiposUsuarioRepository.ListarUsuarios());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}
