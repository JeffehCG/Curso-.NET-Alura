using Alura.Filmes.App.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Filmes.App.Extensions
{
    public static class EnumClassificacaoIndicativaExtensions
    {
        private static readonly Dictionary<string, EnumClassificacaoIndicativa> _mapa = new Dictionary<string, EnumClassificacaoIndicativa>
            {
                {"G", EnumClassificacaoIndicativa.Livre },
                {"PG", EnumClassificacaoIndicativa.MaioresQue10 },
                {"PG-13", EnumClassificacaoIndicativa.MaioresQue13 },
                {"R", EnumClassificacaoIndicativa.MaioresQue14 },
                {"NC-17", EnumClassificacaoIndicativa.MaioresQue18 },
            };

        // Metodo de extenção para o Enum Clissificação, retorna o valor em string
        public static string ParaString(this EnumClassificacaoIndicativa valor)
        {
            return _mapa.First(c => c.Value == valor).Key;
        }

        public static EnumClassificacaoIndicativa ParaValor(this string valor)
        {
            return _mapa.First(c => c.Key == valor).Value;
        }
    }
}
