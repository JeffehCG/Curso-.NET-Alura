using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01__ByteBank
{
    public class ContaCorrente
    {
        //Atributos da classe
        public static int TotalContasCriadas { get; private set; }

        //Atributos do objeto
        public Cliente Titular { get; set; }
        public int Agencia { get; set; }
        public int Numero { get; set;  }
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

        public ContaCorrente(int agencia, int numero)
        {
            Agencia = agencia;
            Numero = numero;
            TotalContasCriadas++;
        }

        //Metodo de encapsulamento
        //public double saldo { get; private set; } = 100;
        //public void SetSaldo(double saldo)
        //{
        //    if(saldo < 0)
        //    {
        //        return;
        //    }
        //    this.saldo = saldo;
        //}

        public void ExibirDados()
        {
            Console.WriteLine(
                $"\n Titular: {Titular.nome} \n " +
                $"Agência: {Agencia} \n " +
                $"Numero: {Numero} \n " +
                $"Saldo: {_saldo}");
        }

        public bool Sacar(double valor)
        {
            if (_saldo < valor)
            {
                return false;
            }
            else
            {
                _saldo -= valor;
                return true;
            }
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public bool Transferencia(double valor, ContaCorrente conta)
        {
            if(_saldo < valor)
            {
                return false;
            }
            else
            {
                _saldo -= valor;
                conta.Depositar(valor);
                return true;
            }
        }
    }
}
