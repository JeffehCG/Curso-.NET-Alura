using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01__ByteBank
{
    public class ContaCorrente
    {
        public static int TotalContasCriadas { get; private set; }
        public static double TaxaOperacao { get; set; }

        public Cliente Titular { get; set; }
        public int ContadorSaqueNaoPermitidos { get; private set; }
        public int ContadorTransferenciaNaoPermitidos { get; private set; }

        //Atributos de apenas leitura, apenas o contructor pode setar elas
        public int Numero {get;}
        public int Agencia { get;}

        private double _saldo = 100;  
        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }
                _saldo = value;
            }
        }

        public ContaCorrente(int numeroAgencia, int numeroConta)
        {
            //Lançando exeção fora do bloco tryCatch
            if (numeroAgencia <= 0)
            {
                ArgumentException excecao = new ArgumentException("O argumento agencia deve ser maiores que zero", nameof(numeroAgencia));
                throw excecao;
            }

            if (numeroConta <= 0)
            {
                throw new ArgumentException("O argumento numero deve ser maiores que zero", nameof(numeroConta));
            }


            Agencia = numeroAgencia;
            Numero = numeroConta;
            
            TotalContasCriadas++;
            TaxaOperacao = 30 / TotalContasCriadas;
        }

        public void ExibirDados()
        {
            Console.WriteLine(
                $"\n Titular: {Titular.nome} \n " +
                $"Agência: {Agencia} \n " +
                $"Numero: {Numero} \n " +
                $"Saldo: {_saldo}");
        }

        public void Sacar(double valor)
        {
            if (_saldo < valor)
            {
                ContadorSaqueNaoPermitidos++;
                throw new SaldoInsuficienteException( _saldo, valor);
            }

            if( valor < 0)
            {
                throw new ArgumentException("Valor invalido para o saque " + nameof(valor));
            }
            else
            {
                _saldo -= valor;
            }
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public void Transferencia(double valor, ContaCorrente conta)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor invalido para a transferencia " + nameof(valor));
            }
            else
            {
                try
                {
                    Sacar(valor);
                }
                //Um objeto da exception ja esta vindo do metodo Sacar()
                //Para seguir esse objeto dentro do catch mantendo o StackTrace Original da exceção, se pode passar o throw sem nenhum argumento
                //catch (SaldoInsuficienteException)
                //{
                //    ContadorTransferenciaNaoPermitidos++;
                //    throw;
                //}
                catch (SaldoInsuficienteException ex)
                {
                    ContadorTransferenciaNaoPermitidos++;
                    //Esta sendo criado uma nova exception, e passando como parametro a anterior, que fica dentro da InnerException 
                    throw new OperacaoFinanceiraException("Operação não realizada", ex);
                }
                conta.Depositar(valor);
            }
        }
    }
}
