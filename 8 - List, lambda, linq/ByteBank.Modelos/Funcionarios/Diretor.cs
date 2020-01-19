using ByteBank.Sistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Funcionarios
{
    public class Diretor : FuncionarioAutenticavel
    {
        public Diretor(string nome, string cpf, string senha)
            : base(nome, cpf, 5000.0, senha)
        {
        }

        internal protected override double GetBonificacao()
        {
            return Salario * 0.5;
        }

        public override void AumentarSalario()
        {
            base.AumentarSalario();
            Salario *= 1.15;
            GastosBonificacao += GetBonificacao();
        }
    }
}
