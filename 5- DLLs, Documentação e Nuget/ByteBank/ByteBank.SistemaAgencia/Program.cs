using _01__ByteBank;
using ByteBank.Funcionarios;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            //Fazendo referencia a biblioteca de classes ByteBank.Modelos 
            ContaCorrente conta = new ContaCorrente(863, 896525);
            conta.Sacar(10);
            Console.WriteLine(conta.Numero);

            FuncionarioAutenticavel funcionario = null;
            //funcionario.Autenticar("123456");

            LidandoComDatas();

            Console.ReadLine();
        }

        static void LidandoComDatas()
        {
            DateTime dataFimPagamento = new DateTime(2020,06,25);
            Console.WriteLine(dataFimPagamento);

            DateTime dataCorrente = DateTime.Now;
            Console.WriteLine(dataCorrente);

            TimeSpan diferencaDatas = dataFimPagamento - dataCorrente;
            Console.WriteLine(diferencaDatas);

            Console.WriteLine(GetQuantidadeDias(diferencaDatas));
            Console.WriteLine(ExibirDiferencaDatas(diferencaDatas));

            Console.ReadLine();
        }

        static string GetQuantidadeDias(TimeSpan timeSpan)
        {
            return timeSpan.Days + " dias";
        }

        // Utilizando a biblioteca Humanizer do NuGet
        static string ExibirDiferencaDatas(TimeSpan timeSpan)
        {
            return $"Vencimento em {TimeSpanHumanizeExtensions.Humanize(timeSpan)}";
        }
    }
}
