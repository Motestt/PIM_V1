using System;
using Fazenda01.Entities;
using System.Data.SqlClient;


namespace Fazenda01
{
    public class Program
    {
        static void Main(string[] args)
        {
            //INICIO
            Console.WriteLine("Bem Vindo!");
            int resposta;
            //LOGICA DE LOGIN
            while (true)
            {
                Console.WriteLine("Para se cadastrar Digite: 1");
                Console.WriteLine("Se já possui conta digite: 2");
                Console.Write("Resposta:");
                if (!int.TryParse(Console.ReadLine(), out resposta) || (resposta != 1 && resposta != 2))
                {
                    Console.WriteLine("Número inválido! Por favor, digite 1 ou 2.");
                    continue;
                }

                if (resposta == 1)
                {
                    Console.WriteLine("Entre com os dados:");
                    Console.Write("Usuario:");
                    string username = Console.ReadLine();
                    Console.Write("Senha:");
                    string password = Console.ReadLine();
                    //criando objeto
                    DataAcess usuario = new DataAcess(username, password);

                    usuario.SaveData(username, password);

                    Console.WriteLine("Cadastro realizado com sucesso!");
                    break; //sai do loop

                }
                else if (resposta == 2)
                {
                    Console.WriteLine("ENTRAR");

                    Console.Write("Usuario:");
                    string username = Console.ReadLine();
                    Console.Write("Senha:");
                    string password = Console.ReadLine();

                    DataAcess usuario = new DataAcess(username, password);
                    string R = usuario.Validator(username, password);
                    Console.WriteLine(R);
                    if (R == "senha correta!")
                    {
                        break; // sai do loop
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            //MENU PRINCIPAL
            while (true)
            {
                Console.WriteLine("Menu Principal:");
                Console.WriteLine("1. Estoque");
                Console.WriteLine("2. Clientes");
                Console.WriteLine("3. Produção");
                Console.WriteLine("4. Vendas");
                Console.WriteLine("5. Fornecedores");
                Console.WriteLine("6. Sair");

                Console.Write("Escolha uma opção:");
                int escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        GerenciadorEstoque.ExibirMenu1();
                        break;
                  
                    case 2:
                        
                        GerenciadorCliente.ExibirMenu2();

                        break;

                    case 3:

                        //GerenciadoProducao.ExibirMenu3();
                        break;

                    case 4:

                        //GerenciadorVendas.ExibirMenu4();
                        break;

                     case 5:   
                        //GerenciadorVendas.ExibirMenu5();
                            break;

                      case 6:  
                        return;

                      default:
                        Console.WriteLine("Opção inválida");
                        break;
                }





            }



        }
    }
}
