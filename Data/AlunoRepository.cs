using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class AlunoRepository
    {
        private readonly string _connection;

        public AlunoRepository()
        {
            var conn = ConfigurationManager.ConnectionStrings["DEV"]?.ConnectionString;

            if (string.IsNullOrEmpty(conn))
                throw new Exception("Connection string 'DEV' não encontrada.");

            _connection = conn;
        }

        public bool Salvar(Aluno aluno)
        {
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                conn.Open();

                string query = "INSERT INTO dbo.Aluno (Nome, Email, DataNascimento) VALUES (@Nome, @Email, @DataNascimento)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = aluno.Nome;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = aluno.Email;
                    cmd.Parameters.Add("@DataNascimento", SqlDbType.Date).Value = aluno.DataNascimento;

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Atualizar(Aluno aluno)
        {
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                conn.Open();

                string query = "UPDATE dbo.Aluno SET Nome = @Nome, Email = @Email, DataNascimento = @DataNascimento WHERE AlunoId = @AlunoId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@AlunoId", SqlDbType.Int).Value = aluno.AlunoId;
                    cmd.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = aluno.Nome;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = aluno.Email;
                    cmd.Parameters.Add("@DataNascimento", SqlDbType.Date).Value = aluno.DataNascimento;

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Excluir(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                conn.Open();

                string query = "DELETE FROM dbo.Aluno WHERE AlunoId = @AlunoId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@AlunoId", SqlDbType.Int).Value = id;

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Aluno> Listar()
        {
            List<Aluno> alunos = new List<Aluno>();

            using (SqlConnection conn = new SqlConnection(_connection))
            {
                conn.Open();

                string query = "SELECT AlunoId, Nome, Email, DataNascimento FROM dbo.Aluno";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Aluno aluno = new Aluno
                        {
                            AlunoId = Convert.ToInt32(reader["AlunoId"]),
                            Nome = reader["Nome"].ToString(),
                            Email = reader["Email"].ToString(),
                            DataNascimento = Convert.ToDateTime(reader["DataNascimento"])
                        };

                        alunos.Add(aluno);
                    }
                }
            }

            return alunos;
        }
    }
}