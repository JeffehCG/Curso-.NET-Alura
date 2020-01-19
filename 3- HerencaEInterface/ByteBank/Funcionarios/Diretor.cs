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
        // No construtor da classe filha sempre é chamado primeiro o da classe pai
        // No : base é passado os parametros para o construtor da classe pai
        public Diretor(string nome, string cpf, string senha) 
            : base(nome, cpf, 5000.0, senha)
        {
        }

        //Override é utilizado para sobreescrever metodo ja criado na classe pai
        public override double GetBonificacao()
        {
            return Salario * 0.5;
        }

        public override void AumentarSalario()
        {
            //Utilizando base sera utilizado exatamente o metodo da classa pai (sem a sobrescrita)
            base.AumentarSalario();
            Salario *= 1.15;
            GastosBonificacao += GetBonificacao();
        }
    }
}
