﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda01.Entities
{
    public class Cliente_J : Cliente
    {
        //atributo
        private string Cnpj_Cliente;

        //construtor
        public Cliente_J(string nome_Cliente, string email_Cliente, string endereco_Cliente, string telefone_Cliente, string cnpj_Cliente) 
        {
            Nome_Cliente = nome_Cliente;
            Email_Cliente = email_Cliente;
            Endereco_Cliente = endereco_Cliente;
            Telefone_Cliente = telefone_Cliente;
            Cnpj_Cliente = cnpj_Cliente;

        }

        //metodo para adicionar clientes
        public string AdicionarClientes(string nome_Cliente, string email_Cliente, string endereco_Cliente, string telefone_Cliente, string cnpj_Cliente)
        {
            string connstring = @"Server=DESKTOP-O4HMF4G\SQLSERVER;Database=FazendaDB;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connstring))
            {
                connection.Open();

                
                string sql = "INSERT INTO tb_Cliente(nm_Cli, email_Cli, end_Cli, tel_Cli) VALUES (@NomeCli, @EmailCli, @EnderecoCli, @TelefoneCli); SELECT SCOPE_IDENTITY();";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@NomeCli", nome_Cliente);
                    cmd.Parameters.AddWithValue("@EmailCli", email_Cliente);
                    cmd.Parameters.AddWithValue("@EnderecoCli", endereco_Cliente);
                    cmd.Parameters.AddWithValue("@TelefoneCli", telefone_Cliente);

                   
                    
                     
                    //executa
                    int idCliente = Convert.ToInt32(cmd.ExecuteScalar());

                    sql = "INSERT INTO tb_CliJ(cd_Cli, numCNPJ) VALUES (@cd_Cli, @numCNPJ)";

                    using (SqlCommand cmdDetalhes = new SqlCommand(sql, connection))
                    {
                        cmdDetalhes.Parameters.AddWithValue("@cd_Cli", idCliente);
                        cmdDetalhes.Parameters.AddWithValue("@numCNPJ", cnpj_Cliente);

                        cmdDetalhes.ExecuteNonQuery();

                    }

                    return "Cliente adicionado!";
                }

            }



        }
    }
}
