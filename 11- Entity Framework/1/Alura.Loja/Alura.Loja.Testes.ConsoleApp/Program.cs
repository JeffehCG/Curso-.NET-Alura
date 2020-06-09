using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Migração automatica
            using (var contexto = new LojaContext())
            {
                contexto.Database.Migrate();
            }

            Console.WriteLine("Exemplo Um Para Muitos");
            //UmParaMuitos();
            RecuperarDadosUmParaMuitos();

            Console.WriteLine("Exemplo Muitos Para Muitos");
            //MuitosParaMuitos();
            RecuperandoDadosMuitosParaMuitos();

            Console.WriteLine("Exemplo Um Para Um");
            //UmParaUm();
            RecuperarDadosUmParaUm();

            QueryUmPoucoMaisComplexa();

            Console.ReadLine();
        }

        #region Relacionamentos entre tabelas

        #region Exemplo de Relacionamentos (Inserção)
        private static void UmParaMuitos()
        {
            // Compra de 6 pães franceses
            var paoFrances = new Produto();
            paoFrances.Nome = "Pão Frances";
            paoFrances.PrecoUnitario = 0.40;
            paoFrances.Unidade = "Unidade";
            paoFrances.Categoria = "Padaria";

            var compra = new Compra();
            compra.Quantidade = 6;
            compra.Produto = paoFrances;
            compra.Preco = paoFrances.PrecoUnitario * compra.Quantidade;

            using(var context = new LojaContext())
            {
                GerarLogSqlEntity(context);

                // Sera adicionado o Produto e a Compra ao mesmo tempo (Pois o produto Pão Frances não existe)
                context.Compras.Add(compra);
                ExibeEntries(context.ChangeTracker.Entries());

                context.SaveChanges();
                ExibeEntries(context.ChangeTracker.Entries());
            }
        }

        private static void MuitosParaMuitos()
        {
            var p1 = new Produto(){ Nome = "Molho de Tomate", PrecoUnitario = 1.49, Unidade = "Unidade", Categoria = "Alimento" };
            var p2 = new Produto(){ Nome = "Milho em Lata", PrecoUnitario = 1.49, Unidade = "Unidade", Categoria = "Alimento" };
            var p3 = new Produto(){ Nome = "Achocolatado", PrecoUnitario = 1.49, Unidade = "Unidade", Categoria = "Alimento" };

            var promocaoDePascoa = new Promocao();
            promocaoDePascoa.Descricao = "Páscoa Feliz";
            promocaoDePascoa.DataInicio = DateTime.Now;
            promocaoDePascoa.DataTermino = DateTime.Now.AddMonths(3);

            promocaoDePascoa.IncluiProduto(p1);
            promocaoDePascoa.IncluiProduto(p2);
            promocaoDePascoa.IncluiProduto(p3);

            using (var context = new LojaContext())
            {
                GerarLogSqlEntity(context);

                // Sera adicionado os Produtos e a Promoção ao mesmo tempo
                context.Promocoes.Add(promocaoDePascoa);
                ExibeEntries(context.ChangeTracker.Entries());

                context.SaveChanges();
                ExibeEntries(context.ChangeTracker.Entries());
            }

        }

        private static void UmParaUm()
        {
            var cliente = new Cliente()
            {
                Nome = "Rodrigo Ferreira",
                EnderecoDeEntrega = new Endereco() 
                { 
                    Numero = 12, 
                    Logradouro = "Rua André Falcão de rezende", 
                    Complemento = "casa", 
                    Bairro = "Americanopolis",
                    Cidade = "São Paulo"
                }
            };

            using (var context = new LojaContext())
            {
                GerarLogSqlEntity(context);

                // Sera adicionado o Produto e a Compra ao mesmo tempo (Pois o produto Pão Frances não existe)
                context.Clientes.Add(cliente);
                ExibeEntries(context.ChangeTracker.Entries());

                context.SaveChanges();
                ExibeEntries(context.ChangeTracker.Entries());
            }
        }
        #endregion

        #region Exemplo Exemplo de Relacionamentos (Recuperando dados)

        private static void RecuperandoDadosMuitosParaMuitos()
        {
            using (var context = new LojaContext())
            {
                GerarLogSqlEntity(context);

                // Recuperando Promocao e seus produtos relacionados
                var promocao = context
                    .Promocoes
                    .Include(p => p.Produtos)
                        .ThenInclude(p => p.Produto)
                    .FirstOrDefault();

                Console.WriteLine($"Promoção {promocao.Descricao}");
                foreach (var item in promocao.Produtos)
                {
                    Console.WriteLine($"Produto: {item.Produto.Nome}");
                }
            }
        }

        private static void RecuperarDadosUmParaUm()
        {
            using (var context = new LojaContext())
            {
                GerarLogSqlEntity(context);

                var cliente = context
                    .Clientes
                    .Include(c => c.EnderecoDeEntrega)
                    .FirstOrDefault();

                Console.WriteLine($"Cliente: {cliente.Nome}, Endereço: {cliente.EnderecoDeEntrega.Logradouro}");
            }
        }

        private static void RecuperarDadosUmParaMuitos()
        {
            using (var context = new LojaContext())
            {
                GerarLogSqlEntity(context);

                var produto = context
                    .Produtos
                    .Include(c => c.Compras)
                    .Where(c => c.Categoria == "Padaria")
                    .FirstOrDefault();

                Console.WriteLine($"Compras Produto {produto.Nome} ");
                foreach (var item in produto.Compras)
                {
                    Console.WriteLine($"Quantidade Compra: {item.Quantidade}");
                }

            }
        }

        private static void QueryUmPoucoMaisComplexa()
        {
            using (var context = new LojaContext())
            {
                GerarLogSqlEntity(context);

                var produto = context
                    .Produtos
                    .Include(c => c.Compras)
                    .Where(c => c.Categoria == "Padaria")
                    .FirstOrDefault();

                // Selecionando apenas compras acima de 1.0
                context.Entry(produto)
                    .Collection(p => p.Compras)
                    .Query()
                    .Where(c => c.Preco > 1.0)
                    .Load();

                Console.WriteLine($"Compras Produto {produto.Nome} ");
                foreach (var item in produto.Compras)
                {
                    Console.WriteLine($"Quantidade Compra: {item.Quantidade}");
                }
            }

        }

        #endregion

        #endregion

        #region Analisando e Entendendo Gerenciamento Status Entity
        private static void AnalisandoEEntendoStatusEntriesEntity()
        {
            using (var context = new LojaContext())
            {
                GerarLogSqlEntity(context);

                var produtos = context.Produtos.ToList();

                ExibeEntries(context.ChangeTracker.Entries());

                // Analisando status Added
                var novoProduto = new Produto()
                {
                    Nome = "Desinfetante",
                    Categoria = "Limpeza",
                    PrecoUnitario = 2.99
                };

                context.Produtos.Add(novoProduto);

                ExibeEntries(context.ChangeTracker.Entries());

                context.SaveChanges();

                ExibeEntries(context.ChangeTracker.Entries());

                // Analisando status Modified
                novoProduto.Nome = "Amaciante";

                ExibeEntries(context.ChangeTracker.Entries());

                context.SaveChanges();

                ExibeEntries(context.ChangeTracker.Entries());

                // Analisando status Deleted
                var p1 = context.Produtos.ToList().Last();
                context.Produtos.Remove(p1);
                ExibeEntries(context.ChangeTracker.Entries());

                context.SaveChanges();

                ExibeEntries(context.ChangeTracker.Entries());

            }
        }

        private static void ExibeEntries(IEnumerable<EntityEntry> entries)
        {
            Console.WriteLine("=====================");
            foreach (var item in entries)
            {
                Console.WriteLine(item.Entity.ToString() + " - " + item.State);
            }
        }

        private static void GerarLogSqlEntity(LojaContext context)
        {
            // Gerando log das ações do entity (Added, Modified etc...)
            var serviceProvider = context.GetInfrastructure<IServiceProvider>();
            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            loggerFactory.AddProvider(SqlLoggerProvider.Create());
        }
        #endregion

        #region CRUD

        private static void RecuperarProdutos()
        {
            using(var context = new ProdutoDAOEntity())
            {
                IList<Produto> produtos = context.Listar();
                Console.WriteLine($"--------------Exibindo Produto ({produtos.Count()} - encontrados)-----------------");
                foreach (var item in produtos)
                {
                    Console.WriteLine(item.Nome);
                }
            }
        }

        private static void ExcluirProdutos()
        {
            Console.WriteLine("--------------Excluindo Produtos-----------------");
            using (var context = new ProdutoDAOEntity())
            {
                IList<Produto> produtos = context.Listar();
                foreach (var item in produtos)
                {
                    context.Remover(item);
                }
            }
        }

        private static void AtualizandoProdutos()
        {
            Console.WriteLine("--------------Atualizando Produtos-----------------");
            using (var context = new ProdutoDAOEntity())
            {
                var produto = context.Listar().First();
                produto.Nome = "Liga da Justiça";

                context.Atualizar(produto);
            }
        }

        private static void GravarUsandoEntity()
        {
            Console.WriteLine("--------------Gravando Produto-----------------");

            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.PrecoUnitario = 19.89;

            using (var context = new ProdutoDAOEntity())
            {
                context.Adicionar(p);
            }
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.PrecoUnitario = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }

        #endregion
    }
}
