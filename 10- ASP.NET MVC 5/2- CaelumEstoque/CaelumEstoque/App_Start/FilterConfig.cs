using CaelumEstoque.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.App_Start
{
    public class FilterConfig
    {
        // Adicionando Filtros Globais, que seram utilizados em todas controllers
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AutorizacaoFilterAttribute());
        }
        // Para que esse metodo seja executado devera ser definido no arquivo Global.asax
    }
}