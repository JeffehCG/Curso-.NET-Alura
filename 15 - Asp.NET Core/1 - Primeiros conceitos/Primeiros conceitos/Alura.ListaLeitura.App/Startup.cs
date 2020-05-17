using Alura.ListaLeitura.App.Logica;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Definindo que sera utilizado o serviço de roteamento do ASP.Net Core
            services.AddRouting();
        }

        // O parametro app esta sendo enviado automaticamente pelo .NET Core
        public void Configure(IApplicationBuilder app)
        {
            #region Roteamento utilizando o RouteBuilder do .NET Core

            var builder = new RouteBuilder(app);
            builder.MapRoute("Livros/ParaLer", LivrosLogica.ParaLer);
            builder.MapRoute("Livros/Lendo", LivrosLogica.Lendo);
            builder.MapRoute("Livros/Lidos", LivrosLogica.Lidos);
            builder.MapRoute("Livros/Detalhes/{id:int}", LivrosLogica.Detalhes); // Rota com parametro tipado
            builder.MapRoute("Cadastro/NovoLivro/{nome}/{autor}", CadastroLogica.NovoLivro); // Rota com parametros
            builder.MapRoute("Cadastro/ExibirFormulario", CadastroLogica.ExibirFormulario);
            builder.MapRoute("Cadastro/Incluir", CadastroLogica.Incluir);
            var rotas = builder.Build();

            app.UseRouter(rotas);
            #endregion

            #region Usando reflaction para roteamento automatico

            //builder.MapRoute("{classe}/{metodo}", RoteamentoPadrao.TratamentoPadrao);
            //builder.MapRoute("{classe}/{metodo}/{id:int}", RoteamentoPadrao.TratamentoPadrao);
            //builder.MapRoute("{classe}/{metodo}/{nome}/{autor}", RoteamentoPadrao.TratamentoPadrao);

            #endregion

            // Retornando a resposta de acordo com a requisição (Utilizando Roteamento feito na mão)
            //app.Run(Roteamento);
        }


        #region Roteamento feito na mão (Aprendendo conceito)

        public Task Roteamento(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();

            // Dicionario de caminhos da aplicação http (e seu retorno)
            var caminhosAtendidos = new Dictionary<string, RequestDelegate>
            {
                {"/Livros/ParaLer", LivrosLogica.ParaLer },
                {"/Livros/Lendo", LivrosLogica.Lendo },
                {"/Livros/Lidos", LivrosLogica.Lidos }
            };

            // Retornando od dados de acordo com o caminho da requisição
            if (caminhosAtendidos.ContainsKey(context.Request.Path))
            {
                var metodo = caminhosAtendidos[context.Request.Path];

                // Invocando metodo do delagate para determinado caminho
                return metodo.Invoke(context);
            }

            // Definindo status 404 (Caminho não encontrado)
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            return context.Response.WriteAsync("Caminho inexistente.");
        }

        #endregion
    }
}