using ByteBank.Service;
using ByteBank.Service.Cartao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Controller
{
    public class CartaoController: ControllerBase
    {
        private ICartaoService _cartaoService;

        // Usando Injeção de dependencias
        public CartaoController(ICartaoService cartaoService)
        {
            _cartaoService = cartaoService;
        }
        public string Debito()
        {
            return View(new { CartaoNome = _cartaoService.ObterCartaoDeDebitoDeDestaque() });
        }

        public string Credito()
        {
            return View(new { CartaoNome = _cartaoService.ObterCartaoDeCreditoDeDestaque() });
        }
    }
}
