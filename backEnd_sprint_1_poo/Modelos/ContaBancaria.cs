using System;
using System.Collections.Generic;
using System.Text;

namespace backEnd_sprint_1_poo.Modelos;

internal abstract class ContaBancaria
{
    public int NumeroConta { get; }
    public Usuario Titular { get; }
    public double Saldo { get; internal set; }

    internal double EmprestimoBase = 2500.00;

    public TipoDeConta TipoDeConta { get; internal set; }

    public ContaBancaria(int numeroConta, Usuario usuario){
    this.NumeroConta = numeroConta;
    this.Titular = usuario;
    this.Saldo = 0;
    }

    public void exibirSaldo(){
        Console.WriteLine($"Saldo da sua {TipoDeConta} atual de {Saldo}");
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

    public void Emprestimo(){


        double valorControle; 
        try
        {
            do
            {
                Console.Clear();
                Console.WriteLine($"Emprestimo disponivel de {EmprestimoBase}\n");

                Console.Write($"Qual valor deseja pegar emprestado? (Ou tecle 0 para cancelar): ");
                var valorSelecionado = Console.ReadLine();

                double valorNumerico = double.Parse(valorSelecionado);
                valorControle = valorNumerico;

                if (valorNumerico == 0)
                {
                    Console.WriteLine("Voltando ao menu anterior");
                    Thread.Sleep(2000);
                }
                else
                {
                    if (valorNumerico > 0 && valorNumerico <= EmprestimoBase)
                    {
                        Console.WriteLine($"Emprestimo de {valorNumerico} realizado com sucesso e já está disponivel em seu saldo!");
                        Saldo += valorNumerico;
                        Thread.Sleep(3000);
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Valor Invalido!");
                        Thread.Sleep(3000);
                        Console.Clear();

                    }
                }
                
            } while (valorControle != 0);

        }
        catch{
            Console.WriteLine("Insira um valor válido!");
            Thread.Sleep(3000);
            Console.Clear();
            Emprestimo();
        }
    }


}
