using Senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repositories
{
    public class GeneroRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; Initial Catalog=T_Filmes; User Id=sa; Pwd=132";
        List<GeneroDomain> generos = new List<GeneroDomain>();

        public List<GeneroDomain> Listar()
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;
                string Query = "SELECT IdGenero, Nome FROM Generos";

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                            Nome = sdr["Nome"].ToString()
                        };
                        generos.Add(genero);
                    }
                }
            }
            return generos;
        }

        public void Cadastrar(GeneroDomain generoDomain)
        {
            string Query = "INSERT INTO Generos (Nome) VALUES (@Nome)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@Nome", generoDomain.Nome);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(GeneroDomain generoDomain)
        {
            string Query = "UPDATE Generos SET Nome = @Nome WHERE IdGenero = @Id";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@Nome", generoDomain.Nome);
                    cmd.Parameters.AddWithValue("@Id", generoDomain.IdGenero);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            string Query = "DELETE FROM Generos WHERE IdGenero = @Id";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
