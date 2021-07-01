using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_gufi_webApi.Domains;
using senai_gufi_webApi.Interfaces;
using senai_gufi_webApi.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace senai_gufi_webApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes às presenças
    /// </summary>
    
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class PresencasController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _presencaRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IPresencaRepository _presencaRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public PresencasController()
        {
            _presencaRepository = new PresencaRepository();
        }

        /// <summary>
        /// Lista todos as presenças
        /// </summary>
        /// <returns>Uma lista de presenças e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_presencaRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca uma presença através do ID
        /// </summary>
        /// <param name="id">ID da presença que será buscada</param>
        /// <returns>Uma presença buscada e um status code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                // Retora a resposta da requisição fazendo a chamada para o método
                return Ok(_presencaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra uma nova presença
        /// </summary>
        /// <param name="novaPresenca">Objeto novaPresenca que será cadastrada</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Presenca novaPresenca)
        {
            try
            {
                // Faz a chamada para o método
                _presencaRepository.Cadastrar(novaPresenca);

                // Retorna um status code
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza uma presença existente
        /// </summary>
        /// <param name="id">ID da presença que será atualizado</param>
        /// <param name="presencaAtualizada">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Presenca presencaAtualizada)
        {
            try
            {
                // Faz a chamada para o método
                _presencaRepository.Atualizar(id, presencaAtualizada);

                // Retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta uma presença existente
        /// </summary>
        /// <param name="id">ID da presença que será deletada</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método
                _presencaRepository.Deletar(id);

                // Retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Lista todos as presenças de um determinado usuário
        /// </summary>
        /// <returns>Uma lista de presenças e um status code 200 - Ok</returns>
        /// dominio/api/presencas/minhas
        [HttpGet("minhas")]
        public IActionResult GetMy()
        {
            try
            {
                // Cria uma variável idUsuario que recebe o valor do ID do usuário que está logado
                int idUsuario = Convert.ToInt32( HttpContext.User.Claims.First( c => c.Type == JwtRegisteredClaimNames.Jti ).Value );

                // Retora a resposta da requisição 200 - OK fazendo a chamada para o método e trazendo a lista
                return Ok(_presencaRepository.ListarMinhas(idUsuario));
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as presenças se o usuário não estiver logado!",
                    error
                });
            }
        }

        /// <summary>
        /// Inscreve o usuário logado em um evento
        /// </summary>
        /// <param name="idEvento">ID do evento que o usuário irá se inscrever</param>
        /// <returns>Um status code 201 - Created</returns>
        /// dominio/api/presencas/inscricao/idEvento
        [HttpPost("inscricao/{idEvento}")]
        public IActionResult Join(int idEvento)
        {
            try
            {
                Presenca inscricao = new Presenca()
                {
                    // Armazena na propriedade IdUsuario da presenca recebida o ID do usuário logado
                    IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value),
                    // Armazena na propriedade IdEvento o ID do evento recebido pela URL
                    IdEvento = idEvento,
                    // Define a situação da presença como "Não confirmada"
                    Situacao = "Não confirmada"
                };

                // Faz a chamada para o método
                _presencaRepository.Inscrever(inscricao);

                // Retora a resposta da requisição 201 - Created
                return StatusCode(201);
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(new
                {
                    mensagem = "Não é possível se inscrever se o usuário não estiver logado!",
                    error
                });
            }
        }

        /// <summary>
        /// Altera o status de uma presença
        /// </summary>
        /// <param name="id">ID da presença que terá a situação alterada</param>
        /// <param name="status">Objeto com o parâmetro que atualiza o situação da presença para Confirmada, Não confirmada ou Recusada</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// dominio/api/presencas/id
        [Authorize(Roles = "1")]
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Presenca status)
        {
            try
            {
                // Faz a chamada para o método
                _presencaRepository.AprovarRecusar(id, status.Situacao);

                // Retora a resposta da requisição 204 - No Content
                return StatusCode(204);
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }
    }
}
