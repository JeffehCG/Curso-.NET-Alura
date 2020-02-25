using ByteBank.Portal.Filtros;
using ByteBank.Portal.Infraestrutura.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura.Filtros
{
    public class FilterResolver
    {
        internal FilterResult VerificarFiltros(ActionBindInfo actionBindInfo)
        {
            var methodInfo = actionBindInfo.MethodInfo;

            // O segundo atributo define se sera pego Attributes das classes mães 
            var atributos = methodInfo.GetCustomAttributes(typeof(FiltroAttribute), false);

            // Verificando se o metodo podera ser executado seguindo os filtros
            foreach(FiltroAttribute filtro in atributos)
            {
                if (!filtro.PodeContinuar())
                {
                    return new FilterResult(false);
                }
            }

            return new FilterResult(true);
        }
    }
}
