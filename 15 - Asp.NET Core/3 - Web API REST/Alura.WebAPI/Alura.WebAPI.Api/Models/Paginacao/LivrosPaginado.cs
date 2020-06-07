using Alura.ListaLeitura.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alura.WebAPI.Api.Models.Paginacao
{
    public static class LivrosPaginadoExtensions
    {
        public static LivrosPaginado ToLivrosPaginado(this IQueryable<LivroApi> query, Paginacao paginacao)
        {
            var totalItens = query.Count();
            var totalPaginas = (int)Math.Ceiling(totalItens / (double)paginacao.Tamanho);
            return new LivrosPaginado()
            {
                Total = totalItens,
                TotalPaginas = totalPaginas,
                NumeroPagina = paginacao.Pagina,
                TamanhoPagina = paginacao.Tamanho,
                Resultado = query
                    .Skip(paginacao.Tamanho * (paginacao.Pagina - 1)) // Descartando Itens de acordo com a pagina
                    .Take(paginacao.Tamanho)
                    .ToList(),
                Anterior = paginacao.Pagina > 1 ? $"livros?pagina={paginacao.Pagina - 1}&tamanho={paginacao.Tamanho}" : "",
                Proximo = paginacao.Pagina < totalPaginas ? $"livros?pagina={paginacao.Pagina + 1}&tamanho={paginacao.Tamanho}" : ""
            };
        }
    }

    public class LivrosPaginado
    {
        public int Total { get; set; }
        public int TotalPaginas { get; set; }
        public int TamanhoPagina { get; set; }
        public int NumeroPagina { get; set; }
        public IList<LivroApi> Resultado { get; set; }
        public string Anterior { get; set; }
        public string Proximo { get; set; }
    }
}
