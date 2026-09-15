using System;
using System.Collections.Generic;
using System.Text;

namespace backEnd_sprint_1_poo.Modelos;

internal abstract class ContaBancaria
{
    public int NumeroConta { get; }
    public Usuario Titular { get; }
    public double Saldo { get; private set; }

    public ContaBancaria(int numeroConta, Usuario usuario){
    this.NumeroConta = numeroConta;
    this.Titular = usuario;
    this.Saldo = 0;
    }

    public void exibirSaldo(){
        Console.WriteLine($"Saldo atual de {Saldo}");
    }

    public virtual void Depositar(double valor){
        Saldo += valor;
        Console.WriteLine($"Deposito de {valor} realizado com sucesso!");
        exibirSaldo();
    }

    public virtual void Saque(double valor)
    {
        if(valor > Saldo){
            Console.WriteLine("Saldo insuficiente");
            exibirSaldo();
        }
        else{
        Saldo -= valor;
            Console.WriteLine($"Saque de {valor} realizado!");
            exibirSaldo();
        }
    }

    public virtual void Emprestimo(double valor){

        Console.WriteLine("");
    }


}
