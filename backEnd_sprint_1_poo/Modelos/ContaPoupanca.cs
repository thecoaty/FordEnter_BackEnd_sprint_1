using backEnd_sprint_1_poo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace backEnd_sprint_1_poo.Modelos;

internal class ContaPoupanca : ContaBancaria, IRendimento
{

    public double Rendimento { get; }
    public ContaPoupanca(Usuario titular, int numeroDaConta) : base(numeroDaConta, titular)
    {
        titular.Contas.Add(this);
        TipoDeConta = TipoDeConta.Poupanca;

        Rendimento = 0.01;
    }

    public double CalcularRendimento(double valor){
        return valor * Rendimento;
    }

    public override void Depositar(double valor)
    {
        if (valor == 0)
        {
            Console.WriteLine("Voltando ao menu anterior");
            Thread.Sleep(2000);
        }
        else if (valor < 0)
        {
            Console.WriteLine("Valor inválido, voltando ao menu anterior");
        }
        else
        {
            Saldo += valor + CalcularRendimento(valor);
            Console.WriteLine($"Deposito de {valor:F2} realizado...");
            Console.WriteLine($"Rendimento da Poupanca de 1% aplicado\n");
            exibirSaldo();
        }
    }

}
