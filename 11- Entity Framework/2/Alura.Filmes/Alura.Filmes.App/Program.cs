using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new AluraFilmesContext())
            {
                context.LogSQLToConsole();

                // Listando Atores
                var atores = context.Atores.ToList();
                foreach (var item in atores)
                {
                    Console.WriteLine(item);
                }

                UtilizandoShadowProperties();

                Console.ReadLine();
            }
        }

        public static void UtilizandoShadowProperties()
        {
            using (var context = new AluraFilmesContext())
            {
                // Adicionando Ator
                var ator = new Ator();
                ator.PrimeiroNome = "Tom";
                ator.UltimoNome = "Hanks";
                context.Entry(ator).Property("last_update").CurrentValue = DateTime.Now; // Adicionando valor a uma Shadow Property

                context.Atores.Add(ator);
                //context.SaveChanges();

                // Recuperando Ator
                var ator2 = context.Atores.FirstOrDefault();

                Console.WriteLine(ator2);
                Console.WriteLine(context.Entry(ator2).Property("last_update").CurrentValue); // Recuperando valor de uma Shadow Property

                // Listar os 10 atores modificados recentemente
                var atoresMaisRecentesalterados = context.Atores
                    .OrderByDescending(a => EF.Property<DateTime>(a, "last_update")) // Ordenando por uma Shadow Property
                    .Take(10);

                foreach (var item in atoresMaisRecentesalterados)
                {
                    Console.WriteLine(item + " - " + context.Entry(item).Property("last_update").CurrentValue);
                }

                Console.ReadLine();
            }
        }
    }
}