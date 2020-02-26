using ByteBank.Portal.Filtros;
using ByteBank.Portal.Model;
using ByteBank.Service;
using ByteBank.Service.Cambio;
using ByteBank.Service.Cartao;
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
        private ICartaoService _cartaoService;

        // Usando Injeção de dependencias
        public CambioController(ICambioService cambioService , ICartaoService cartaoService)
        {
            _cambioService = cambioService;
            _cartaoService = cartaoService;
        }

        // Controller da pagina MXN
        // Funciona apenas em horario comercial
        // Classe de Attribute em (ByteBank.Portal.Filtros)
        [ApenasHorarioComercialFiltro]
        public string MXN()
        {
            var valorFinal = _cambioService.Calcular("MXN", "BRL", 1);
            var textoPagina = View();

            // Substituindo tag coringa da pagina, para valor calculado
            var textoResultado = textoPagina.Replace("VALOR_EM_REAIS", valorFinal.ToString());

            return textoResultado;
        }

        // Controller da pagina USD
        [ApenasHorarioComercialFiltro]
        public string USD()
        {
            var valorFinal = _cambioService.Calcular("USD", "BRL", 1);
            var textoPagina = View();

            // Objeto anonimo, sem uma classe especifica
            var modeloAnonimo = new
            {
                ValorEmReais = valorFinal.ToString()
            };

            return View(modeloAnonimo);
        }

        public string Calculo(string moedaOrigem, string moedaDestino, decimal valor)
        {
            var valorFinal = _cambioService.Calcular(moedaOrigem, moedaDestino, valor);
            var cartaoPromocao = _cartaoService.ObterCartaoDeCreditoDeDestaque();

            // Modelo da View
            var modelo = new CalculoCambioModel 
            {
                MoedaDestino = moedaDestino,
                MoedaOrigem = moedaOrigem,
                ValorOrigem = valor,
                ValorDestino = valorFinal,
                CartaoPromocao = cartaoPromocao
            };

            return View(modelo);
        }

        [ApenasHorarioComercialFiltro]
        public string Calculo(string moedaDestino, decimal valor) =>
            Calculo("BRL", moedaDestino, valor);
    }
}
