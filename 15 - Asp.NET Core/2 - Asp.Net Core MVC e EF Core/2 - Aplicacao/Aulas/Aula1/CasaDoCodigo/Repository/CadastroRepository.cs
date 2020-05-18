using CasaDoCodigo.Models;
using CasaDoCodigo.Models.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repository
{
    public class CadastroRepository : BaseRepository<Cadastro> , ICadastroRepository
    {
        public CadastroRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
