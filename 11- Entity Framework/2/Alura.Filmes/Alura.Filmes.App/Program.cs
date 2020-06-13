using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
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

            UtilizandoEnumEConstraint();

            UtilizandoHeranca();

            ExecutandoCodigoSQL();

            UtilizandoProcedures();

            InsertDeletePeloExecuteSqlCommand();

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

                // Listando o Top 5 de atores com mais filmes feitos
                var atoresMaisAtuantes = context.Atores
                    .Include(a => a.Filmes)
                    .ThenInclude(a => a.Filme)
                    .OrderByDescending(a => a.Filmes.Count())
                    .Take(5);

                foreach (Ator ator in atoresMaisAtuantes)
                {
                    Console.WriteLine($"O ator {ator.PrimeiroNome} {ator.UltimoNome} atuou em {ator.Filmes.Count()} filmes");
                }
            }
        }

        private static void UtilizandoEnumEConstraint()
        {
            using (var context = new AluraFilmesContext())
            {
                var filme = new Filme()
                {
                    Titulo = "Senho dos Anéis",
                    Duracao = 120,
                    AnoLancamento = "2000",
                    Classificacao = EnumClassificacaoIndicativa.MaioresQue18,
                    IdiomaFalado = context.Idiomas.First()
                };

                context.Filmes.Add(filme);
                //context.SaveChanges();

                var filmeInserido = context.Filmes.First(f => f.Titulo == "Senho dos Anéis");
                Console.WriteLine(filmeInserido + " - " + filmeInserido.TextoClassificacao);
            }
        }

        private static void UtilizandoHeranca()
        {
            using (var context = new AluraFilmesContext())
            {
                Console.WriteLine("Clientes");
                foreach (var cliente in context.Clientes)
                {
                    Console.WriteLine(cliente);
                }

                Console.WriteLine("Funcionarios");
                foreach (var funcionario in context.Funcionarios)
                {
                    Console.WriteLine(funcionario);
                }
            }
        }

        private static void ExecutandoCodigoSQL()
        {
            using (var context = new AluraFilmesContext())
            {
                // Nessa versão do entity essa forma contem algumas limitações, o select só pode retornar dados de uma tabela em questão
                var sql = @"SELECT a.*
                            FROM actor a
                            INNER JOIN top5_most_starred_actors filmes ON filmes.actor_id = a.actor_id";

                // "top5_most_starred_actors" é uma view do banco (queries salvas no banco na pasta Views) 

                var atoresMaisAtuantes = context.Atores
                    .FromSql(sql)
                    .Include(a => a.Filmes)
                    .ThenInclude(a => a.Filme);

                foreach (Ator ator in atoresMaisAtuantes)
                {
                    Console.WriteLine($"O ator {ator.PrimeiroNome} {ator.UltimoNome} atuou em {ator.Filmes.Count()} filmes");
                }
            }
        }

        private static void UtilizandoProcedures()
        {
            using (var context = new AluraFilmesContext())
            {
                var categoria = "Action";

                var paramCateg = new SqlParameter("category_name", categoria);

                var paramTotal = new SqlParameter
                {
                    ParameterName = "@total_actors",
                    Size = 4,
                    Direction = System.Data.ParameterDirection.Output 
                };

                context.Database
                    .ExecuteSqlCommand("total_actors_from_given_category @category_name, @total_actors OUT", paramCateg, paramTotal);

                Console.WriteLine($"O total de atores na categoria {categoria} é de {paramTotal.Value}");
            }
        }

        private static void InsertDeletePeloExecuteSqlCommand()
        {
            using (var context = new AluraFilmesContext())
            {
                var sql = "INSERT INTO language (name) VALUES ('Teste 1'), ('Teste 2'), ('Teste 3')";
                var registrosAfetados = context.Database.ExecuteSqlCommand(sql);
                Console.WriteLine($"O total de registros afetados é {registrosAfetados}");

                var deleteSql = "DELETE FROM language WHERE name LIKE 'Teste%'";
                var deleteRegistrosAfetados = context.Database.ExecuteSqlCommand(deleteSql);
                Console.WriteLine($"O total de registros afetados é {deleteRegistrosAfetados}");
            }
        }
    }
}