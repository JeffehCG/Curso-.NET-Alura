using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace web
{
    public class Startup
    {
        // Metodo para adicionar serviços para serem utilizados pela aplicação
        public void ConfigureServices(IServiceCollection services)
        {
            // Configurando serviços para utilização da injeção de dependencia
            // Ou seja, quando for chamado o metodo .GetService<ICatalogo> ele ira retornar uma instancia do tipo Catalogo

            services.AddTransient<ICatalogo, Catalogo>();
            services.AddTransient<IRelatorio, Relatorio>();

            // ou
            //services.AddScoped<ICatalogo, Catalogo>();
            //services.AddScoped<IRelatorio, Relatorio>();


            // ou
            //services.AddSingleton<ICatalogo, Catalogo>();
            //services.AddSingleton<IRelatorio, Relatorio>();

            // Diferenças entre as configurações de serviços acima
            //Objetos transitórios são sempre diferentes; uma nova instância é fornecida para todos os controladores e todos os serviços.
            //Objetos com escopo são os mesmos em uma solicitação, mas diferentes entre solicitações diferentes.
            //Objetos singleton são os mesmos para todos os objetos e todos os pedidos.
        }

        // Utilização dos serviços adicionados (Definindo o fluxo de chamadas)
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // Utilizando injeção de dependencia
            // GetService devolve uma instancia da classe relacionada a interface selecionada
            ICatalogo catalogo = serviceProvider.GetService<ICatalogo>();
            IRelatorio relatorio = serviceProvider.GetService<IRelatorio>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await relatorio.Imprimir(context);
                });
            });
        }
    }
}
