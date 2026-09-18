using backEnd_sprint_1_poo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace backEnd_sprint_1_poo.Modelos;

internal class ContaCorrente : ContaBancaria, ITaxa
{
    public double taxaDeSaque = 0.03;
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
        double Taixa = CalcularTaxa(valor);
        if(valor > 0 && Taixa + valor <= Saldo){
            Console.WriteLine($"Saque de {valor:F2} + Taxa de saque da conta corrente de 3% aplicado");
        } else if(valor>0 && valor <= Saldo){
            Console.WriteLine($"\nSaque de {valor:F2} indisponível, considerar a taxa de 3%  - Valor de saque com taxa = {Taixa + valor:F2}\n");
            Thread.Sleep(2000);
        }
        base.Saque(Taixa + valor );
    }
}
