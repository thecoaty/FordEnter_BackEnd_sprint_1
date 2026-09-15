using backEnd_sprint_1_poo.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace backEnd_sprint_1_poo.Menus;

internal class AcessarContaCorrente : Menu
{
    public override void Executar(ContaBancaria conta)
    {
                
    ExibirOpcoes(conta);
        try
        {
            do
            {
                string opcaoEscolhida = Console.ReadLine()!;
                int opcao = int.Parse(opcaoEscolhida);
                switch (opcao)
                {
                    case 1:
                        conta.exibirSaldo();
                        Thread.Sleep(3000);
                        ExibirOpcoes(conta);
                        break;
                    case 2:
                        Console.Write("Digite o valor para deposito: ");
                        string valorDeposito = Console.ReadLine()!;
                        double valorIntDeposito = double.Parse(valorDeposito);
                        conta.Depositar(valorIntDeposito);
                        Thread.Sleep(3000);
                        ExibirOpcoes(conta);
                        break;
                    case 3:
                        conta.exibirSaldo();
                        Console.Write($"\nDigite o valor para sacar: ");
                        string valorSaque = Console.ReadLine()!;
                        double valorIntSaque = double.Parse(valorSaque);
                        conta.Saque(valorIntSaque);
                        Thread.Sleep(3000);
                        ExibirOpcoes(conta);
                        break;
                    case 4:
                        ExibirOpcoes(conta);
                        break;

                    case -1:
                        return;

                    default:
                        Console.WriteLine("Opção inválida, insira uma opção valída");
                        Thread.Sleep(3000);
                        ExibirOpcoes(conta);
                        break;
                }
            } while (true);
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Opção invalida {ex.Message}\n");
            Thread.Sleep(2000);
            Executar(conta);
        }

    }
    private void ExibirOpcoes(ContaBancaria conta){
        Console.Clear();
        var TitularDaConta = conta.Titular.Nome;
        var saldoDaConta = conta.Saldo;

        ExibirTituloDaOpcao($"Opções da Conta corrente. {TitularDaConta}, digite a opção desejada:");
        Console.WriteLine("1. Consultar Saldo");
        Console.WriteLine("2. Deposito");
        Console.WriteLine("3. Saque");
        Console.WriteLine("4. Consultar Emprestimos");
        Console.WriteLine("-1. Sair\n");
        Console.Write("Digite a sua opção: ");
    }
}
