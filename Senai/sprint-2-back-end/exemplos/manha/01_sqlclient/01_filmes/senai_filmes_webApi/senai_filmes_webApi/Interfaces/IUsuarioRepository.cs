using senai_filmes_webApi.Domains;

namespace senai_filmes_webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório UsuarioRepository
    /// </summary>
    interface IUsuarioRepository
    {
        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">email do usuário</param>
        /// <param name="senha">senha do usuário</param>
        /// <returns>Um objeto do tipo UsuarioDomain que foi buscado</returns>
        UsuarioDomain BuscarPorEmailSenha(string email, string senha);
    }
}
