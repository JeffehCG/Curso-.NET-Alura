using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Funcionarios
{
    class Auxiliar : Funcionario
    {
        public Auxiliar(string nome, string cpf)
            : base(nome, cpf, 2000.0)
        { }

        public override void AumentarSalario()
        {
            base.AumentarSalario();
            Salario *= 1.1;
            GastosBonificacao += GetBonificacao();
        }

        internal protected override double GetBonificacao()
        {
            return Salario * 0.2;
        }
    }
}
