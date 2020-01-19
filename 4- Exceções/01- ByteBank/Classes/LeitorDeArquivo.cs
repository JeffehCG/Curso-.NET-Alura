using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01__ByteBank.Classes
{
    //IDisposable é uma interface utilizada para liberar recursos (Ou seja, liberar arquivo quando não esta sendo utilizada por exemplo)
    public class LeitorDeArquivo: IDisposable
    {
        public string Arquivo { get; }

        public LeitorDeArquivo(string arquivo)
        {
            Arquivo = arquivo;

            //Random erro = new Random();

            //if(erro.NextDouble() <= 0.5)
            //{
            //    throw new FileNotFoundException();
            //}
            Console.WriteLine("Abrindo arquivo: " + arquivo);
        }

        public string LerProximaLinha()
        {
            Console.WriteLine("Lendo linha . . .");

            Random erro = new Random();

            if (erro.NextDouble() <= 0.5)
            {
                throw new IOException();
            }
            
            return "Linha do arquivo";
        }

        // Metodo que tem a responsabilidade de liberar recursos
        public void Dispose()
        {
            Console.WriteLine("Fechando arquivo");
        }
    }
}
