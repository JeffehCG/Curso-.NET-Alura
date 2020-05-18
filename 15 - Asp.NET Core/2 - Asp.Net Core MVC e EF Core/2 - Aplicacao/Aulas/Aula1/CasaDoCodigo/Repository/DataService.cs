using CasaDoCodigo.Models;
using CasaDoCodigo.Models.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repository
{
    // Classe de inicialização do banco
    public class DataService : IDataService
    {
        private readonly ApplicationContext _context;
        private readonly IProdutoRepository _produtoRepository;

        public DataService(ApplicationContext context, IProdutoRepository produtoRepository)
        {
            _context = context;
            _produtoRepository = produtoRepository;
        }

        public void InicializaDB()
        {
            // Configuração para criar o banco de dados automaticamento com o build do projeto
            _context.Database.Migrate();

            // Ou (Porem não utiliza migration)
            //context.Database.EnsureCreated();

            AdicionarListaProdutos();
        }

        private void AdicionarListaProdutos()
        {
            var listaLivrosJson = File.ReadAllText("Repository\\livros.json");
            var listaLivros = JsonConvert.DeserializeObject<List<Produto>>(listaLivrosJson);

            _produtoRepository.ImportarListaProdutos(listaLivros);
        }
    }
}
