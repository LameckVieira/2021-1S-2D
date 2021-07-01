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

        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
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
                                   // INSERT INTO Generos(Nome) VALUES('Aventura');
                string queryInsert = "INSERT INTO Generos(Nome) VALUES('" + novoGenero.nome + "')";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
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
