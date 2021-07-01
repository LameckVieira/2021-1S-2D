using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos gêneros
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// Data Source = Nome do servidor
        /// initial catalog = Nome do banco de dados
        /// user Id=sa; pwd=senai@132 = Faz a autenticação com o usuário do SQL Server, passando o logon e a senha
        /// integrated security=true = Faz a autenticação com o usuário do sistema (Windows)
        /// </summary>
        private string stringConexao = "Data Source=DESKTOP-SP7RV1S\\SQLEXPRESS; initial catalog=Filmes; user Id=sa; pwd=senai@132";
        //private string stringConexao = "Data Source=DESKTOP-SP7RV1S\\SQLEXPRESS; initial catalog=Filmes; integrated security=true";

        /// <summary>
        /// Atualiza um gênero passando o id pelo corpo
        /// </summary>
        /// <param name="genero">Objeto genero com as novas informações</param>
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string queryUpdateIdBody = "UPDATE Generos SET Nome = @Nome WHERE idGenero = @ID";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                {
                    // Passa os valores para os parâmetros
                    cmd.Parameters.AddWithValue("@Nome", genero.nome);
                    cmd.Parameters.AddWithValue("@ID", genero.idGenero);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Atualiza um gênero passando o id pelo recurso (URL)
        /// </summary>
        /// <param name="id">id do gênero que será atualizado</param>
        /// <param name="genero">Objeto genero com as novas informações</param>
        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string queryUpdateIdUrl = "UPDATE Generos SET Nome = @Nome WHERE idGenero = @ID";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {
                    // Passa os valores para os parâmetros
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", genero.nome);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca um gênero através do seu id
        /// </summary>
        /// <param name="id">id do gênero que será buscado</param>
        /// <returns>Um gênero buscado ou null caso não seja encontrado</returns>
        public GeneroDomain BuscarPorId(int id)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string querySelectById = "SELECT idGenero, Nome FROM Generos WHERE idGenero = @ID";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader rdr para receber os valores do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Passa o valor para o parâmetro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Verifica se o resultado da query retornou algum registro
                    if (rdr.Read())
                    {
                        // Se sim, instancia um novo objeto generoBuscado do tipo GeneroDomain
                        GeneroDomain generoBuscado = new GeneroDomain()
                        {
                            // Atribui à propriedade idGenero o valor da coluna "idGenero" da tabela do banco de dados
                            idGenero = Convert.ToInt32(rdr["idGenero"]),

                            // Atribui à propriedade nome o valor da coluna "Nome" da tabela do banco de dados
                            nome = rdr["Nome"].ToString()
                        };

                        // Retorna o generoBuscado com os dados obtidos
                        return generoBuscado;
                    }

                    // Se não, retorna null
                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto novoGenero com as informações que serão cadastradas</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                                      // INSERT INTO Generos(Nome) VALUES('Ficção Científica');
                                      // INSERT INTO Generos(Nome) VALUES('Joana D'Arc');
                                      // INSERT INTO Generos(Nome) VALUES('')DROP TABLE Filmes--');
                // string queryInsert = "INSERT INTO Generos(Nome) VALUES('" + novoGenero.nome + "')";
                // Não usar dessa forma pois pode causar o efeito Joana D'Arc
                // Além de permitir SQL Injection
                // Por exemplo
                // "nome" : "')DROP TABLE Filmes--"
                // Ao tentar cadastrar o comando acima, irá deletar a tabela Filmes do banco de dados
                // https://www.devmedia.com.br/sql-injection/6102

                // Declara a query que será executada
                string queryInsert = "INSERT INTO Generos(Nome) VALUES(@Nome)";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor para o parâmetro @Nome
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.nome);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um gênero através do seu id
        /// </summary>
        /// <param name="id">id do gênero que será deletado</param>
        public void Deletar(int id)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada passando o valor como parâmetro
                string queryDelete = "DELETE FROM Generos WHERE idGenero = @ID";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // Define o valor do id recebido no método como o valor do parâmetro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros</returns>
        public List<GeneroDomain> ListarTodos()
        {
            // Cria uma lista listaGeneros onde serão armazenados os dados
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT idGenero, Nome FROM Generos";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        // Instacia um objeto genero do tipo GeneroDomain
                        GeneroDomain genero = new GeneroDomain()
                        {
                            // Atribui à propriedade idGenero o valor da primeira coluna da tabela do banco de dados
                            idGenero = Convert.ToInt32(rdr[0]),

                            // Atribui à propriedade nome o valor da segunda coluna da tabela do banco de dados
                            nome = rdr[1].ToString()
                        };

                        // Adiciona o objeto genero à lista listaGeneros
                        listaGeneros.Add(genero);
                    }
                }
            }

            // Retorna a lista de gêneros
            return listaGeneros;
        }
    }
}
