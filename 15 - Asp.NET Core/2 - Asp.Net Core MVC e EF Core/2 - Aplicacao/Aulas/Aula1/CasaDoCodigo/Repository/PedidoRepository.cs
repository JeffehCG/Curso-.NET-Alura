using CasaDoCodigo.Models;
using CasaDoCodigo.Models.Interface.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repository
{
    public class PedidoRepository : BaseRepository<Pedido> , IPedidoRepository
    {
        readonly IProdutoRepository _produtoRepository;
        readonly IItemPedidoRepository _itemPedidoRepository;

        public PedidoRepository(ApplicationContext context, IProdutoRepository produtoRepository, IItemPedidoRepository itemPedidoRepository) : base(context)
        {
            _produtoRepository = produtoRepository;
            _itemPedidoRepository = itemPedidoRepository;
        }

        public void AddItem(string codigo, int id)
        {
            var produto = _produtoRepository.GetByParameter(p => p.Codigo == codigo);

            if(produto == null)
            {
                throw new ArgumentException("Produto não encontrado!");
            }

            var pedido = base.GetByParameter(p => p.Id == id);

            var itemPedido = _itemPedidoRepository.GetByParameter(i => i.Produto != null && i.Produto.Codigo == codigo && i.Pedido != null && i.Pedido.Id == id);

            if(itemPedido == null)
            {
                itemPedido = new ItemPedido(pedido, produto);
                _itemPedidoRepository.Save(itemPedido);
            }
        }

        public Pedido GetPedido(int pedidoId)
        {
            var pedido = dbSet
                .Include(p => p.Itens)
                    .ThenInclude(i => i.Produto)
                .Include(p => p.Cadastro)
                .Where(p => p.Id == pedidoId)
                .SingleOrDefault();

            return pedido;
        }
    }
}
