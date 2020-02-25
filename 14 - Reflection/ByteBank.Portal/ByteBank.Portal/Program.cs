using ByteBank.Portal.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal
{
    class Program
    {
        static void Main(string[] args)
        {
            // Portas que o HttpListener ficara escutando
            var prefixos = new string[] { "http://localhost:5341/" };

            Console.WriteLine("Para testar a aplicação web digite por exemplo alguma das rotas abaixo");
            Console.WriteLine("localhost:5341/Cambio/Calculo?moedaOrigem=BRL&moedaDestino=USD&valor=10");
            Console.WriteLine("localhost:5341/Cambio/Calculo?moedaDestino=USD&valor=10");
            Console.WriteLine("localhost:5341/Cambio/USD");

            var webApplication = new WebApplication(prefixos);
            webApplication.Iniciar();
        }
    }
}
