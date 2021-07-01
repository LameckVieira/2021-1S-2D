using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class JogosRepository : IJogosRepository
    {
        private string StringConexao = "Data Source = DESKTOP-0KGDOK7; initial Catalog = InLock_Games_Manha;user id = sa; pwd = senai@123";

        public void Atualizar(int id, Jogos jogoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateIdBody = "UPDATE Jogos SET valor = @valor WHERE idJogo = @Id";
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                {
                    cmd.Parameters.AddWithValue("@valor", jogoAtualizado.valor);
                    
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Jogos BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelect = "SELECT * FROM Jogos WHERE IdJogo = @id ";
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@id",id);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        Jogos jogoBuscado = new Jogos
                        {
                            idJogo = Convert.ToInt32(rdr["idJogo"]),
                            idEstudio = Convert.ToInt32(rdr["idEstudio"]),
                            nomeJogo = rdr["nomeJogo"].ToString(),
                            descricao = rdr["descrição"].ToString(),
                            dataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),
                            valor = Convert.ToDecimal(rdr["Valor"])

                        };
                        return jogoBuscado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(Jogos novoJogo)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Jogos(idEstudio, nomeJogo, descricao, dataLancamento, valor) VALUES (@idTipoEstudio, @nomeJogo, @descricao, @datalancamento, @valor)";
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idEstudio", novoJogo.idEstudio);
                    cmd.Parameters.AddWithValue("@nomeJogo", novoJogo.nomeJogo);
                    cmd.Parameters.AddWithValue("@descricao", novoJogo.descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento", novoJogo.dataLancamento);
                    cmd.Parameters.AddWithValue("@valor", novoJogo.valor);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Jogos WHERE idJogo = @Id";
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Jogos> ListarTodos()
        {
            List<Jogos> jogos = new List<Jogos>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT * FROM Jogo";
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Jogos jogos1 = new Jogos()
                        {
                            idJogo = Convert.ToInt32(rdr["idJogo"]),
                            idEstudio = Convert.ToInt32(rdr["idEstudio"]),
                            nomeJogo = rdr["nomeJogo"].ToString(),
                            descricao = rdr["descrição"].ToString(),
                            dataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),
                            valor = Convert.ToDecimal(rdr["Valor"])
                        };
                        jogos.Add(jogos1);
                    }
                    return jogos;
                }
            }
        }
    }
}
