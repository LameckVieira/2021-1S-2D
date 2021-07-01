using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string StringConexao = "Data Source = DESKTOP-0KGDOK7; initial Catalog = InLock_Games_Manha;user id = sa; pwd = senai@123";
        public List<Estudios> ListarTodos()
        {
            List<Estudios> estudios = new List<Estudios>();
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT * FROM Estudios";
                con.Open();
                SqlDataReader rdr;
                using(SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while(rdr.Read())
                    {
                        Estudios estudios1 = new Estudios()
                        {
                            idEstudio = Convert.ToInt32(rdr["idEstudio"]),
                            nomeEstudio = rdr["nomeEstudio"].ToString()
                        };
                        estudios.Add(estudios1);
                    }
                    return estudios;
                }
            } 
        }
        public void Atualizar(int id, Estudios estudioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateIdBody = "UPDATE Estudios SET nomeEstudio = @nome WHERE idEstudio = @Id";
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                {
                    cmd.Parameters.AddWithValue("@nome", estudioAtualizado.nomeEstudio);
                    cmd.Parameters.AddWithValue("@Id", estudioAtualizado.idEstudio);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Estudios BuscarporId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectById = "SELECT * FROM Estudios WHERE idEstudio =@Id";
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        Estudios estudiobuscado = new Estudios
                        {
                            idEstudio = Convert.ToInt32(rdr["idEstudio"]),
                            nomeEstudio = rdr["nomeEstudio"].ToString()
                        };
                        return estudiobuscado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(Estudios novoEstudio)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Estudios(nomeEstudio) VALUES (@nomeEstudio)";
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeEstudio", novoEstudio.nomeEstudio);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Estudios WHERE idEstudio = @Id";
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
