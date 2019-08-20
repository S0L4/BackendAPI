using Senai.Sstop.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.WebApi.Repositories
{
    public class EstiloRepository
    {

        // aonde q sera feita essa comunicacao
        private string StringConexao = "Data Source=.\\SqlExpress; Initial Catalog=T_Sstop; User Id=sa; Pwd=132";

        public List<EstiloDomain> Listar()
        {
            // buscar os dados de banco de dados
            List<EstiloDomain> estilos = new List<EstiloDomain>();

            // chamar o banco
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // nossa query a ser executada
                string Query = "SELECT IdEst, Nome FROM EstilosMusicais";

                // abrir conexao
                con.Open();

                // declaro para pecorrer a lista
                SqlDataReader sdr;

                // comando a ser executado em qual conexao
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    // pegar os comandos da tabela do banco e armazenar dentro da aplicacao do bakend
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        EstiloDomain estilo = new EstiloDomain
                        {
                            IdEstilo = Convert.ToInt32(sdr["IdEst"]),
                            Nome = sdr["Nome"].ToString()
                        };
                        estilos.Add(estilo);
                    }
                }
            }
            // executar o select
            // retornar as informacoes
            return estilos;
        }

        public EstiloDomain BuscarPorId(int id)
        {
            string Query = "SELECT IdEst, Nome FROM EstilosMusicais WHERE IdEst = @Id";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            EstiloDomain estilo = new EstiloDomain
                            {
                                IdEstilo = Convert.ToInt32(sdr["IdEst"]),
                                Nome = sdr["Nome"].ToString()
                            };
                            return estilo;
                        }
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(EstiloDomain estiloDomain)
        {
            string Query = "INSERT INTO EstilosMusicais (Nome) VALUES (@Nome)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", estiloDomain.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public void Deletar(int id)
        {
            string Query = "DELETE FROM EstilosMusicais WHERE IdEst = @Id";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))      
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(EstiloDomain estiloDomain)
        {
            string Query = "UPDATE EstilosMusicais SET Nome = @Nome WHERE IdEst = @Id";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", estiloDomain.Nome);
                    cmd.Parameters.AddWithValue("@Id", estiloDomain.IdEstilo);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
