using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Funcionarios
{
    class Desenvolvedor : Funcionario
    {
        public Desenvolvedor(string nome, string cpf)
            : base(nome, cpf, 3000.0)
        {
        }

        internal protected override double GetBonificacao()
        {
            return Salario * 0.1;
        }

        public override void AumentarSalario()
        {
            base.AumentarSalario();
            Salario *= 0.15;
            GastosBonificacao += GetBonificacao();
        }
    }
}
