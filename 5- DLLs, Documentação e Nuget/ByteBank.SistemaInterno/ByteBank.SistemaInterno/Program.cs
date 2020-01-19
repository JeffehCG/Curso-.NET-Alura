using _01__ByteBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Referenciando a Biblioteca de classes ByteBank.Modelos externamente da solução
// É preciso referenciar a DLL da pasta do projeto ByteBank.Modelos/bin/Debug
// Essa DLL sera copiada para pastas 5- DLLs, Documentação e Nuget/Bibliotecas (E tambem o arquivo XML de documentação)
namespace ByteBank.SistemaInterno
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta = new ContaCorrente(356,548692);
            Console.WriteLine(conta.Saldo);

            Console.ReadLine();
        }
    }
}
