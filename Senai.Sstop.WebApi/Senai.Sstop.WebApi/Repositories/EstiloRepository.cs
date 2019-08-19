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
    }
}
