using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Alura.ListaLeitura.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var _repo = new LivroRepositorioCSV();

            #region Hospedando chamadas HTTP 

            IWebHost host = new WebHostBuilder()
                .UseKestrel() // Sera usado o servidor Kestrel
                .UseStartup<Startup>() // Definindo que a configuração ficara na classe Startup
                .Build();

            host.Run();

            #endregion

            #region Imprimento lista no console

            ImprimeLista(_repo.ParaLer);
            ImprimeLista(_repo.Lendo);
            ImprimeLista(_repo.Lidos);

            #endregion
        }

        static void ImprimeLista(ListaDeLeitura lista)
        {
            Console.WriteLine(lista);
        }
    }
}
