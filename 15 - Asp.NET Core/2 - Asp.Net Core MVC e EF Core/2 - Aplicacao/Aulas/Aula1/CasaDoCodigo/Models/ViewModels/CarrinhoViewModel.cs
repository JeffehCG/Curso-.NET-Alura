using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models.ViewModels
{
    public class CarrinhoViewModel
    {
        public CarrinhoViewModel(IList<ItemPedido> items)
        {
            Items = items;
        }

        public IList<ItemPedido> Items { get; }

        public decimal Total => Items.Sum(i => i.Quantidade * i.PrecoUnitario);
    }
}
