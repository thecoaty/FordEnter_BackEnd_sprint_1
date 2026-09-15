using System;
using System.Collections.Generic;
using System.Text;

namespace backEnd_sprint_1_poo.Modelos;

internal class ContaCorrente : ContaBancaria
{
    public ContaCorrente(Usuario titular, int numeroDaConta):base(numeroDaConta, titular){ 
    
    }

    public override void Saque(double valor)
    {
        double taxaDeSaque = 0.05;
        Console.WriteLine($"Saque de {valor} + Taxa de saque da conta corrente de {taxaDeSaque*valor} aplicado");
        base.Saque((taxaDeSaque*valor) + valor );
    }
}
