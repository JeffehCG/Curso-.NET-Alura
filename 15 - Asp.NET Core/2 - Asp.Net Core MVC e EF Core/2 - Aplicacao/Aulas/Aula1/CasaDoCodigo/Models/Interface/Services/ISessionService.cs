using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models.Interface.Services
{
    public interface ISessionService
    {
        int? GetPedidoId();
        void SetPedidoId(int pedidoId);
    }
}
