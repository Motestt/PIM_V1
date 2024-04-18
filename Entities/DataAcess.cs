using Dapper;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;



namespace Fazenda01.Entities
{
    public class DataAcess
    {

        //atributos
        private string Username;
        private string Password;

        //construtor
        public DataAcess(string username, string password)
        {
            Username = username;
            Password = password;
        }

        //Salvar Dados
        public void SaveData(string username, string password)
        {
            //string de conexão
            string connstring = @"Server=DESKTOP-O4HMF4G\SQLSERVER;Database=FazendaDB;Trusted_Connection=True;";

            //logica de acesso
            using (SqlConnection connection = new SqlConnection(connstring))
            {
                // Abrindo a conexão
                connection.Open();

                // Comando SQL para inserir dados
                string sql = "INSERT INTO usuario(username, password) VALUES(@username, @password)";

                // Criando o comando com parâmetros
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    // Adicionando os valores aos parâmetros
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    // Executando o comando
                    int rowsAffected = cmd.ExecuteNonQuery();


                }

                connection.Close();

            }


        }

        //classe que valida senha do usuario
        public string Validator(string username, string password)
        {
            //conexão               
            
            //string com validaçao sql
            string connstring = @"Server=DESKTOP-O4HMF4G\SQLSERVER;Database=FazendaDB;User Id=joao;Password=.tjgl55.b;Trusted_Connection=True;";
            //string com autenticação windows
            string connstring2 = @"Server=DESKTOP-O4HMF4G\SQLSERVER;Database=FazendaDB;Trusted_Connection=True;";

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connstring;

            conn.Open();

            //Comando SQL

            string sql = "SELECT password FROM usuario WHERE username = @username";

            SqlCommand cmd = new SqlCommand(sql, conn);

            // Adiciona parametros a variavel "cmd"

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);


            // leitura do usuario e retorno da senha
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();

            string TestPass = reader["password"].ToString();

            //testa se o imput é igual ao do DB por meio do .Equals();
            bool saoIguais = TestPass.Equals(password, StringComparison.Ordinal);

            //retorna a condição do login
            conn.Close();
            if (saoIguais)
            {

                return "senha correta!";
            }
            else
            {

                return "senha incorreta";

            }

        }

        //metodo que adiciona produtos ao DB, com string sql de parametro
        public void AddProduto(string sql)
        {
            //string de conexao e logica
            string connstring = @"Server=DESKTOP-O4HMF4G\SQLSERVER;Database=FazendaDB;Trusted_Connection=True;";

            SqlConnection connection = new SqlConnection(connstring);

            // Abrindo a conexão
            connection.Open();
   
            // Criando o comando com parâmetros
            SqlCommand cmd = new SqlCommand(sql, connection);

            // Executando o comando
            int rowsAffected = cmd.ExecuteNonQuery();
           
            connection.Close();











        }

        
    }

}