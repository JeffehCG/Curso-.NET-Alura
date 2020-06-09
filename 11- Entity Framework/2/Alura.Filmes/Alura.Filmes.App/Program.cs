using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using System;
using System.Linq;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new AluraFilmesContext())
            {
                context.LogSQLToConsole();

                var atores = context.Atores.ToList();
                foreach (var item in atores)
                {
                    Console.WriteLine(item);
                }

                Console.ReadLine();
            }
        }
    }
}