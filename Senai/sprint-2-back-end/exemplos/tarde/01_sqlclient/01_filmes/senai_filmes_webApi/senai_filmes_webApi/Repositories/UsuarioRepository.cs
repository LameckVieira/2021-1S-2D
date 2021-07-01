using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using System;
using System.Data.SqlClient;

namespace senai_filmes_webApi.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório de usuários
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        // Define a string de conexão
        private string stringConexao = "Data Source=DESKTOP-SP7RV1S\\SQLEXPRESS; initial catalog=Filmes; user Id=sa; pwd=senai@132";

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">e-mail do usuário</param>
        /// <param name="senha">senha do usuário</param>
        /// <returns>Um objeto do tipo UsuarioDomain que foi buscado</returns>
        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            // Define a conexão con passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Define a query a ser executada no banco de dados
                string querySelect = "SELECT idUsuario, email, senha, permissao FROM Usuarios WHERE email = @email AND senha = @senha;";

                // Define o comando passando a query e a conexão como parâmetros
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
                        // Cria um objeto usuarioBuscado
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {
                            // Atribui às propriedades os valores das colunas
                            idUsuario       = Convert.ToInt32(rdr["idUsuario"]),
                            email           = rdr["email"].ToString(),
                            senha           = rdr["senha"].ToString(),
                            permissao       = rdr["permissao"].ToString()
                        };

                        // Retorna o objeto usuarioBuscado
                        return usuarioBuscado;
                    }

                    // Caso não encontre um e-mail e senha correspondentes, retorna null
                    return null;
                }
            }
        }
    }
}
