using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Alura.ListaLeitura.App.Utilitarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    public class LivrosLogica
    {
        // HttpContext encapsula todas as informações necessárias sobre o contexto de uma requisição web.
        // O parametro context esta sendo enviado automaticamente pelo .NET Core
        public static Task ParaLer(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var conteudoArquivo = MontarListaLivros(_repo.ParaLer.Livros);

            // Retornando uma Task
            return context.Response.WriteAsync(conteudoArquivo);
        }

        public static Task Lendo(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var conteudoArquivo = MontarListaLivros(_repo.Lendo.Livros);

            // Retornando uma Task
            return context.Response.WriteAsync(conteudoArquivo);
        }

        public static Task Lidos(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var conteudoArquivo = MontarListaLivros(_repo.Lidos.Livros);

            // Retornando uma Task
            return context.Response.WriteAsync(conteudoArquivo);
        }

        public static Task Detalhes(HttpContext context)
        {
            int id = Convert.ToInt32(context.GetRouteValue("id"));
            var repo = new LivroRepositorioCSV();
            var livro = repo.Todos.Where(l => l.Id == id).FirstOrDefault();

            return livro != null ? context.Response.WriteAsync(livro.Detalhes()) : context.Response.WriteAsync("Livro não encontrado!");
        }

        private static string MontarListaLivros(IEnumerable<Livro> livros)
        {
            var conteudoArquivo = CarregamentoArquivo.CarregaArquivoHTML("lista-livros");
            string listaLivrosHtml = string.Empty;

            foreach (var item in livros)
            {
                listaLivrosHtml += $"<li>{item.Id} - {item.Titulo} - {item.Autor}</li> <br/>";
            }

            return conteudoArquivo.Replace("#NOVO-ITEM#", listaLivrosHtml);
        }

    }
}
