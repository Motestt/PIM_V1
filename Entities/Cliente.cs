using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda01.Entities
{
    public class Cliente
    {
        //atributos
        public string Nome_Cliente { get; set; }
        public string Email_Cliente { get; set; }
        public string Endereco_Cliente { get; set; }
        public string Telefone_Cliente { get; set; }


        //construtor padrao
        public Cliente() { }

        //construtor
        public Cliente(string nome_Cliente, string email_Cliente, string endereco_Cliente, string telefone_Cliente)
        {
            Nome_Cliente = nome_Cliente;
            Email_Cliente = email_Cliente;
            Endereco_Cliente = endereco_Cliente;
            Telefone_Cliente = telefone_Cliente;
        }

        public string BuscaC()
        {
            string connstring = @"Server=DESKTOP-O4HMF4G\SQLSERVER;Database=FazendaDB;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connstring))
            {
                connection.Open();
                string sql = "SELECT * FROM tb_Cliente";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        string result = "";
                        while (reader.Read())
                        {
                            // Ajuste os índices para corresponder às colunas reais da sua tabela
                            string nome = reader.GetString(1);
                            string email = reader.GetString(2);
                            string endereco = reader.GetString(3);
                            string telefone = reader.GetString(4);

                            // Concatene os dados em uma string de resultado
                            result += $"Nome: {nome}\nEmail: {email}\nEndereço: {endereco}\nTelefone: {telefone}\n\n";
                        }
                        return result;

                    }

                }

            }
        }

    }
}













