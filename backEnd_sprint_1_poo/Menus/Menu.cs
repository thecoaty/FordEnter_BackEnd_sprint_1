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

    public Boolean ValidarCaracteres(string nomeDoUsuario){

        string[] caractereInvalido = ["\u0022", "\u005C", "'","-", "_", "=", "+", "{", "}", "[", "]", ",", ".", "*", "&", "¨", "%", "$", "#", "@", "!", "|","/", "?", ":", ";", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" ];

        for (int i = 0; i != nomeDoUsuario.Length; i++)
        {
            //Console.WriteLine(nomeDoUsuario[i]);
            foreach (var caractere in caractereInvalido)
            {
                if (nomeDoUsuario[i] == char.Parse(caractere))
                {
                    Console.WriteLine("Caractere Invalido");
                    return false;
                }

            }
        }
                return true;
    }

    public void CriarUsuario(){
        Console.Write("Olá usuario qual o seu nome? ");
        string usuario = Console.ReadLine()!;
        
        if (!(string.IsNullOrWhiteSpace(usuario)) && ValidarCaracteres(usuario))
        {
            var numeroAleatorio = new Random();
            int numeroDaConta = numeroAleatorio.Next(1, 100);
            var novoUsuario = new Usuario(usuario);


            var contaCorrente = new ContaCorrente(novoUsuario, numeroDaConta);
            var contaPoupanca = new ContaPoupanca(novoUsuario, numeroDaConta);
            var contaEmpresarial = new ContaEmpresarial(novoUsuario, numeroDaConta);
            ExibirMenu(novoUsuario);
        }
        else{
            Console.WriteLine("Precisa ter um nome de usuario válido e sem caracteres especiais.");
            Thread.Sleep(2000);

            Console.Clear();
            CriarUsuario();
        }

    }

    public void ExibirMenu(Usuario usuario){
        Console.Clear();
        ExibirTituloDaOpcao($"Olá {usuario.Nome}, digite a opção desejada:");
       

        Console.WriteLine("1. Acessar sua Conta Corrente");
        Console.WriteLine("2. Acessar sua Conta Poupanca");
        Console.WriteLine("3. Acessar sua Conta Empresarial");
        Console.WriteLine("-1. Sair");
        Console.Write("Digite a sua opção: ");
        try
        {
            do
            {
            string opcaoEscolhida = Console.ReadLine()!;
            int opcao = int.Parse(opcaoEscolhida);
                switch (opcao)
                {
                    case 1:
                        new AcessarConta().Executar(usuario.Contas[0]);
                        return;
                    case 2:
                        new AcessarConta().Executar(usuario.Contas[1]);
                        return;
                    case 3:
                        new AcessarConta().Executar(usuario.Contas[2]);
                        return;
                    case -1:
                        return;
                    default:
                        Console.WriteLine("Opção inválida, insira uma opção valída");
                        break;
                }
            } while (true);
        }
        catch {
            Console.Clear();
            Console.WriteLine($"Caractere invalido, o sistema aceita apenas números... \n");
            Thread.Sleep(2000);
            ExibirMenu(usuario);
        }
        
    }


    public virtual void Executar(ContaBancaria conta)
    {
        Console.Clear();
    }

}
