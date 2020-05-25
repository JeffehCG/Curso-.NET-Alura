using CasaDoCodigo.Repository;
using System.Collections.Generic;

namespace CasaDoCodigo.Models.Interface.Repository
{
    public interface IPedidoRepository : IBaseRepository<Pedido>
    {
        void AddItem(string codigo, int id);
        Pedido GetPedido(int pedidoId);
    }
}