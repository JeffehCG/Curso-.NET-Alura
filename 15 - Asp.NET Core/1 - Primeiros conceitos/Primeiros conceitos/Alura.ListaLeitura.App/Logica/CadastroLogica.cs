using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Alura.ListaLeitura.App.Utilitarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    public class CadastroLogica
    {
        public static Task NovoLivro(HttpContext context)
        {
            var livro = new Livro()
            {
                Titulo = context.GetRouteValue("nome").ToString(), // Recuperando valor dos parametros das rotas
                Autor = context.GetRouteValue("autor").ToString()
            };

            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);
            return context.Response.WriteAsync("O livro foi adicionado com sucesso!");
        }

        public static Task Incluir(HttpContext context)
        {
            var livro = new Livro()
            {
                // Recuperando valor dos parametros das rotas chamada get (QueryString)
                //Titulo = context.Request.Query["nome"],
                //Autor = context.Request.Query["autor"]

                // Recuperando valor dos parametros das rotas chamada post (Corpo da requisição)
                Titulo = context.Request.Form["nome"],
                Autor = context.Request.Form["autor"]
            };

            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);
            return context.Response.WriteAsync("O livro foi adicionado com sucesso!");
        }

        public static Task ExibirFormulario(HttpContext context)
        {
            var html = CarregamentoArquivo.CarregaArquivoHTML("formulario");

            return context.Response.WriteAsync(html);
        }
    }
}
