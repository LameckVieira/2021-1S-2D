using senai_filmes_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório FilmeRepository
    /// </summary>
    public interface IFilmeRepository
    {
        // TipoRetorno NomeMetodo(TipoParametro NomeParametro);
        // void Cadastrar();

        /// <summary>
        /// Retorna todos os filmes
        /// </summary>
        /// <returns>Uma lista de filmes</returns>
        List<FilmeDomain> ListarTodos();

        /// <summary>
        /// Busca um filme através do seu id
        /// </summary>
        /// <param name="id">id do filme que será buscado</param>
        /// <returns>Um objeto do tipo FilmeDomain que foi buscado</returns>
        FilmeDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoFilme">Objeto novoFilme que será cadastrado</param>
        void Cadastrar(FilmeDomain novoFilme);

        /// <summary>
        /// Atualiza um filme existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="filme">Objeto filme com as novas informações</param>
        void AtualizarIdCorpo(FilmeDomain filme);

        /// <summary>
        /// Atualiza um filme existente passando o id pela url da requisição
        /// </summary>
        /// <param name="id">id do filme que será atualizado</param>
        /// <param name="filme">Objeto filme com as novas informações</param>
        void AtualizarIdUrl(int id, FilmeDomain filme);

        /// <summary>
        /// Deleta um filme
        /// </summary>
        /// <param name="id">id do filme que será deletado</param>
        void Deletar(int id);
    }
}
