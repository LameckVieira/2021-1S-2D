using senai_gufi_webApi.Domains;
using System.Collections.Generic;

namespace senai_gufi_webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo PresencaRepository
    /// </summary>
    interface IPresencaRepository
    {
        /// <summary>
        /// Lista todas as presenças
        /// </summary>
        /// <returns>Uma lista de presenças</returns>
        List<Presenca> Listar();

        /// <summary>
        /// Busca um presença através do ID
        /// </summary>
        /// <param name="id">ID da presença que será buscada</param>
        /// <returns>Uma presença buscada</returns>
        Presenca BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova presença
        /// </summary>
        /// <param name="novaPresenca">Objeto novaPresenca que será cadastrado</param>
        void Cadastrar(Presenca novaPresenca);

        /// <summary>
        /// Atualiza uma presença existente
        /// </summary>
        /// <param name="id">ID da presença que será buscada</param>
        /// <param name="presencaAtualizada">Objeto com as novas informações</param>
        void Atualizar(int id, Presenca presencaAtualizada);

        /// <summary>
        /// Deleta uma presença existente
        /// </summary>
        /// <param name="id">ID da presença que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Lista todos os eventos que um determinado usuário participa
        /// </summary>
        /// <param name="id">ID do usuário que participa dos eventos listados</param>
        /// <returns>Uma lista de presenças com os dados dos eventos</returns>
        List<Presenca> ListarMinhas(int id);

        /// <summary>
        /// Cria uma nova presença
        /// </summary>
        /// <param name="inscricao">Objeto com as informações da inscrição</param>
        void Inscrever(Presenca inscricao);

        /// <summary>
        /// Altera o status de uma presença
        /// </summary>
        /// <param name="id">ID da presença que terá a situação alterada</param>
        /// <param name="status">Parâmetro que atualiza o situação da presença para 1 - Confirmada, 2 - Não confirmada ou 0 - Recusada</param>
        void AprovarRecusar(int id, string status);
    }
}
