using CasaDoCodigo.Repository;
using System.Collections.Generic;

namespace CasaDoCodigo.Models.Interface.Repository
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
        void ImportarListaProdutos(List<Produto> produtos);
    }
}