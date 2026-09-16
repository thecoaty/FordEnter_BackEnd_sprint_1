using System;
using System.Collections.Generic;
using System.Text;

namespace backEnd_sprint_1_poo.Modelos;

internal class ContaEmpresarial : ContaBancaria
{
    public ContaEmpresarial(Usuario titular, int numeroDaConta) : base(numeroDaConta, titular)
    {

        titular.Contas.Add(this);
        TipoDeConta = TipoDeConta.ContaEmpresarial;
        EmprestimoBase = 5000.00;
    }
}
