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
            UtilizandoShadowProperties();

            ListarDadosBanco();

            ListarDadosRelacionalComFiltro();

            Console.ReadLine();
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
            }
        }

        public static void ListarDadosBanco()
        {
            using (var context = new AluraFilmesContext())
            {
                context.LogSQLToConsole();

                // Listando Atores
                var atores = context.Atores.ToList();
                foreach (var item in atores)
                {
                    Console.WriteLine(item);
                }

                // Listando Filmes
                var filmes = context.Filmes.ToList();
                foreach (var item in filmes)
                {
                    Console.WriteLine(item);
                }

                // Listando Relacionamento Filmes/Ator
                var filme = context.Filmes
                        .Include(f => f.Atores)
                        .ThenInclude(fa => fa.Ator)
                        .First();

                Console.WriteLine(filme);
                foreach (var item in filme.Atores)
                {
                    Console.WriteLine(item.Ator);
                }

                // Listando Relacionamento Filme/Categoria
                var categoria = context.Categorias
                    .Include(c => c.Filmes)
                    .ThenInclude(fc => fc.Filme)
                    .First();

                Console.WriteLine(categoria);
                foreach (var item in categoria.Filmes)
                {
                    Console.WriteLine(item.Filme);
                }

            }
        }

        private static void ListarDadosRelacionalComFiltro()
        {
            using (var context = new AluraFilmesContext())
            {
                // Listando Relacionamento Filme/Idiomas
                var idiomas = context.Idiomas
                    .Include(c => c.FilmesFalados);

                foreach (var idioma in idiomas)
                {
                    Console.WriteLine(idioma);

                    Console.WriteLine("Filmes Falados");
                    foreach (var filmesFalados in idioma.FilmesFalados)
                    {
                        Console.WriteLine(filmesFalados);
                    }
                    Console.WriteLine("\n");
                }
            }
        }
    }
}