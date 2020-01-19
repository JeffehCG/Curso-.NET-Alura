using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void UsandoStreamEntrada()
        {
            Console.WriteLine($"Digite e de enter para continuar! Para finalizar digite Sair");
            using (var fluxoEntrada = Console.OpenStandardInput())
            using (var fs = new FileStream("entradaConsole.txt", FileMode.Create))
            {
                var buffer = new byte[1024];
                int bytesLidos = 0;

                var utf8 = new UTF8Encoding();

                while (utf8.GetString(buffer, 0, bytesLidos).IndexOf("Sair") == -1)
                {
                    bytesLidos = fluxoEntrada.Read(buffer, 0, 1024);
                    fs.Write(buffer, 0, bytesLidos);
                    fs.Flush();
                } 

                Console.WriteLine($"Bytes lidos da console: {bytesLidos}");
            }
        }

        // Utilizar apenas para arquivos pequenos
        static void AuxiliaresDaClasseFile()
        {
            // Leitura
            // Pegando dados de um arquivo
            var linhas = File.ReadAllLines("contas.txt");
            Console.WriteLine("Quantidade de linhas: " + linhas.Length);

            // Pegando todo texto de um arquivo
            var texto = File.ReadAllText("contas.txt");
            Console.WriteLine("Texto : " + texto);

            // Pegando arquivo em bytes
            var bytes = File.ReadAllBytes("contas.txt");
            Console.WriteLine("Quantidade de bytes : " + bytes.Length);

            // Escrita
            // Escrevendo em um arquivo
            File.WriteAllText("escrevendoComClasseFile.txt", "Testando File.WriteAllText");

            // Recebendo dados de entrada do Console
            Console.Write("Digite o seu nome: ");
            var nome = Console.ReadLine();
            Console.WriteLine("Seu nome: " + nome);
        }
    }
}
