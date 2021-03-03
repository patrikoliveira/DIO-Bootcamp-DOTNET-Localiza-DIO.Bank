using System;
using System.Collections.Generic;
using DIO.Bank.Classes;
using DIO.Bank.Enum;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirContas();
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
                    default:
                      throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nosso banco");
        }

    private static void Transferir()
    {
        System.Console.WriteLine("Digite o número da conta de origem: ");
        int indiceContaOrigem = int.Parse(Console.ReadLine());

        System.Console.WriteLine("Digite o número da conta de destino: ");
        int indiceContaDestino = int.Parse(Console.ReadLine());

        System.Console.WriteLine("Digite o valor a ser transferido: ");
        double valorTransferencia = double.Parse(Console.ReadLine());
        listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
    }

    private static void Depositar()
    {
        System.Console.WriteLine("Digite o número da conta: ");
        int indiceConta = int.Parse(Console.ReadLine());

        System.Console.WriteLine("Digite o valor a ser depositado: ");
        double valorDepositar = double.Parse(Console.ReadLine());
        listContas[indiceConta].Depositar(valorDepositar);
    }

    private static void Sacar()
    {
        System.Console.WriteLine("Digite o número da conta: ");
        int indiceConta = int.Parse(Console.ReadLine());

        System.Console.WriteLine("Digite o valor a ser sacado: ");
        double valorSacar = double.Parse(Console.ReadLine());
        listContas[indiceConta].Sacar(valorSacar);
    }

    private static void ListarContas()
    {
        System.Console.WriteLine("Listar contas");

        if (listContas.Count == 0)
        {
            System.Console.WriteLine("Nenhuma conta cadastrada.");
            return;
        }
        
        for (int i = 0; i < listContas.Count; i++)
        {
            System.Console.Write("#{0} - ", i);
            System.Console.WriteLine(listContas[i]);
        }
    }

    private static void InserirContas()
    {
        System.Console.WriteLine("Inserir nova Conta");

        System.Console.WriteLine("Digite 1 para Conta Fisica ou 2 para Jurídica: ");
        int entradaTipoConta = int.Parse(Console.ReadLine());

        System.Console.WriteLine("Digite o nome do cliente: ");
        string entradaNome = Console.ReadLine();

        System.Console.WriteLine("Digite o saldo inicial: ");
        double entradaSaldo = double.Parse(Console.ReadLine());

        System.Console.WriteLine("Digite o credito: ");
        double entradaCredito = double.Parse(Console.ReadLine());

        Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                    saldo: entradaSaldo,
                                    credito: entradaCredito,
                                    nome: entradaNome);
        listContas.Add(novaConta);
    }

    private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("DIO Bank a seu Dispor");
            System.Console.WriteLine("Informe a opção desejada: ");
            System.Console.WriteLine("1- Listar Contas");
            System.Console.WriteLine("2- Inserir nova conta");
            System.Console.WriteLine("3- Transferir");
            System.Console.WriteLine("4- Depositar");
            System.Console.WriteLine("C- Limpar Tela");
            System.Console.WriteLine("X- Sair");
            System.Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;
        }
    }
}
