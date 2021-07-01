using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using senai_filmes_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controller responsável pelos endpoints referentes aos gêneros
/// </summary>
namespace senai_filmes_webApi.Controllers
{
    // Define que o tipo de resposta da API será no formato json
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/generos
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]

    public class GenerosController : ControllerBase
    {
        /// <summary>
        /// Objeto _generoRepository que irá receber todos os métodos definidos na interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _generoRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public GenerosController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros e um status code</returns>
        /// http://localhost:5000/api/generos
        /// o usuário precisa estar logado para listar todos os gêneros
        // [Authorize] // verifica se o usuário está logado
        [HttpGet]
        public IActionResult Get()
        {
            // Cria uma lista nomeada listaGeneros para receber os dados
            List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

            // Retorna o status code 200 (Ok) com a lista de gêneros no formato JSON
            return Ok(listaGeneros);
        }

        /// <summary>
        /// Busca um gênero através do seu id
        /// </summary>
        /// <param name="id">id do gênero que será buscado</param>
        /// <returns>Um gênero buscado ou NotFound caso nenhum gênero seja encontrado</returns>
        /// http://localhost:5000/api/generos/1
        /// somente o usuário administrador pode buscar um gênero pelo id
        [Authorize(Roles = "administrador")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            // Verifica se nenhum gênero foi encontrado
            if (generoBuscado == null)
            {
                // Caso não seja encontrado, retorna um status code 404 - Not Found com a mensagem personalizada
                return NotFound("Nenhum gênero encontrado!");
            }

            // Caso seja encontrado, retorna o gênero buscado com um status code 200 - Ok
            return Ok(generoBuscado);
        }

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <returns>Um status code 201 - Created</returns>
        /// http://localhost:5000/api/generos
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            // Faz a chamada para o método .Cadastrar()
            _generoRepository.Cadastrar(novoGenero);

            // Retorna um status code 201 - Created
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um gênero existente passando o seu id pela url da requisição
        /// </summary>
        /// <param name="id">id do gênero que será atualizado</param>
        /// <param name="generoAtualizado">Objeto generoAtualizado com as novas informações</param>
        /// <returns>Um status code</returns>
        /// http://localhost:5000/api/generos/3
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, GeneroDomain generoAtualizado)
        {
            // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
            // e um bool para apresentar que houve erro
            if (generoBuscado == null)
            {
                return NotFound
                    ( 
                        new 
                        { 
                            mensagem = "Gênero não encontrado!",
                            erro = true
                        }
                    );
            }

            // Tenta atualizar o registro
            try
            {
                // Faz a chamada para o método .AtualizarIdUrl()
                _generoRepository.AtualizarIdUrl(id, generoAtualizado);

                // Retorna um status code 204 - No Content
                return NoContent();
            }
            // Caso ocorra algum erro
            catch (Exception codErro)
            {
                // Retorna um status code 400 - BadRequest e o código do erro
                return BadRequest(codErro);
            }
        }

        /// <summary>
        /// Atualiza um gênero existente passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="generoAtualizado">Objeto generoAtualizado com as novas informações</param>
        /// <returns>Um status code</returns>
        [HttpPut]
        public IActionResult PutIdBody(GeneroDomain generoAtualizado)
        {
            // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(generoAtualizado.idGenero);

            // Verifica se algum gênero foi encontrado
            if (generoBuscado != null)
            {
                // Tenta atualizar o registro
                try
                {
                    // Faz a chamada para o método .AtualizarIdCorpo()
                    _generoRepository.AtualizarIdCorpo(generoAtualizado);

                    // Retorna um status code 204 - No Content
                    return NoContent();
                }
                // Caso ocorra algum erro
                catch (Exception codErro)
                {
                    // Retorna BadRequest com o código do erro
                    return BadRequest(codErro);
                }
            }

            // Caso não seja encontrado, retorna NotFoun com uma mensagem personalizada
            return NotFound
                (
                    new
                    {
                        mensagem = "Gênero não encontrado!"
                    }
                );
        }

        /// <summary>
        /// Deleta um gênero existente
        /// </summary>
        /// <param name="id">id do gênero que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// http://localhost:5000/api/generos/11
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método .Deletar()
            _generoRepository.Deletar(id);

            // Retorna um status code 204 - No Content
            return StatusCode(204);
        }
    }
}
