using backEnd_sprint_1_poo.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace backEnd_sprint_1_poo.Menus;

internal class AcessarConta : Menu
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
                        ExibirTituloDaOpcao("Exibir saldo.");
                        conta.exibirSaldo();
                        Thread.Sleep(3000);
                        ExibirOpcoes(conta);
                        break;
                    case 2:
                        ExibirTituloDaOpcao("Realizar deposito.");
                        Console.Write("Digite o valor para deposito, ou tecle 0 para voltar: ");
                        string valorDeposito = Console.ReadLine()!;
                        double valorIntDeposito = double.Parse(valorDeposito);
                        conta.Depositar(valorIntDeposito);
                        Thread.Sleep(3000);
                        ExibirOpcoes(conta);
                        break;
                    case 3:
                        ExibirTituloDaOpcao("Realizar saque.");
                        conta.exibirSaldo();
                        Console.Write($"\nDigite o valor para sacar, ou tecle 0 para voltar: ");
                        string valorSaque = Console.ReadLine()!;
                        double valorIntSaque = double.Parse(valorSaque);
                        conta.Saque(valorIntSaque);
                        Thread.Sleep(3000);
                        ExibirOpcoes(conta);
                        break;
                    case 4:
                        ExibirTituloDaOpcao("Consulta de Emprestimo");
                        conta.Emprestimo();
                        Console.Clear();
                        ExibirOpcoes(conta);
                        break;

                    case 0:
                        ExibirMenu(conta.Titular);
                        return;

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
        catch
        {
            Console.Clear();
            Console.WriteLine($"Caractere invalido, o sistema aceita apenas números... \n");
            Thread.Sleep(2000);
            Executar(conta);
        }

    }
    private void ExibirOpcoes(ContaBancaria conta){
        Console.Clear();
        var TitularDaConta = conta.Titular.Nome;
        var saldoDaConta = conta.Saldo;

        ExibirTituloDaOpcao($"Opções da Conta {conta.TipoDeConta}. {TitularDaConta}, digite a opção desejada:");
        Console.WriteLine("1. Consultar Saldo");
        Console.WriteLine("2. Deposito");
        Console.WriteLine("3. Saque");
        Console.WriteLine("4. Consultar Emprestimos");
        Console.WriteLine("0. Voltar");
        Console.WriteLine("-1. Sair\n");
        Console.Write("Digite a sua opção: ");
    }
}
