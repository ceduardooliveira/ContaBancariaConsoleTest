﻿using System;

class Program
{
    static void Main(string[] args)
    {
        // Singleton: Obtém a única instância do banco.
        var banco = Banco.Instancia;

        // Configuração do Observer.
        var notificador = new NotificadorSaldo();
        var gerenciador = new GerenciadorObservadores();
        gerenciador.AdicionarObservador(notificador);

        Console.WriteLine("Bem-vindo ao Sistema Bancário!");
        // Entrada de dados manual via console.
        while (true)
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1. Criar Conta");
            Console.WriteLine("2. Realizar Depósito");
            Console.WriteLine("3. Realizar Saque");
            Console.WriteLine("4. Exibir Contas");
            Console.WriteLine("5. Sair");
            Console.Write("Opção: ");
            var opcao = Console.ReadLine();

            if (opcao == "1")
            {
                Console.Write("Digite o nome do titular: ");
                var titular = Console.ReadLine();
                if (string.IsNullOrEmpty(titular))
                {
                    Console.WriteLine("Nome do titular inválido.");
                    continue;
                }

                Console.Write("Digite o saldo inicial: ");
                if (!decimal.TryParse(Console.ReadLine(), out var saldoInicial))
                {
                    Console.WriteLine("Valor de saldo inicial inválido.");
                    continue;
                }

                Console.Write("Escolha o tipo de conta (1. Corrente / 2. Poupança): ");
                var tipoConta = Console.ReadLine();
                if (tipoConta != "1" && tipoConta != "2")
                {
                    Console.WriteLine("Tipo de conta inválido.");
                    continue;
                }

                // Factory Method: Cria contas de forma dinâmica com base no tipo escolhido.
                ContaFactory contaFactory = tipoConta == "1"
                    ? new ContaCorrenteFactory()
                    : new ContaPoupancaFactory();

                var conta = contaFactory.CriarConta(titular, saldoInicial);
                banco.AdicionarConta(conta);
                Console.WriteLine($"Conta criada com sucesso para {titular}!");
            }
            else if (opcao == "2")
            {
                Console.Write("Digite o nome do titular: ");
                var titular = Console.ReadLine();
                if (string.IsNullOrEmpty(titular))
                {
                    Console.WriteLine("Nome do titular inválido.");
                    continue;
                }

                Console.Write("Digite o valor do depósito: ");
                if (!decimal.TryParse(Console.ReadLine(), out var valor))
                {
                    Console.WriteLine("Valor de depósito inválido.");
                    continue;
                }

                var conta = banco.Contas.Find(c => c.Titular == titular);
                if (conta != null)
                {
                    var deposito = new OperacaoDeposito(conta, valor);
                    deposito.Executar();
                    gerenciador.NotificarTodos(conta); // Observer: Notifica a mudança.
                }
                else
                {
                    Console.WriteLine("Conta não encontrada.");
                }
            }
            else if (opcao == "4")
            {
                Console.WriteLine("\nLista de Contas:");
                foreach (var conta in banco.Contas)
                {
                    Console.WriteLine($"Titular: {conta.Titular}, Saldo: {conta.Saldo:C}, Tipo: {conta.TipoConta}");
                }
            }
            else if (opcao == "5")
            {
                Console.WriteLine("Encerrando o sistema...");
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }
        }
    }
}
