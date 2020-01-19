using _01__ByteBank;
using ByteBank.Funcionarios;
using ByteBank.Modelos.Utilitarios;
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
            EstruturaArray();
            ArrayDeObjetos();
            ListaContaCorrenteArray();
            ListaGenerica();

            Console.ReadLine();
        }

        static void EstruturaArray()
        {
            // Array de inteiros com 5 posições
            int[] idades = new int[5];

            idades[0] = 15;
            idades[1] = 21;
            idades[2] = 67;
            idades[3] = 36;
            idades[4] = 18;

            int mediaIdades = 0;

            foreach(int idade in idades)
            {
                Console.WriteLine($"Idade = {idade}");
                mediaIdades += idade;
            }

            mediaIdades /= idades.Length;
            Console.WriteLine($"Media Idades = {mediaIdades}");
        }

        static void ArrayDeObjetos()
        {
            ContaCorrente[] contas = new ContaCorrente[]
                {
                    new ContaCorrente(874, 3589647, new Cliente("Rodrigo", "245.456.789-25", "Desenvolvedor")),
                    new ContaCorrente(358, 2568741, new Cliente("Pedro", "548.354.856-56", "Analista")),
                    new ContaCorrente(435, 3541258, new Cliente("Rafael", "254.358.425-25", "QA"))
                };

            foreach( ContaCorrente conta in contas)
            {
                conta.ExibirDados();
            }
        }

        static void ListaContaCorrenteArray()
        {
            ListaContaCorrente lista = new ListaContaCorrente(contaInicial: new ContaCorrente(871, 3541258, new Cliente("Rafael", "254.358.425-25", "QA")));

            lista.Adicionar(new ContaCorrente(872, 3589647, new Cliente("Rodrigo", "245.456.789-25", "Desenvolvedor")));
            lista.Adicionar(new ContaCorrente(873, 2568749, new Cliente("Pedro", "548.354.856-56", "Analista")));
            lista.Adicionar(new ContaCorrente(874, 3541258, new Cliente("Rafael", "254.358.425-25", "QA")));
            lista.Adicionar(new ContaCorrente(875, 3589647, new Cliente("Rodrigo", "245.456.789-25", "Desenvolvedor")));

            lista.AdicionarVarios(
                new ContaCorrente(876, 3589647, new Cliente("Rodrigo", "245.456.789-25", "Desenvolvedor")),
                new ContaCorrente(877, 3589647, new Cliente("Rodrigo", "245.456.789-25", "Desenvolvedor")),
                new ContaCorrente(878, 3589647, new Cliente("Rodrigo", "245.456.789-25", "Desenvolvedor")),
                new ContaCorrente(879, 3589647, new Cliente("Rodrigo", "245.456.789-25", "Desenvolvedor")),
                new ContaCorrente(880, 3589647, new Cliente("Rodrigo", "245.456.789-25", "Desenvolvedor")));

            lista.Remover(new ContaCorrente(877, 3589647, new Cliente("Rodrigo", "245.456.789-25", "Desenvolvedor")));

            // Indexador, para chamar o objeto instanciando com um indice, como se fosse um array
            Console.WriteLine("Item no indice 6: " + lista[5].Numero);

            // Indexador com params, para retornar um array de contas pelos indices
            Console.WriteLine("Array de contas: " + lista[3, 5, 8]);

            lista.ListarItens();
        }

        static void ListaGenerica()
        {
            // Lista Generica de int
            ListaGenerica<int> idades = new ListaGenerica<int>();

            idades.Adicionar(90);
            idades.AdicionarVarios(5,36,84,25,31,96);
            idades.Remover(36);
            idades.Adicionar(63);
            idades.ListarItens();

            Console.WriteLine("Item posição 4: " + idades[3]);
        }
    }
}