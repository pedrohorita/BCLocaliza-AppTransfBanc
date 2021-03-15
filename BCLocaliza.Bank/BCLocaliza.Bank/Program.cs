using System;
using System.Collections.Generic;

namespace BCLocaliza.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {            
            string opcUsuario = ObterOpcaoUsuario();
            while (opcUsuario != "X")
            {
                switch(opcUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "":
                        break;
                    default:
                        Console.WriteLine("Desculpe, não consegui entender essa opção. Tente novamente.");                        
                        break;
                }
                opcUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.WriteLine("Transferir");

            Console.WriteLine("Digite o número da conta origem: ");
            int numContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta destino: ");
            int numContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser depositado: ");
            double valor = double.Parse(Console.ReadLine());

            listContas[numContaOrigem - 1].Transferir(valor, listContas[numContaDestino - 1]);
        }

        private static void Depositar()
        {
            Console.WriteLine("Depositar");

            Console.WriteLine("Digite o número da conta: ");
            int numConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser depositado: ");
            double valor = double.Parse(Console.ReadLine());

            listContas[numConta - 1].Depositar(valor);
        }

        private static void Sacar()
        {
            Console.WriteLine("Sacar");

            Console.WriteLine("Digite o número da conta: ");
            int numConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado: ");
            double valor = double.Parse(Console.ReadLine());

            listContas[numConta - 1].Sacar(valor);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if(listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }
            int n = 1;
            foreach (Conta conta in listContas)
            {
                Console.WriteLine($"#{n} - {conta}");
                n += 1;
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Digite 1 para Conta Física ou 2 para Jurídica: ");
            int tipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Nome do Cliente: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            double saldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito: ");
            double credito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)tipoConta,
                                         saldo: saldo,
                                         credito: credito,
                                         nome: nome);

            listContas.Add(novaConta);

        }
            
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo ao BCLoc Bank!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcUsuario;
        }
    }
}
