using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web
{
    public class Relatorio : IRelatorio
    {
        private readonly ICatalogo catalogo;

        // Utilizando Injeção de dependencia
        // Como na classe Startup já esta configurado o serviço para ICatalogo, quando IRelatorio por instanciado ira receber automaticamente uma instancia de Catalogo
        public Relatorio(ICatalogo catalogo)
        {
            this.catalogo = catalogo;
        }

        // Metodo usando async await (Retorna uma task que sera executada pelo requisitante)
        public async Task Imprimir(HttpContext context)
        {
            foreach (var livro in catalogo.GetLivors())
            {
                await context.Response.WriteAsync($"{livro.Codigo,-10}{livro.Nome,-40}{livro.Preco.ToString("C"),10}\r\n");
            }
        }
    }
}
