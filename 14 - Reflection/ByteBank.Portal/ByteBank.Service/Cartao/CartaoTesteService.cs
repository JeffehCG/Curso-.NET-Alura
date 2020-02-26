using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Service.Cartao
{
    public class CartaoTesteService : ICartaoService
    {
        public string ObterCartaoDeCreditoDeDestaque()
        {
            return "ByteBank Gold Platinum Extra Premium Special";
        }

        public string ObterCartaoDeDebitoDeDestaque()
        {
            return "ByteBank Estudante Sem Taxas de Manutenção";
        }
    }
}
