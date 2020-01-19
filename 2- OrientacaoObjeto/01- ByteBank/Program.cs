using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01__ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta1 = new ContaCorrente(863, 86316);
            conta1.Titular = new Cliente("Gabriela", "453.254.789-62", "Dentista");
            conta1.ExibirDados();

            ContaCorrente conta2 = new ContaCorrente(863, 86317);
            conta2.Titular = new Cliente("Bruno", "254.896.354-12", "Medico"); ;
            conta2.Saldo = 300.0;
            conta2.ExibirDados();

            bool resultadoSaque = conta1.Sacar(50.0);
            conta1.ExibirDados();
            Console.WriteLine(resultadoSaque);

            conta1.Depositar(500.0);
            conta1.ExibirDados();

            conta1.Transferencia(300, conta2);
            conta1.ExibirDados();
            conta2.ExibirDados();

            Console.WriteLine(ContaCorrente.TotalContasCriadas);

            Console.ReadLine();
        }
    }
}
