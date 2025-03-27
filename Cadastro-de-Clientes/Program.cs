using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cadastro_de_Clientes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Cliente> listaClientes = new List<Cliente>();

            bool continuar = true;

            while (continuar) 
            {

                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1 - Adicionar cliente");
                Console.WriteLine("2 - Listar clientes");
                Console.WriteLine("3 - Buscar cliente por nome");
                Console.WriteLine("4 - Remover cliente");
                Console.WriteLine("5 - Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarCliente(listaClientes);
                        break;
                    case "2":
                        ListarClientes(listaClientes);
                        break;
                    case "3":
                        BuscarCliente(listaClientes);
                        break;
                    case "4":
                        RemoverCliente(listaClientes);
                        break;
                    case "5":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }
            }

        }

        static void AdicionarCliente(List<Cliente> listaClientes)
        {
            Console.Write("Digite o nome do cliente: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o e-mail do cliente: ");
            string email = Console.ReadLine();

            Console.Write("Digite a idade do cliente: ");
            int idade = int.Parse(Console.ReadLine());

            Cliente novoCliente = new Cliente
            {
                Nome = nome,
                Email = email,
                Idade = idade
            };

            listaClientes.Add(novoCliente);

            Console.WriteLine("Cliente adicionado com sucesso!");
        }

        static void ListarClientes(List<Cliente> listaClientes)
        {
            if(listaClientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado");
                return;
            }

            Console.WriteLine("\n--- Lista de Clientes ---");
            foreach(Cliente cliente in listaClientes)
            {
                Console.WriteLine($"Nome: {cliente.Nome}, E-mail: {cliente.Email}, Idade: {cliente.Idade}");
            }
        }

        static void BuscarCliente(List<Cliente> listaClientes)
        {
            Console.Write("Digite o nome do cliente que deseja buscar: ");
            string nomeBusca = Console.ReadLine();

            Cliente clienteEncontrado = listaClientes.Find(cliente => cliente.Nome.Equals(nomeBusca, StringComparison.OrdinalIgnoreCase));

            if (clienteEncontrado != null)
            {
                Console.WriteLine($"\nCliente encontrado: Nome: {clienteEncontrado.Nome}, E-mail: {clienteEncontrado.Email}, Idade: {clienteEncontrado.Idade}");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }

        static void RemoverCliente(List<Cliente> listaClientes)
        {
            Console.Write("Digite o nome do cliente que deseja remover: ");
            string nomeRemover = Console.ReadLine();

            Cliente clienteEncontrado = listaClientes.Find(cliente => cliente.Nome.Equals(nomeRemover, StringComparison.OrdinalIgnoreCase));

            if (clienteEncontrado != null)
            {
                listaClientes.Remove(clienteEncontrado);
                Console.WriteLine($"Cliente {clienteEncontrado.Nome} removido com sucesso.");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }


    }
}
