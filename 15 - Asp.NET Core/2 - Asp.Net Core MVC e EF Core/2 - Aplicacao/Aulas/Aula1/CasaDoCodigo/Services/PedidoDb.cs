using CasaDoCodigo.Models;
using CasaDoCodigo.Models.Interface.Repository;
using CasaDoCodigo.Models.Interface.Services;
using CasaDoCodigo.Models.Response;
using CasaDoCodigo.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Services
{
    public class PedidoDb : IPedidoDb
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly ISessionService _sessionService;
        private readonly IItemPedidoRepository _itemPedidoRepository;
        private readonly ICadastroRepository _cadastroRepository;

        public PedidoDb(IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository, ISessionService sessionService, IItemPedidoRepository itemPedidoRepository, ICadastroRepository cadastroRepository)
        {
            _produtoRepository = produtoRepository;
            _pedidoRepository = pedidoRepository;
            _sessionService = sessionService;
            _itemPedidoRepository = itemPedidoRepository;
            _cadastroRepository = cadastroRepository;
        }

        public List<Produto> ListarProdutos()
        {
            return _produtoRepository.GetAll();
        }

        public Pedido AdicionarItemPedido(string codigo)
        {
            var idPedido = _sessionService.GetPedidoId();
            Pedido pedido = null;

            if (idPedido != null)
            {
                pedido = _pedidoRepository.GetPedido((int)idPedido);
            }

            if (pedido == null)
            {
                pedido = new Pedido();
                _pedidoRepository.Save(pedido);
                _sessionService.SetPedidoId(pedido.Id);
            }

            if (!string.IsNullOrEmpty(codigo))
            {
                _pedidoRepository.AddItem(codigo, pedido.Id);
                pedido = _pedidoRepository.GetPedido(pedido.Id);
            }

            return pedido;
        }

        public Pedido GetDadosPedido()
        {
            var idPedido = _sessionService.GetPedidoId();
            Pedido pedido = null;

            if (idPedido != null)
            {
                pedido = _pedidoRepository.GetPedido((int)idPedido);
            }

            return pedido;
        }

        public UpdateQuantidadeResponse AtualizarQuantidadeItemPedido(ItemPedido itemPedido)
        {
            var itemPedidoUpdate = _itemPedidoRepository.GetById(itemPedido.Id);

            if (itemPedidoUpdate != null)
            {
                itemPedidoUpdate.AtualizaQuantidade(itemPedido.Quantidade);

                if(itemPedidoUpdate.Quantidade <= 0)
                {
                    _itemPedidoRepository.Remove(itemPedidoUpdate);
                }
                else
                {
                    _itemPedidoRepository.Updade(itemPedidoUpdate);
                }
                
                var idPedido = _sessionService.GetPedidoId();
                var carrinhoViewModel = new CarrinhoViewModel(_pedidoRepository.GetPedido((int)idPedido).Itens);

                return new UpdateQuantidadeResponse(itemPedidoUpdate, carrinhoViewModel);
            }

            throw new ArgumentException("Item pedido não encontrado");
        }

        public Pedido AtualizarCadastro(Cadastro cadastro)
        {
            var idPedido = _sessionService.GetPedidoId();
            var pedido = _pedidoRepository.GetPedido((int)idPedido);

            var cadastroDb = _cadastroRepository.GetByParameter(p => p.Id == pedido.Cadastro.Id);

            if(cadastroDb == null)
            {
                throw new ArgumentException("cadastro");
            }

            cadastroDb.Update(cadastro);

            _cadastroRepository.Updade(cadastroDb);

            return _pedidoRepository.GetPedido((int)idPedido);
        }
    }
}
