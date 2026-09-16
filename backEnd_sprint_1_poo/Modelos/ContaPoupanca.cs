using System;
using System.Collections.Generic;
using System.Text;

namespace backEnd_sprint_1_poo.Modelos;

internal class ContaPoupanca : ContaBancaria
{

    public double Rendimento { get; }
    public ContaPoupanca(Usuario titular, int numeroDaConta) : base(numeroDaConta, titular)
    {
        titular.Contas.Add(this);
        TipoDeConta = TipoDeConta.ContaPoupanca;

        Rendimento = 0.01;
    }

    public override void Depositar(double valor)
    {
        Saldo += valor + (valor * Rendimento);
        Console.WriteLine($"Deposito de {valor} realizado com sucesso com Rendimento da Poupanca de 1%");
        exibirSaldo();
    }

}
