using System;
using System.Collections.Generic;
using System.Text;

namespace backEnd_sprint_1_poo.Modelos;

internal class Usuario
{
    public string Nome { get; }

    public List<ContaBancaria> Contas = new List<ContaBancaria>();

    public Usuario(string nome){
        this.Nome = nome;
    }
}
