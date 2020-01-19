using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Funcionarios
{
    public abstract class Funcionario
    {
        public static double GastosBonificacao { get; protected set; }
        public static int TotalFuncionarios { get; private set; }

        public string Nome { get; set; }
        public string CPF { get; private set; }
        public double Salario { get; protected set; }

        public Funcionario(string nome, string cpf, double salario)
        {
            Nome = nome;
            CPF = cpf;
            Salario = salario;

            GastosBonificacao += GetBonificacao();
            TotalFuncionarios++;
        }

        public virtual void AumentarSalario()
        {
            GastosBonificacao -= GetBonificacao();
        }

        //Metodo visivel apenas internamente nesse projeto, ou classes externamente que derivam dessa classe (Com herença)
        internal protected abstract double GetBonificacao();
    }
}
