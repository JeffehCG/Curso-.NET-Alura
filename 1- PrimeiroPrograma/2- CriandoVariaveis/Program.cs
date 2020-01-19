using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2__CriandoVariaveis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando projeto 2, criando variaveis");

            variaveisNumericas();
            variaveisTextuais();

            Console.WriteLine("Execução finalizada, tecle enter para sair");
            Console.ReadLine();
        }

        static public void variaveisNumericas()
        {
            // Numericos
            Console.WriteLine("\n Numericos");
            int idade;
            idade = 32;
            Console.WriteLine(idade);

            idade = 10;
            Console.WriteLine(idade);

            idade = 10 + 5;
            Console.WriteLine(idade);

            idade = 10 + 5 * 2;
            Console.WriteLine(idade);

            idade = (10 + 5) * 2;
            Console.WriteLine("Sua idade é " + idade);

            // Ponto Flutuante
            Console.WriteLine("\n Ponto Flutuante");
            double salario;
            salario = 1200.70;
            Console.WriteLine(salario);

            salario = salario / 2;
            Console.WriteLine(salario);

            // Conversões
            Console.WriteLine("\n Conversões");
            double valor;
            valor = 12500.50;

            int valorInteiro;
            valorInteiro = (int)valor;
            Console.WriteLine(valorInteiro);

            // Tipos numericos
            // variavel 64bits
            long numeroMaior = 1000000000000000000;

            // variavel 32 bits
            int numero = 1000000000;

            // variavel 16 bits
            short numeroMenor = 10000;

            float altura = 1.80f;
        }

        static public void variaveisTextuais()
        {
            
            Console.WriteLine("\n Textuais");
            //Character
            char primeiraLetra = 'a';
            Console.WriteLine(primeiraLetra);

            //Character pela ascii table
            primeiraLetra = (char)65;
            Console.WriteLine(primeiraLetra);

            //Texto
            string titulo = "Alura cursos de tecnologia";
            Console.WriteLine(titulo);

            string cursosProgramacao = 
                @" - .NET
                - Java
                - Javascript";

            Console.WriteLine(cursosProgramacao);
        }
    }
}
