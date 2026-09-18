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
        Console.WriteLine($"Saldo da sua {TipoDeConta} atual de {Saldo:F2}");
    }

    public virtual void Depositar(double valor){
        if(valor == 0){
            Console.WriteLine("Voltando ao menu anterior");
            Thread.Sleep(2000);
        }
        else if(valor < 0){
            Console.WriteLine("Valor inválido, voltando ao menu anterior");
        }
        else{
            Saldo += valor;
            Console.WriteLine($"\nDeposito de {valor:F2} realizado com sucesso!\n");
            exibirSaldo();
        }
    }

    public virtual void Saque(double valor)
    {
        if(valor == 0 ){
            Console.WriteLine("Voltando ao menu anterior");
            Thread.Sleep(2000);
        }
        else if (valor < 0)
        {
            Console.WriteLine("Valor inválido, voltando ao menu anterior");
        }
        else if(valor > Saldo){
            Console.WriteLine("\nSaldo insuficiente");
            exibirSaldo();
        }
        else{
        Saldo -= valor;
            Console.WriteLine($"\nSaque de {valor:F2} realizado!");
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
                Console.WriteLine($"Emprestimo disponivel de {EmprestimoBase:F2}\n");

                Console.Write($"\nQual valor deseja pegar emprestado? (Ou tecle 0 para cancelar): ");
                var valorSelecionado = Console.ReadLine();

                double valorNumerico = double.Parse(valorSelecionado!);
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
                        Console.WriteLine($"\nEmprestimo de {valorNumerico:F2} realizado com sucesso e já está disponivel em seu saldo!");
                        Saldo += valorNumerico;
                        EmprestimoBase -= valorNumerico;
                        Thread.Sleep(3000);
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("\nValor Invalido!");
                        Thread.Sleep(2000);
                        Console.Clear();

                    }
                }
                
            } while (valorControle != 0);

        }
        catch{
            Console.WriteLine("\nInsira um valor válido!");
            Thread.Sleep(2000);
            Console.Clear();
            Emprestimo();
        }
    }


}
