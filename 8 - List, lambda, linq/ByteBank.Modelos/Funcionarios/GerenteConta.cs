using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Funcionarios
{
    public class GerenteConta : FuncionarioAutenticavel
    {
        public GerenteConta(string nome, string cpf, string senha)
            : base(nome, cpf, 4000.0, senha)
        { }

        public override void AumentarSalario()
        {
            base.AumentarSalario();
            Salario *= 1.05;
            GastosBonificacao += GetBonificacao();
        }

        internal protected override double GetBonificacao()
        {
            return Salario * 0.25;
        }
    }
}
