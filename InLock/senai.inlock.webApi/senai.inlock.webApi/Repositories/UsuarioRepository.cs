using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source = DESKTOP-0KGDOK7; initial Catalog = InLock_Games_Manha;user id = sa; pwd = senai@123";
        public void Atualizar(int id, Usuario UsuarioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdate = "UPDATE Usuario SET senha = @senha WHERE idUsuario = @Id";
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@senha", UsuarioAtualizado.senha);
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        
        }

        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelect = "SELECT * FROM Usuario WHERE email = @email AND senha = @senha";
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        Usuario usuarioBuscado = new Usuario
                        {
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),
                            email = rdr["email"].ToString(),
                            senha = rdr["senha"].ToString()
                        };
                        return usuarioBuscado;
                    }
                    return null;
                }
            }
        }

        public Usuario BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectById = "SELECT * FROM Usuario WHERE idUsuario =@Id";
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        Usuario usuarioBuscado = new Usuario
                        {
                            idUsuario = Convert.ToInt32(rdr["idEstudio"]),
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),
                            email = rdr["email"].ToString(),
                            senha = rdr["email"].ToString()
                        };
                        return usuarioBuscado;
                    }
                    return null;
                }
            }
        }
        public void Cadastrar(Usuario novoUsuario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Usuario(idTipoUsuario,email,senha) VALUES (@idTipoUsuario, @email, @senha)";
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdtipoUsuario", novoUsuario.idTipoUsuario);
                    cmd.Parameters.AddWithValue("@email", novoUsuario.email);
                    cmd.Parameters.AddWithValue("@senha", novoUsuario.senha);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Usuario WHERE idUsuario = @Id";
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Usuario> ListarTodos()
        {
            List<Usuario> usuario = new List<Usuario>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT * FROM Usuario";
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Usuario usuario1 = new Usuario()
                        {
                            idUsuario = Convert.ToInt32(rdr["idEstudio"]),
                            email = rdr["email"].ToString()
                        };
                        usuario.Add(usuario1);
                    }
                    return usuario;
                }
            }
        }
    }
}
