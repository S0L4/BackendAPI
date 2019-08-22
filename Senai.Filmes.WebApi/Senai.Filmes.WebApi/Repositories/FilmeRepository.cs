using Senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repositories
{
    public class FilmeRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; Initial Catalog=T_Filmes; User Id=sa; Pwd=132";
        List<FilmeDomain> filmes = new List<FilmeDomain>();

        public List<FilmeDomain> Listar()
        {
            string Query = "SELECT F.IdFilme, F.Titulo, G.IdGenero, G.Nome" +
                "FROM Filmes F JOIN Generos G ON F.IdGenero = G.IdGenero ";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain {
                            IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                            Titulo = sdr["Titulo"].ToString(),
                            Genero = new GeneroDomain
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Nome = sdr["Nome"].ToString(),
                            }
                        };
                        filmes.Add(filme);
                    }
                }
            }
            return filmes;
        }

        public FilmeDomain BuscarPorId(int id)
        {
            string Query = "SELECT F.IdFilme, F.Titulo, G.IdGenero, G.Nome " +
                "FROM Filmes F JOIN Generos G ON F.IdGenero = G.IdGenero WHERE IdFilme = @Id";

            FilmeDomain filmeDomain = new FilmeDomain();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@Id", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FilmeDomain filme = new FilmeDomain
                            {
                                IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                                Titulo = sdr["Titulo"].ToString(),
                                Genero = new GeneroDomain
                                {
                                    IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                    Nome = sdr["Nome"].ToString(),
                                }
                            };
                            return filme;
                        }
                    }
                    return null;
                }
            }
        }

        public void Atualizar(FilmeDomain filmeDomain)
        {
            string Query "UPDATE Filmes SET Titulo = @Titulo WHERE IdGenero = @Id"
        }
    }
}
