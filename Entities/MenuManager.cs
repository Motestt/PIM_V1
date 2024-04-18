using Fazenda01.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Fazenda01.Entities
{
    public class GerenciadorEstoque
    {
        public static void ExibirMenu1()
        {

            //MENU DO ESTOQUE 
            while (true)
            {
                Console.WriteLine("Menu Estoque:");
                Console.WriteLine("1. Adicionar Produto");
                Console.WriteLine("2. Remover Produto");
                Console.WriteLine("3. Pesquisar Produto");
                Console.WriteLine("4. Voltar");

                Console.Write("Escolha uma opção:");
                int escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        AdicionarProduto();
                        break;
                    case 2:
                        RemoverProduto();
                        break;
                    case 3:
                        PesquisarProduto();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }

        private static void AdicionarProduto()
        {
            Console.WriteLine("Adicionar Produto");

            Console.Write("Nome do produto:");
            string nome_produto = Console.ReadLine();
            Console.Write("Valor:");
            double valor_produto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Quantidade:");
            int quantidade_produto = int.Parse(Console.ReadLine());

            Produto produto = new Produto(nome_produto, valor_produto, quantidade_produto);

            string s = produto.AdicionarProduto(produto);

        }

        private static void RemoverProduto()
        {
            Console.WriteLine("Remover Produto");
            Console.Write("Nome do produto a ser removido:");
            string n = Console.ReadLine();

            Produto produto = new Produto();

            string ss = produto.RemoverProduto(n);




        }

        private static void PesquisarProduto()
        {
            Console.WriteLine("Pesquisar Produto");
            Console.WriteLine("Nome:");
            string n = Console.ReadLine();
            Produto p1 = new Produto();

            string ss = p1.PesquisarProduto(n);
            Console.WriteLine(ss.ToString());
        }



    }

    //gerenciador de clientes
    public class GerenciadorCliente
    {
        public static void ExibirMenu2()
        {

            //menu cliente


            while (true)
            {
                Console.WriteLine("Menu Cliente:");
                Console.WriteLine("1. Adicionar Cliente");
                Console.WriteLine("2. Remover Cliente");
                Console.WriteLine("3. Exibir lista de clientes");
                Console.WriteLine("4. Voltar");

                Console.Write("Escolha uma opção:");
                int escolha2 = int.Parse(Console.ReadLine());

                switch (escolha2)
                {
                    case 1:
                        AdicionarClientesM();
                        break;
                    case 2:
                        RemoverClientes();
                        break;
                    case 3:
                        PesquisarClientes();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }

        }

        private static void AdicionarClientesM()
        {
            Console.WriteLine("Adicionar Cliente");

            Console.Write("Nome do Cliente:");
            string nome_Cliente = Console.ReadLine();
            Console.Write("Email:");
            string email_Cliente = Console.ReadLine();
            Console.Write("Endereço:");
            string endereco_Cliente = Console.ReadLine();
            Console.Write("Telefone:");
            string telefone_Cliente = Console.ReadLine();
            Console.Write("Cliente Fisico ou Juridico? (F/J):");
            string res = Console.ReadLine().ToUpper();

            if (res == "F")
            {
                Console.Write("CPF:");
                string cpf_Cliente = Console.ReadLine();
                Cliente_F cliente = new Cliente_F(nome_Cliente, email_Cliente, endereco_Cliente, telefone_Cliente, cpf_Cliente);

                cliente.AdicionarClientes(nome_Cliente, email_Cliente, endereco_Cliente, telefone_Cliente, cpf_Cliente);



            }
            else if (res == "J")
            {
                Console.Write("CNPJ:");
                string cnpj_Cliente = Console.ReadLine();
                Cliente_J cliente = new Cliente_J(nome_Cliente, email_Cliente, endereco_Cliente, telefone_Cliente, cnpj_Cliente);

                cliente.AdicionarClientes(nome_Cliente, email_Cliente, endereco_Cliente, telefone_Cliente, cnpj_Cliente);

            }
            else
            {
                Console.WriteLine("Tipo invalido!"); return;
            }

        }



        //remover cliente
        private static void RemoverClientes()
        {
            //recebendo o nome
            Console.WriteLine("Remover Cliente");
            Console.Write("Nome completo: ");
            string n = Console.ReadLine();

            //acesso ao banco
            string connstring = @"Server=DESKTOP-O4HMF4G\SQLSERVER;Database=FazendaDB;Trusted_Connection=True;";

            SqlConnection connection = new SqlConnection(connstring);

            connection.Open();

            // Verificando se o cliente existe 
            string sql = "SELECT COUNT(*) FROM tb_Cliente WHERE nm_Cli = @nm_Cli";
            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@nm_Cli", n);
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            //if que verifica e retorna se nao achar
            if (count == 0)
            {
                Console.WriteLine("Cliente não encontrado.");
                return;
            }


            // Remova o cliente
            string sql2 = "DELETE FROM tb_Cliente WHERE nm_Cli = @nm_Cli";
            SqlCommand cmd2 = new SqlCommand(sql2, connection);

            cmd2.Parameters.AddWithValue("@nm_Cli", n);
            int rows = cmd2.ExecuteNonQuery();
            if (rows > 0)
            {
                Console.WriteLine("Cliente removido com sucesso.");
            }
            else
            {
                Console.WriteLine("Falha ao remover o cliente.");
            }



        }




        //pesquisar clientes
        private static void PesquisarClientes()
        {
            //exibir clientes]

            Cliente cliente = new Cliente();
            Console.WriteLine(cliente.BuscaC());


        }








    }

}

