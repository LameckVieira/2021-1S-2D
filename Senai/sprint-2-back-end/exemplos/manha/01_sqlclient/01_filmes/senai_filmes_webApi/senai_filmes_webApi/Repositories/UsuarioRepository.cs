using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using System;
using System.Data.SqlClient;

namespace senai_filmes_webApi.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos usuários
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-SP7RV1S\\SQLEXPRESS; initial catalog=Filmes; user Id=sa; pwd=senai@132";

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">email do usuário</param>
        /// <param name="senha">senha do usuário</param>
        /// <returns>Um objeto do tipo UsuarioDomain que foi buscado</returns>
        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            // Define a conexão con passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Define o comando a ser executado no banco de dados
                string querySelect = "SELECT idUsuario, email, senha, permissao FROM Usuarios WHERE email = @email AND senha = @senha;";

                // Define o comando cmd passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    // Define os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando e armazena os dados no objeto rdr
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // Caso dados tenham sido obtidos
                    if (rdr.Read())
                    {
                        // Cria um objeto do tipo UsuarioDomain
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {
                            // Atribui às propriedades os valores das colunas do banco de dados
                            idUsuario   = Convert.ToInt32(rdr["idUsuario"]),
                            email       = rdr["email"].ToString(),
                            senha       = rdr["senha"].ToString(),
                            permissao   = rdr["permissao"].ToString()
                        };

                        // Retorna o usuário buscado
                        return usuarioBuscado;
                    }

                    // Caso não encontre um email e senha correspondente, retorna null
                    return null;
                }
            }
        }
    }
}
