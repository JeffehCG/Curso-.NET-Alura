using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4__LacosRepeticao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Projeto 4- laços repetição");
            calcularPoupanca(1000.0, 12);
            calcularPoupancaCorrecaoAnual(2500.0, 35);
            utilizandoBreak();
            Console.ReadLine();
        }

        public static void calcularPoupanca(double valorInvestido, int qtMeses)
        {
            Console.WriteLine("\n Repetição While");
            double valorFinal = valorInvestido;

            int contadorMes = 1;
            while(contadorMes <= qtMeses)
            {
                valorFinal = valorFinal + valorFinal * 0.0036;
                Console.WriteLine($"Valor daqui {contadorMes} mesês sera R${valorFinal}");
                contadorMes++;
            }
        }

        public static void calcularPoupancaCorrecaoAnual(double valorInvestido, int qtMeses)
        {
            Console.WriteLine("\n Repetição For");
            double valorFinal = valorInvestido;
            int qtAnos = qtMeses / 12;
            int mesesRestante = qtMeses - qtAnos * 12;
            double fatorRendimento = 1.0036;

            int indicadorMes = 0;
            for (int contadorAno = 1; contadorAno <= qtAnos; contadorAno++)
            {
                for(int contadorMes = 1; contadorMes <= 12; contadorMes++)
                {
                    indicadorMes++;
                    valorFinal *= fatorRendimento;
                    Console.WriteLine($"Valor daqui {indicadorMes} mesês sera R${valorFinal}");
                }
                fatorRendimento += 0.0010;
            }
            for (int contadorMesesRestante = 1; contadorMesesRestante <= mesesRestante; contadorMesesRestante++)
            {
                indicadorMes++;
                valorFinal *= fatorRendimento;
                Console.WriteLine($"Valor daqui {indicadorMes} mesês sera R${valorFinal}");
            }
        }

        public static void utilizandoBreak()
        {
            Console.WriteLine("\n Utilizando Break");
            for (int contadorLinha = 0; contadorLinha <=10; contadorLinha++)
            {
                for(int contadorColuna = 0; contadorColuna <= 10; contadorColuna++)
                {
                    Console.Write("*");
                    if (contadorColuna >= contadorLinha)
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
