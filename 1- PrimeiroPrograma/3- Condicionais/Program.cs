using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3__Condicionais
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando projeto 3. Condicionais");

            int idade = 18;
            bool possuiAcompanhante = false;
            string mensagemAdicional;

            if (possuiAcompanhante)
            {
                mensagemAdicional = "Essa acompanhado";
            }
            else
            {
                mensagemAdicional = "Não esta acompanhado";
            }

            if (idade >= 18 || possuiAcompanhante)
            {
                Console.WriteLine("Pode entrar");
                Console.WriteLine(mensagemAdicional);
            }
            else
            {
                Console.WriteLine("Não pode entrar");
            }

            Console.ReadLine();
        }
    }
}
