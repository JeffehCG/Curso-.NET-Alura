using _01__ByteBank.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01__ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tratando erro de divisão por zero de maneira diferenciada
            try
            {
                CarregarContas();
                MetodosComExeptions();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Não é possivel divisão por zero");
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine("Argumento com problema: "+ ex.ParamName);
                Console.WriteLine("Ocorreu uma exceção do tipo ArgumentExecption");
                Console.WriteLine(ex.Message);
            }
            catch(SaldoInsuficienteException ex)
            {
                Console.WriteLine("Ocorreu uma exceção do tipo SaldoInsuficienteException");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            catch(OperacaoFinanceiraException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                Console.WriteLine("Informações de INNER EXCEPTION (exceção interna");

                Console.WriteLine(ex.InnerException.Message);
                Console.WriteLine(ex.InnerException.StackTrace);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            
            Console.ReadLine();
        }

        private static void CarregarContas()
        {
            // IDisposable
            //Se o objeto leitor for instanciado, no final do bloco de codigo do using o metodo Disposable da classe sera chamado
            using (LeitorDeArquivo leitor = new LeitorDeArquivo("contas.txt"))
            {
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
            }

            //LeitorDeArquivo leitor = new LeitorDeArquivo
            //try
            //{
            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();
            //}
            //catch(IOException)
            //{
            //    Console.WriteLine("Exceção do tipo IOException capturada e tratada");
            //}
            //finally
            //{
            //    leitor.Fechar();
            //}
        }

        static void MetodosComExeptions()
        {
            ErroTransferencia();
            ErroSaque();
            InstanciarNumeroAgenciaZero();
            TestaDivisao(0);
            InstanciarNull();
        }

        private static void TestaDivisao(int divisor)
        {

            int resultado = Dividir(10, divisor);
            Console.WriteLine("Resultado da divisão de 10 por " + divisor + " é " + resultado);

        }

        private static int Dividir(int numero, int divisor)
        {
            return numero / divisor;
        }

        private static ContaCorrente InstanciarNull()
        {
            try
            {
                ContaCorrente conta = null;
                Console.WriteLine(conta.Saldo);
                return conta;
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Não é possivel exibir valor de uma referencia nulla");
                //O metodo Instanciar exigi um retorno de ContaCorrente, por isso é necesserio colocar throw para lançar a exeção
                throw;
            }
        }

        private static void InstanciarNumeroAgenciaZero()
        {
            ContaCorrente conta = new ContaCorrente(-5, -9);
        }

        private static void ErroSaque()
        {
            ContaCorrente conta = new ContaCorrente(456, 4563251);
            conta.Titular = new Cliente("Julio", "654.324.698-96", "Desenvolvedor");
            conta.Depositar(50);
            conta.ExibirDados();
            conta.Sacar(500);
        }

        private static void ErroTransferencia()
        {
            ContaCorrente conta = new ContaCorrente(456, 4563251);
            conta.Titular = new Cliente("Julio", "654.324.698-96", "Desenvolvedor");

            ContaCorrente conta2 = new ContaCorrente(456, 364954);
            conta2.Titular = new Cliente("Jessica", "654.325.478-15", "Desenvolvedor");

            conta.Depositar(500);
            conta.ExibirDados();

            conta.Transferencia(700, conta2);

            conta.ExibirDados();
            conta2.ExibirDados();
        }
    }
}
