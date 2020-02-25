using ByteBank.Service;
using ByteBank.Service.Cambio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Controller
{
    public class CambioController: ControllerBase
    {
        private ICambioService _cambioService;
        public CambioController()
        {
            _cambioService = new CambioTesteService();
        }

        // Controller da pagina MXN
        public string MXN()
        {
            var valorFinal = _cambioService.Calcular("MXN", "BRL", 1);
            var textoPagina = View();

            // Substituindo tag coringa da pagina, para valor calculado
            var textoResultado = textoPagina.Replace("VALOR_EM_REAIS", valorFinal.ToString());

            return textoResultado;
        }

        // Controller da pagina USD
        public string USD()
        {
            var valorFinal = _cambioService.Calcular("USD", "BRL", 1);
            var textoPagina = View();

            // Substituindo tag coringa da pagina, para valor calculado
            var textoResultado = textoPagina.Replace("VALOR_EM_REAIS", valorFinal.ToString());

            return textoResultado;
        }

        public string Calculo(string moedaOrigem, string moedaDestino, decimal valor)
        {
            var valorFinal = _cambioService.Calcular(moedaOrigem, moedaDestino, valor);
            var textoPagina = View();

            // Substituindo tags coringas da pagina, para valor calculado
            var textoResultado = textoPagina
                .Replace("VALOR_MOEDA_ORIGEM", valor.ToString())
                .Replace("MOEDA_ORIGEM", moedaOrigem)
                .Replace("VALOR_MOEDA_DESTINO", moedaDestino)
                .Replace("MOEDA_DESTINO", valorFinal.ToString());

            return textoResultado;
        }

        public string Calculo(string moedaDestino, decimal valor) =>
            Calculo("BRL", moedaDestino, valor);
    }
}
