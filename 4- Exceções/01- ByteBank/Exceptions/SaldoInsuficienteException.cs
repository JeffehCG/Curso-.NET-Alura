using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01__ByteBank
{
    //Criando um tipo de exceção
    public class SaldoInsuficienteException: OperacaoFinanceiraException
    {
        public double Saldo { get; }
        public double ValorSaque { get; }
        public SaldoInsuficienteException()
        {
        }

        public SaldoInsuficienteException(string mensagem)
            :base(mensagem)
        {

        }

        public SaldoInsuficienteException(string mensagem, Exception excecaoInterna)
            : base(mensagem, excecaoInterna)
        {

        }

        //this esta chamando o contructor de apenas um parametro da propria classe
        public SaldoInsuficienteException( double saldo, double valorSaque)
            : this($"Tentativa de saque do valor de {valorSaque} em uma conta com saldo de {saldo}")
        {
            Saldo = saldo;
            ValorSaque = valorSaque;
        }
    }
}
