using CaelumEstoque.DAO;
using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            ProdutosDAO dao = new ProdutosDAO();
            IList<Produto> produtos = dao.Lista();
            ViewBag.Produtos = produtos;
            return View();
        }

        public ActionResult Form()
        {
            // Listando categorias para o dropdown do formulario
            CategoriasDAO dao = new CategoriasDAO();
            IList<CategoriaDoProduto> categorias = dao.Lista();
            ViewBag.Categorias = categorias;
            return View();
        }

        //public ActionResult Adiciona(string nome, float preco, string descricao, int quantidade, int categoriaId)
        //{
        //    Produto produto = new Produto()
        //    {
        //        Nome = nome,
        //        Preco = preco,
        //        Descricao = descricao,
        //        Quantidade = quantidade,
        //        CategoriaId = categoriaId
        //    };

        //    ProdutosDAO dao = new ProdutosDAO();
        //    dao.Adiciona(produto);
        //    return View();
        //}

        //Ou


        // Esse metodo só ira receber requisições do tipo POST
        [HttpPost]
        public ActionResult Adiciona(Produto produto)
        {
            ProdutosDAO dao = new ProdutosDAO();
            dao.Adiciona(produto);

            // Redirecionando para o metodo Index, Controller Produto
            return RedirectToAction("Index", "Produto");
        }
    }
}