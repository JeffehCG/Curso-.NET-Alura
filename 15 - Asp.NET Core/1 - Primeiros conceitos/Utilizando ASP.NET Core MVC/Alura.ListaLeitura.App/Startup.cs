using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Definindo que sera utilizado o ASP.NET Core MVC
            services.AddMvc();
        }

        // O parametro app esta sendo enviado automaticamente pelo .NET Core
        public void Configure(IApplicationBuilder app)
        {
            // Essa opção deve ser utilizada apenas em ambiente de desenvolvimento, habilita a exibição da pagina de detalhes do erro
            app.UseDeveloperExceptionPage();

            app.UseMvcWithDefaultRoute();
        }
    }
}