using backEnd_sprint_1_poo.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace backEnd_sprint_1_poo.Menus;

internal class Menu
{
    
    public void ExibirTituloDaOpcao(string titulo){
        int quantidadeDeLetras = titulo.Length;

        string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
        Console.WriteLine(asteriscos);
        Console.WriteLine(titulo);
        Console.WriteLine(asteriscos + "\n");
    }

    public virtual void Executar(Dictionary<ContaBancaria, Usuario> usuariosRegistrados){

    }

    public void CriarUsuario(){
        Console.Write("Olá usuario qual o seu nome? ");
        string usuario = Console.ReadLine()!;
        var novoUsuario = new Usuario(usuario);
        var numeroAleatorio = new Random();
        int numeroDaConta = numeroAleatorio.Next(1, 100);

        var conta1 = new ContaCorrente(novoUsuario, numeroDaConta);

        Console.Clear();

        ExibirTituloDaOpcao($"Olá {usuario}, digite a opção desejada:");
        ExibirMenu(conta1);
    }

    public void ExibirMenu(ContaCorrente conta){

        Console.WriteLine("1. Acessar sua Conta Corrente");
        Console.WriteLine("2. Acessar sua Conta Poupanca");
        Console.WriteLine("3. Acessar sua Conta Empresarial");
        Console.WriteLine("-1. Sair");
        try
        {
            do
            {
            string opcaoEscolhida = Console.ReadLine()!;
            int opcao = int.Parse(opcaoEscolhida);
                switch (opcao)
                {
                    case 1:
                        new AcessarContaCorrente().Executar(conta);
                        return;
                    default:
                        Console.WriteLine("Opção inválida, insira uma opção valída");
                        break;
                }
            } while (true);
        }
        catch (Exception ex) {
            Console.Clear();
            Console.WriteLine($"Opção invalida {ex.Message}\n");
            ExibirMenu(conta);
        }
        
    }


    public virtual void Executar(ContaBancaria conta)
    {
        Console.Clear();
    }

}
