using senai_filmes_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório GeneroRepository
    /// </summary>
    public interface IGeneroRepository
    {
        // TipoRetorno NomeMetodo(TipoParametro NomeParametro);
        // void Cadastrar();

        /// <summary>
        /// Retorna todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros</returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Busca um gênero através do seu id
        /// </summary>
        /// <param name="id">id do gênero que será buscado</param>
        /// <returns>Um objeto do tipo GeneroDomain que foi buscado</returns>
        GeneroDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto novoGenero que será cadastrado</param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Atualiza um gênero existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto genero com as novas informações</param>
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualiza um gênero existente passando o id pela url da requisição
        /// </summary>
        /// <param name="id">id do gênero que será atualizado</param>
        /// <param name="genero">Objeto genero com as novas informações</param>
        void AtualizarIdUrl(int id, GeneroDomain genero);

        /// <summary>
        /// Deleta um gênero
        /// </summary>
        /// <param name="id">id do gênero que será deletado</param>
        void Deletar(int id);
    }
}
