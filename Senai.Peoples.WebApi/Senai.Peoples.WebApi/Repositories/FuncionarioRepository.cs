using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionarioRepository
    {
        private string ConexaoBD = "Data Source=.\\SqlExpress; Initial Catalog= T_Peoples; User Id= sa; Pwd= 132";

        List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();
        SqlDataReader leitura;

        public List<FuncionarioDomain> Listar()
        {
            using (SqlConnection con = new SqlConnection(ConexaoBD))
            {
                con.Open();
                string Query = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios";
                
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    leitura = cmd.ExecuteReader();

                    while (leitura.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(leitura["IdFuncionario"]),
                            Nome = leitura["Nome"].ToString(),
                            Sobrenome = leitura["Sobrenome"].ToString()
                        };
                        funcionarios.Add(funcionario);
                    }
                }
            }
            return funcionarios;
        }

        public FuncionarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(ConexaoBD))
            {
                con.Open();
                string Query = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios WHERE IdFuncionario = @Id";

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    leitura = cmd.ExecuteReader();

                    if (leitura.HasRows)
                    {
                        while (leitura.Read())
                        {
                            FuncionarioDomain funcionario = new FuncionarioDomain
                            {
                                IdFuncionario = Convert.ToInt32(leitura["IdFuncionario"]),
                                Nome = leitura["Nome"].ToString(),
                                Sobrenome = leitura["Sobrenome"].ToString()
                            };
                            return funcionario;
                        }
                    }
                    return null;
                }
            }
        }

        public void Inserir(FuncionarioDomain funcionarioDomain)
        {
            string Query = "INSERT INTO Funcionarios (Nome, Sobrenome) VALUES (@Nome, @Sobrenome)";
            using (SqlConnection con = new SqlConnection(ConexaoBD))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", funcionarioDomain.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionarioDomain.Sobrenome);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            string Query = "DELETE FROM Funcionarios WHERE IdFuncionario = @Id";
            using (SqlConnection con = new SqlConnection(ConexaoBD))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(FuncionarioDomain funcionarioDomain)
        {
            string Query = "UPDATE Funcionarios SET Nome = @Nome, Sobrenome = @Sobrenome WHERE IdFuncionario = @Id";
            using (SqlConnection con = new SqlConnection(ConexaoBD))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", funcionarioDomain.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionarioDomain.Sobrenome);
                    cmd.Parameters.AddWithValue("@Id", funcionarioDomain.IdFuncionario);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
