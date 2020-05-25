using CasaDoCodigo.Models;
using CasaDoCodigo.Models.Response;
using System.Collections.Generic;

namespace CasaDoCodigo.Models.Interface.Services
{
    public interface IPedidoDb
    {
        Pedido AdicionarItemPedido(string codigo);
        Pedido AtualizarCadastro(Cadastro cadastro);
        UpdateQuantidadeResponse AtualizarQuantidadeItemPedido(ItemPedido itemPedido);
        Pedido GetDadosPedido();
        List<Produto> ListarProdutos();
    }
}