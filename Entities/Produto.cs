using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda01.Entities
{
    public class Produto
    {

        //atributos
        private string Nome_Produto;
        private double Valor_Produto;
        private int Quantidade_Produto;

        public Produto() { }

        //construtor
        public Produto(string nome_produto, double valor_produto, int quantidade_produto)
        {
            Nome_Produto = nome_produto;
            Valor_Produto = valor_produto;
            Quantidade_Produto = quantidade_produto;
        }

        //add produto
        public string AdicionarProduto(Produto produto)
        {
            string connstring = @"Server=DESKTOP-O4HMF4G\SQLSERVER;Database=FazendaDB;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connstring))
            {
                connection.Open();

                string sql = "INSERT INTO tb_Produto(nm_Produto, vl_Produto, qt_Produto) VALUES(@nome, @valor, @quantidade)";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@nome", produto.Nome_Produto);
                    cmd.Parameters.AddWithValue("@valor", produto.Valor_Produto);
                    cmd.Parameters.AddWithValue("@quantidade", produto.Quantidade_Produto);

                    int rowsAffected = cmd.ExecuteNonQuery();
                }

                return "Produto adicionado!";
            }
        }

        //remover produto

        public string RemoverProduto(string nome_produto)
        {
            string connstring = @"Server=DESKTOP-O4HMF4G\SQLSERVER;Database=FazendaDB;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connstring))
            {
                connection.Open();

                string sql = "DELETE FROM tb_Produto WHERE nm_Produto = @nome";


                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@nome", nome_produto);
                    // cmd.Parameters.AddWithValue("@valor", valor_produto);


                    int rowsAffected = cmd.ExecuteNonQuery();
                }

                return "Produto adicionado!";

            }

        }
        //pesquisar produto
        public string PesquisarProduto(string nome_produto)
        {
            string connstring = @"Server=DESKTOP-O4HMF4G\SQLSERVER;Database=FazendaDB;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connstring))
            {
                connection.Open();

                string sql = "SELECT * FROM tb_Produto WHERE nm_Produto = @nome";

                //parametros
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@nome", nome_produto);
                 


                    int rowsAffected = cmd.ExecuteNonQuery();

                    //Reader 
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string nome = reader.GetString(1);
                            decimal valor = reader.GetDecimal(2);
                            int quantidade = reader.GetInt32(3);

                            return $"Nome: {nome.Trim()}, Valor: {valor}, Quantidade: {quantidade}";
                        }
                        else
                        {
                            return "Produto não encontrado!";
                        }
                    }
                }
                



            }



        }
    }
}


