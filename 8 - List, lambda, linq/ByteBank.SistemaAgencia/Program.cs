using _01__ByteBank;
using ByteBank.Funcionarios;
using ByteBank.Modelos.Utilitarios;
using ByteBank.SistemaAgencia.Comparadores;
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
            UsandoClasseList();
            DeclaracaoComVar();
            OrdenandoListas();
            OrdenandoListaObjetosComSort();
            OrdenandoListaObjetosComOrderBy();

            Console.ReadLine();
        }

        static void UsandoClasseList()
        {
            List<int> idades = new List<int>();

            idades.Add(15);
            idades.Add(23);
            idades.Add(85);
            idades.Add(28);
            idades.Add(55);
            idades.Add(65);

            idades.AddRange(new int[] {33,18,22,96});

            // Metodo Extendido da classe List, Criado na classe ListExtensoes
            idades.AdicionarVarios(71, 85, 36, 101);

            idades.Remove(28);

            for(int i = 0; i < idades.Count; i++)
            {
                Console.WriteLine(idades[i]);
            }
        }

        static void OrdenandoListas()
        {
            Console.WriteLine("\n Ordenando Listas \n");

            List<int> idades = new List<int>();
            idades.AdicionarVarios(71, 85, 29, 101, 18 , 55, 36);
            idades.Sort();

            foreach (int idade in idades)
            {
                Console.WriteLine(idade);
            }

            List<string> nomes = new List<string>()
            {
                "Vinicius",
                "Renata",
                "Gustavo",
                "Pedro",
                "Bruno"
            };
            nomes.Sort();

            foreach (string nome in nomes)
            {
                Console.WriteLine(nome);
            }
        }

        static void OrdenandoListaObjetosComSort()
        {
            Console.WriteLine("\n Ordenando Listas Objetos com Sort() \n");

            List<ContaCorrente> contas = new List<ContaCorrente>()
            {
                new ContaCorrente(954,744222),
                null,
                new ContaCorrente(684,149254),
                new ContaCorrente(465,321536),
                new ContaCorrente(351,858632),
                null,
                new ContaCorrente(265,559325)
            };

            // Para que o metodo Sort() seja executado em uma lista de classe, a classe em questão deve implementar a interface IComparable
            // No metodo CompareTo() é definido como essa ordenação sera feita
            contas.Sort();

            // Caso queira ordenar de outra forma (Diferente de como esta implementado no CompareTo())
            // Tambem tem a posibilidade de passar como parametro para o Sort uma classe com a interface IComparer
            // Onde pela mesma sera definido como sera feita a ordenação
            contas.Sort(new ComparadorContaCorrenteAgencia());

            foreach (ContaCorrente conta in contas)
            {
                if(conta != null)
                {
                    Console.WriteLine($"Numero: {conta.Numero} - Agencia: {conta.Agencia}");
                }
                else
                {
                    Console.WriteLine("Null");
                }
            }
        }

        static void OrdenandoListaObjetosComOrderBy()
        {
            Console.WriteLine("\n Ordenando Listas Objetos com OrderBy() \n");

            List<ContaCorrente> contas = new List<ContaCorrente>()
            {
                new ContaCorrente(954,744222),
                new ContaCorrente(684,149254),
                null,
                new ContaCorrente(465,321536),
                new ContaCorrente(351,858632),
                null,
                new ContaCorrente(265,559325)
            };

            // Expressão lambda conta => { return conta != null ? conta.Numero: int.MaxValue; }
            // Esta sendo usada uma operação ternaria na expressão lambda
            // Caso a conta na ordenação seja nulla a expressão lambda retorna int.MaxValue (que é o maior numero int) para ficar no final da lista 
            IOrderedEnumerable<ContaCorrente> contasOrdenadas = 
                contas.OrderBy(conta => { return conta != null ? conta.Numero: int.MaxValue; });

            foreach (ContaCorrente conta in contasOrdenadas)
            {
                if (conta != null)
                {
                    Console.WriteLine($"Numero: {conta.Numero} - Agencia: {conta.Agencia}");
                }
                else
                {
                    Console.WriteLine("Null");
                }
            }

            // Ordernar lista sem as contas nullas
            IOrderedEnumerable<ContaCorrente> contasOrdenadasSemNullas = contas
                .Where(conta => conta != null)
                .OrderBy(conta => { return conta.Numero; });

            foreach (ContaCorrente conta in contasOrdenadasSemNullas)
            {
                Console.WriteLine($"Numero: {conta.Numero} - Agencia: {conta.Agencia}");
            }
        }

        static void DeclaracaoComVar()
        {
            // Var recebe o tipo que for atribuido no valor;
            var conta = new ContaCorrente(358,369541);
            var cliente = new Cliente("Henrique", "235.125.145-25", "Medico");

            conta.Titular = cliente;
            conta.Depositar(1500);
            conta.ExibirDados();
        }
    }
}
