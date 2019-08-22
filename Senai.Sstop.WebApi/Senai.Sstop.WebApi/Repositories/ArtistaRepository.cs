using Senai.Sstop.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.WebApi.Repositories
{
    public class ArtistaRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; Initial Catalog=T_Sstop; User Id=sa; Pwd=132";

        public List<ArtistaDomain> Listar()
        {
            List<ArtistaDomain> artistas = new List<ArtistaDomain>();

            string Query = "SELECT A.IdArt, A.Nome, E.IdEst, E.Nome AS NomeEstilo " +
                "FROM Artistas A INNER JOIN EstilosMusicais E ON A.IdEst = E.IdEst";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        ArtistaDomain artista = new ArtistaDomain
                        {
                            IdArtista = Convert.ToInt32(sdr["IdArt"]),
                            Nome = sdr["Nome"].ToString(),
                            Estilo = new EstiloDomain
                            {
                                IdEstilo = Convert.ToInt32(sdr["IdEst"]),
                                Nome = sdr["NomeEstilo"].ToString(),
                            }
                        };
                        artistas.Add(artista);
                    }
                }
            }
            return artistas;
        }

        public void Cadastrar(ArtistaDomain artistaDomain)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "INSERT INTO Artistas(Nome, IdEst) VALUES(@Nome, @IdEst)";

                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@Nome", artistaDomain.Nome);
                cmd.Parameters.AddWithValue("@IdEst", artistaDomain.EstiloId);
                con.Open();
                cmd.ExecuteNonQuery();                        
            }
        }
    }
}
