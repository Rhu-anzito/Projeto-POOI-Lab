using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class DisciplinaRepository
    {
        private readonly string _connection;

        public DisciplinaRepository()
        {
            var conn = ConfigurationManager.ConnectionStrings["DEV"]?.ConnectionString;

            if (string.IsNullOrEmpty(conn))
                throw new Exception("Connection string 'DEV' não encontrada.");

            _connection = conn;
        }

        public bool Salvar(Disciplina disciplina)
        {
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                conn.Open();

                string query = "INSERT INTO dbo.Disciplina (Codigo, Nome, CargaHoraria) VALUES (@Codigo, @Nome, @CargaHoraria)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = disciplina.Codigo;
                    cmd.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = disciplina.Nome;
                    cmd.Parameters.Add("@CargaHoraria", SqlDbType.Int).Value = disciplina.CargaHoraria;

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Atualizar(Disciplina disciplina)
        {
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                conn.Open();

                string query = "UPDATE dbo.Disciplina SET Codigo = @Codigo, Nome = @Nome, CargaHoraria = @CargaHoraria WHERE DisciplinaId = @DisciplinaId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@DisciplinaId", SqlDbType.Int).Value = disciplina.DisciplinaId;
                    cmd.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = disciplina.Codigo;
                    cmd.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = disciplina.Nome;
                    cmd.Parameters.Add("@CargaHoraria", SqlDbType.Int).Value = disciplina.CargaHoraria;

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Excluir(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                conn.Open();

                string query = "DELETE FROM dbo.Disciplina WHERE DisciplinaId = @DisciplinaId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@DisciplinaId", SqlDbType.Int).Value = id;

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Disciplina> Listar()
        {
            List<Disciplina> disciplinas = new List<Disciplina>();

            using (SqlConnection conn = new SqlConnection(_connection))
            {
                conn.Open();

                string query = "SELECT DisciplinaId, Codigo, Nome, CargaHoraria FROM dbo.Disciplina";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Disciplina disciplina = new Disciplina
                        {
                            DisciplinaId = Convert.ToInt32(reader["DisciplinaId"]),
                            Codigo = reader["Codigo"].ToString(),
                            Nome = reader["Nome"].ToString(),
                            CargaHoraria = Convert.ToInt32(reader["CargaHoraria"])
                        };

                        disciplinas.Add(disciplina);
                    }
                }
            }

            return disciplinas;
        }
    }
}