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

            var webApplication = new WebApplication(prefixos);
            webApplication.Iniciar();
        }
    }
}
