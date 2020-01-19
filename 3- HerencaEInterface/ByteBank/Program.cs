using ByteBank.Funcionarios;
using ByteBank.Sistemas;
using ByteBank.Terceiros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {

            CalcularBonificacao();
            UsarSistema();

            Console.ReadLine();
        }

        public static void UsarSistema()
        {
            SistemaInterno sistemaInterno = new SistemaInterno();

            Diretor diretor = new Diretor("Lucas", "563.489.357-58", "123456");
            sistemaInterno.Logar(diretor, "123456");

            GerenteConta gerenteConta = new GerenteConta("Paulo", "263.589.145-58", "123456");
            sistemaInterno.Logar(gerenteConta, "dfasfd");

            ParceiroComercial parceiro = new ParceiroComercial("123456");
            sistemaInterno.Logar(parceiro, "123456");
        }

        public static void CalcularBonificacao()
        {
            Designer designer = new Designer("Pedro", "256.489.365-85");

            Diretor diretor = new Diretor("Roberta", "456.843.678-25", "123456");

            Auxiliar auxiliar = new Auxiliar("Igor", "245.156.452.48");

            GerenteConta gerenteConta = new GerenteConta("Camila", "542.365.486-58", "123456");

            Console.WriteLine("Total de Gastos Bonificação: " + Funcionario.GastosBonificacao);

            diretor.AumentarSalario();
            Console.WriteLine("Total de Gastos Bonificação: " + Funcionario.GastosBonificacao);
        }
    }
}
