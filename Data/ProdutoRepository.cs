using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class ProdutoRepository
    {
        private readonly string _connection;

        public ProdutoRepository()
        {
            var conn = ConfigurationManager.ConnectionStrings["DEV"]?.ConnectionString;

            if (string.IsNullOrEmpty(conn))
                throw new Exception("Connection string 'DEV' não encontrada.");

            _connection = conn;
        }

        public ProdutoRepository(string connection)
        {
            _connection = connection;
        }

        public bool Salvar(Produto produto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connection))
                {
                    conn.Open();

                    string query = "INSERT INTO dbo.TB_Produto (nome, preco) VALUES (@Nome, @Preco)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@Nome", SqlDbType.VarChar).Value = produto.Nome;
                        cmd.Parameters.Add("@Preco", SqlDbType.Decimal).Value = produto.Preco;

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar produto", ex);
            }
        }

        public bool Atualizar(Produto produto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connection))
                {
                    conn.Open();

                    string query = "UPDATE dbo.TB_Produto SET nome = @Nome, preco = @Preco WHERE id = @Id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = produto.Id;
                        cmd.Parameters.Add("@Nome", SqlDbType.VarChar).Value = produto.Nome;
                        cmd.Parameters.Add("@Preco", SqlDbType.Decimal).Value = produto.Preco;

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar produto", ex);
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connection))
                {
                    conn.Open();

                    string query = "DELETE FROM dbo.TB_Produto WHERE id = @Id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir produto", ex);
            }
        }

        public List<Produto> Listar()
        {
            List<Produto> produtos = new List<Produto>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connection))
                {
                    conn.Open();

                    string query = "SELECT id, nome, preco FROM dbo.TB_Produto";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Produto produto = new Produto
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nome = reader["nome"].ToString(),
                                Preco = Convert.ToDecimal(reader["preco"])
                            };

                            produtos.Add(produto);
                        }
                    }
                }

                return produtos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar produtos", ex);
            }
        }
    }
}