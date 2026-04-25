using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class ProfessorRepository
    {
        private readonly string _connection;

        public ProfessorRepository()
        {
            var conn = ConfigurationManager.ConnectionStrings["DEV"]?.ConnectionString;

            if (string.IsNullOrEmpty(conn))
                throw new Exception("Connection string 'DEV' não encontrada.");

            _connection = conn;
        }

        public bool Salvar(Professor professor)
        {
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                conn.Open();

                string query = "INSERT INTO dbo.Professor (Nome, Email, Titulo) VALUES (@Nome, @Email, @Titulo)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = professor.Nome;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = professor.Email;
                    cmd.Parameters.Add("@Titulo", SqlDbType.NVarChar).Value = professor.Titulo;

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Atualizar(Professor professor)
        {
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                conn.Open();

                string query = "UPDATE dbo.Professor SET Nome = @Nome, Email = @Email, Titulo = @Titulo WHERE ProfessorId = @ProfessorId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@ProfessorId", SqlDbType.Int).Value = professor.ProfessorId;
                    cmd.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = professor.Nome;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = professor.Email;
                    cmd.Parameters.Add("@Titulo", SqlDbType.NVarChar).Value = professor.Titulo;

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Excluir(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                conn.Open();

                string query = "DELETE FROM dbo.Professor WHERE ProfessorId = @ProfessorId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@ProfessorId", SqlDbType.Int).Value = id;

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Professor> Listar()
        {
            List<Professor> professores = new List<Professor>();

            using (SqlConnection conn = new SqlConnection(_connection))
            {
                conn.Open();

                string query = "SELECT ProfessorId, Nome, Email, Titulo FROM dbo.Professor";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Professor professor = new Professor
                        {
                            ProfessorId = Convert.ToInt32(reader["ProfessorId"]),
                            Nome = reader["Nome"].ToString(),
                            Email = reader["Email"].ToString(),
                            Titulo = reader["Titulo"].ToString()
                        };

                        professores.Add(professor);
                    }
                }
            }

            return professores;
        }
    }
}