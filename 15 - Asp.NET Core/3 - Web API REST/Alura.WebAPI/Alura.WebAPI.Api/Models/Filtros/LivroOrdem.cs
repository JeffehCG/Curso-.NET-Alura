using Alura.ListaLeitura.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core; // Utilizado para OrderBy() poder aceitar um parametro String (Com o nome da propriedade)
using System.Text;

namespace Alura.WebAPI.Api.Models.Filtros
{
    public static class LivroOrdemExtensions
    {
        public static IQueryable<Livro> AplicaOrdem(this IQueryable<Livro> query, LivroOrdem ordem)
        {
            if(ordem != null && ordem.OrdenarPor != null)
            {
                query = query.OrderBy(ordem.OrdenarPor);
            }

            return query;
        }
    }

    public class LivroOrdem
    {
        public string OrdenarPor { get; set; }
    }
}
