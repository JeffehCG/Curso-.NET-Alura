using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Funcionarios
{
    // Classes abstratas é uma base para classes filhas, e não pode ser instanciada diretamente
    public abstract class Funcionario
    {
        public static double GastosBonificacao {get; protected set;}
        public static int TotalFuncionarios { get; private set; }

        public string Nome { get; set; }
        public string CPF { get; private set; }
        // Diferença protected e private (private - acessado apenas na classe pai), (protected - acessado nas classes filhas e pai)
        public double Salario { get; protected set; }

        public Funcionario(string nome, string cpf, double salario)
        {
            Nome = nome;
            CPF = cpf;
            Salario = salario;

            //Utilizando virtual e override o GetBonificacao ira retornar o valor dependendo do tipo da classe (Diretor, Funcionario etc...)
            GastosBonificacao += GetBonificacao();
            TotalFuncionarios++;
        }

        //Com virtual classes filhas poderam sobrescrever esse metodo
        public virtual void AumentarSalario()
        {
            GastosBonificacao -= GetBonificacao();
        }

        // Classes abstratas obrigatoriamente devem ser implementadas nas classes filhas
        public abstract double GetBonificacao();
    }
}
