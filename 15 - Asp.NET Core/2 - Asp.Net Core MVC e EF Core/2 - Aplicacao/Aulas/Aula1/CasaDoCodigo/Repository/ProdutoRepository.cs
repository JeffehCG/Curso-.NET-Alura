using CasaDoCodigo.Models;
using CasaDoCodigo.Models.Interface.Repository;
using CasaDoCodigo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repository
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext context) : base(context)
        {
        }

        public void ImportarListaProdutos( List<Produto> produtos)
        {
            foreach (var produto in produtos)
            {
                if(base.GetByParameter( p => p.Codigo == produto.Codigo) == null)
                {
                    base.Save(produto);
                }
            }
        }
    }
}
