using backEnd_sprint_1_poo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace backEnd_sprint_1_poo.Modelos;

internal class ContaCorrente : ContaBancaria, ITaxa
{
    public double taxaDeSaque = 0.05;
    public ContaCorrente(Usuario titular, int numeroDaConta):base(numeroDaConta, titular)
    {
        titular.Contas.Add(this);
        TipoDeConta = TipoDeConta.ContaCorrente;
    }

    public double CalcularTaxa( double valorSaque)
    {
        return taxaDeSaque * valorSaque;
    }

    public override void Saque(double valor)
    {
        double saqueComTaixa = CalcularTaxa(valor);
        Console.WriteLine($"Saque de {valor} + Taxa de saque da conta corrente de {saqueComTaixa} aplicado");
        base.Saque(saqueComTaixa + valor );
    }
}
