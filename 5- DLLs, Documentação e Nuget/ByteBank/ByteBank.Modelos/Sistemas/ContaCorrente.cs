using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01__ByteBank
{
    //Comentarios <summary> para documentar
    // Para essa documentação ser gerada para o DLL (E ser visualizada externamente) e preciso seguir alguns passos
    // Botão direito na Biblioteca, Propriedades/Build e marcar o checkbox arquivo de documentação XML 

    /// <summary>
    /// Esta classe define uma Conta Corrente do banco ByteBank
    /// </summary>
    public class ContaCorrente
    {
        public static int TotalContasCriadas { get; private set; }
        public static double TaxaOperacao { get; set; }

        public Cliente Titular { get; set; }
        public int ContadorSaqueNaoPermitidos { get; private set; }
        public int ContadorTransferenciaNaoPermitidos { get; private set; }

        public int Numero { get; }
        public int Agencia { get; }

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

        /// <summary>
        /// Cria uma instancia de ContaCorrente com os argumentos utilizados
        /// </summary>
        /// <param name="numeroAgencia"> Representa o valor da propriedade <see cref="Agencia"/>, e deve possuir um valor maior que zero</param>
        /// <param name="numeroConta"> Representa o valor da propriedade <see cref="Numero"/>, e deve possuir um valor maior que zero</param>
        public ContaCorrente(int numeroAgencia, int numeroConta)
        {
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

        /// <summary>
        /// Realiza o saque e atualiza o valor da propriedade <see cref="Saldo"/>
        /// </summary>
        /// <exception cref="ArgumentException">Exceção lançada quando um valor negativo é utilizado no argumento <paramref name="valor"/></exception>
        /// <exception cref="SaldoInsuficienteException">Exceção lançada quando o valor de <paramref name="valor"/> é maior que o valor da propriedade <see cref="Saldo"/></exception>
        /// <param name="valor"> Representa o valor do saque, deve ser maior que 0 e menor que o <see cref="Saldo"/></param>
        public void Sacar(double valor)
        {
            if (_saldo < valor)
            {
                ContadorSaqueNaoPermitidos++;
                throw new SaldoInsuficienteException(_saldo, valor);
            }

            if (valor < 0)
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

                catch (SaldoInsuficienteException ex)
                {
                    ContadorTransferenciaNaoPermitidos++;
                    throw new OperacaoFinanceiraException("Operação não realizada", ex);
                }
                conta.Depositar(valor);
            }
        }
    }
}
