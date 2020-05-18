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
        // Metodo para adicionar servi�os para serem utilizados pela aplica��o
        public void ConfigureServices(IServiceCollection services)
        {
            // Configurando servi�os para utiliza��o da inje��o de dependencia
            // Ou seja, quando for chamado o metodo .GetService<ICatalogo> ele ira retornar uma instancia do tipo Catalogo

            services.AddTransient<ICatalogo, Catalogo>();
            services.AddTransient<IRelatorio, Relatorio>();

            // ou
            //services.AddScoped<ICatalogo, Catalogo>();
            //services.AddScoped<IRelatorio, Relatorio>();


            // ou
            //services.AddSingleton<ICatalogo, Catalogo>();
            //services.AddSingleton<IRelatorio, Relatorio>();

            // Diferen�as entre as configura��es de servi�os acima
            //Objetos transit�rios s�o sempre diferentes; uma nova inst�ncia � fornecida para todos os controladores e todos os servi�os.
            //Objetos com escopo s�o os mesmos em uma solicita��o, mas diferentes entre solicita��es diferentes.
            //Objetos singleton s�o os mesmos para todos os objetos e todos os pedidos.
        }

        // Utiliza��o dos servi�os adicionados (Definindo o fluxo de chamadas)
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // Utilizando inje��o de dependencia
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
